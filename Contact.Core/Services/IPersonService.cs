using Contact.Core.Models;
using System;
using System.Threading.Tasks;

namespace Contact.Core.Services
{
    public interface IPersonService : IService<Person>
    {
        Task<Person> GetWithContactInformationsByUUIDAsync(Guid UUID);
    }
}
