using ClosedXML.Excel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Report.WorkerService.Services;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Report.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly RabbitMQClientService _rabbitMQClientService;
        private IModel _channel;

        public Worker(RabbitMQClientService rabbitMQClientService)
        {
            _rabbitMQClientService = rabbitMQClientService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMQClientService.Connect();
            _channel.BasicQos(0, 1, false);
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            _channel.BasicConsume(RabbitMQClientService.QueueName, false, consumer);
            consumer.Received += Consumer_Received;
            return Task.CompletedTask;
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            var createExcelMessage = System.Text.Json.JsonSerializer.Deserialize<CreateExcelMessage>(Encoding.UTF8.GetString(@event.Body.ToArray()));
            using var ms = new MemoryStream();
            var wb = new XLWorkbook();
            var ds = new DataSet();
            ds.Tables.Add(GetTable("reports"));

            wb.Worksheets.Add(ds);
            wb.SaveAs(ms);

            MultipartFormDataContent multipartFormDataContent = new();
            multipartFormDataContent.Add(new ByteArrayContent(ms.ToArray()), "file", Guid.NewGuid().ToString() + ".xlsx");
            var baseUrl = "https://localhost:44345/api/files";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync($"{baseUrl}?UUID={createExcelMessage.UUID}", multipartFormDataContent);
                if (response.IsSuccessStatusCode)
                    _channel.BasicAck(@event.DeliveryTag, false);
            }
        }

        private DataTable GetTable(string tableName)
        {
            using var httpClient = new HttpClient();
            
            var baseUrl = "https://localhost:44349/api/ContactInformation";
            var result = httpClient.GetAsync($"{baseUrl}/LocationReport").Result;
            var data = result.Content.ReadAsStringAsync().Result;
            var root = JsonConvert.DeserializeObject<List<ReportDetail>>(data);

            DataTable table = new() { TableName = tableName };
            table.Columns.Add("Location", typeof(string));
            table.Columns.Add("TotalPerson", typeof(string));
            table.Columns.Add("TotalPhone", typeof(string));

            root.ForEach(x =>
            {
                table.Rows.Add(x.Location, x.TotalPerson, x.TotalPhone);
            });
            return table;
        }
    }
}
