using Contact.Core.Repositories;
using Contact.Core.UnitOfWorks;
using Contact.Data.Repositories;
using System.Threading.Tasks;

namespace Contact.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RiseAssessmentDbContext _context;
        public UnitOfWork(RiseAssessmentDbContext context)
        {
            _context = context;
        }

        private PersonRepository _personRepository;
        private ContactInformationRepository _contactInformationRepository;

        public IPersonRepository Persons => _personRepository = _personRepository ?? new PersonRepository(_context);
        public IContactInformationRepository ContactInformations => _contactInformationRepository = _contactInformationRepository ?? new ContactInformationRepository(_context);

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
