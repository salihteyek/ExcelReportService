using Contact.Core.Models;
using Contact.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Contact.Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private RiseAssessmentDbContext dbContext { get => _context as RiseAssessmentDbContext; }
        public PersonRepository(RiseAssessmentDbContext context) : base(context)
        {

        }

        public async Task<Person> GetWithContactInformationsByUUIDAsync(Guid UUID)
        {
            return await dbContext.Persons.Include("ContactInformations").SingleOrDefaultAsync(x => x.UUID == UUID);
        }
    }
}
