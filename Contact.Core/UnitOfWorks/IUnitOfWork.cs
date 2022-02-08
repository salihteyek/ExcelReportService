using Contact.Core.Repositories;
using System.Threading.Tasks;

namespace Contact.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IPersonRepository Persons { get; }
        IContactInformationRepository ContactInformations { get; }
        Task SaveChangeAsync();
    }
}
