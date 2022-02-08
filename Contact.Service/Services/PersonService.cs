using Contact.Core.Models;
using Contact.Core.Repositories;
using Contact.Core.Services;
using Contact.Core.UnitOfWorks;
using System;
using System.Threading.Tasks;

namespace Contact.Service.Services
{
    public class PersonService : Service<Person>, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork, IRepository<Person> repository) : base(unitOfWork, repository)
        {

        }

        public async Task<Person> GetWithContactInformationsByUUIDAsync(Guid UUID)
        {
            return await _unitOfWork.Persons.GetWithContactInformationsByUUIDAsync(UUID);
        }
    }
}
