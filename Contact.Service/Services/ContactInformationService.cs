using Contact.Core.Models;
using Contact.Core.Repositories;
using Contact.Core.Services;
using Contact.Core.UnitOfWorks;

namespace Contact.Service.Services
{
    public class ContactInformationService : Service<ContactInformation>, IContactInformationService
    {
        public ContactInformationService(IUnitOfWork unitOfWork, IRepository<ContactInformation> repository) : base(unitOfWork, repository)
        {

        }
    }
}
