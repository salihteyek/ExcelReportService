using Microsoft.AspNetCore.Mvc;
using Report.Api.Services;
using System.Threading.Tasks;

namespace Report.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public ExcelService _excelService { get; set; }
        public ReportController(ExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpGet("CreateExcel")]
        public async Task<IActionResult> CreateExcel()
        {
            await _excelService.CreateExcelAsync();
            var message = "Excel oluşturma işleminiz kuyruğa alındı.";
            return Ok(new { message });
        }

        [HttpGet("excels")]
        public async Task<IActionResult> GetExcel()
        {
            var result = await _excelService.GetExcelsAsync();
            return Ok(result);
        }
    }
}
