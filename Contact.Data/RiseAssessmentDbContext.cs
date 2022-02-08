using Contact.Core.Models;
using Contact.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Contact.Data
{
    public class RiseAssessmentDbContext : DbContext
    {
        public RiseAssessmentDbContext(DbContextOptions<RiseAssessmentDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ContactInformationConfiguration());
        }
    }
}
