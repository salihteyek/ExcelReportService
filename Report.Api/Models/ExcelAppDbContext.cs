using Microsoft.EntityFrameworkCore;

namespace Report.Api.Models
{
    public class ExcelAppDbContext : DbContext
    {
        public ExcelAppDbContext(DbContextOptions<ExcelAppDbContext> options) : base(options)
        {

        }
        public DbSet<Excels> Excels { get; set; }
    }
}
