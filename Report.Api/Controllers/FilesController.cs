using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Report.Api.Enums;
using Report.Api.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Report.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ExcelAppDbContext _context;
        public FilesController(ExcelAppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, Guid UUID)
        {
            if (file is not { Length: > 0 }) 
                return BadRequest();

            var resultFile = await _context.Excels.FirstAsync(x => x.UUID == UUID);
            var filePath = resultFile.FileName + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", filePath);

            using FileStream stream = new(path, FileMode.Create);
            await file.CopyToAsync(stream);

            resultFile.FilePath = filePath;
            resultFile.FileStatus = FileStatus.Tamamlandı;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
