using Contact.Core.Models;
using System;
using System.Threading.Tasks;

namespace Contact.Core.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetWithContactInformationsByUUIDAsync(Guid UUID);
    }
}
