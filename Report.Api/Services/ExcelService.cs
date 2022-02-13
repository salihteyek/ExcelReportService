using Microsoft.EntityFrameworkCore;
using Report.Api.Enums;
using Report.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.Api.Services
{
    public class ExcelService
    {
        private readonly ExcelAppDbContext _context;
        private readonly RabbitMQPublisher _rabbitMQPublisher;

        public ExcelService(RabbitMQPublisher rabbitMQPublisher, ExcelAppDbContext context)
        {
            _context = context;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        public async Task CreateExcelAsync()
        {
            var fileName = $"excel-{Guid.NewGuid().ToString()}";
            Excels excelData = new()
            {
                UUID = Guid.NewGuid(),
                FileName = fileName,
                FileStatus = FileStatus.Hazırlanıyor,
                RequestDate = DateTime.Now
            };
            await _context.Excels.AddAsync(excelData);
            await _context.SaveChangesAsync();

            _rabbitMQPublisher.Publish(new Shared.CreateExcelMessage() { UUID = excelData.UUID });
        }

        public async Task<IEnumerable<Excels>> GetExcelsAsync()
        {
            var result = await _context.Excels.ToListAsync();
            return result;
        }
    }
}
