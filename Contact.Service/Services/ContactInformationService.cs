using Contact.Core.Models;
using Contact.Core.Repositories;
using Contact.Core.Services;
using Contact.Core.UnitOfWorks;
using Contact.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Service.Services
{
    public class ContactInformationService : Service<ContactInformation>, IContactInformationService
    {
        public ContactInformationService(IUnitOfWork unitOfWork, IRepository<ContactInformation> repository) : base(unitOfWork, repository)
        {

        }

        public Task<List<ReportModelView>> PersonsLocationReportAsync()
        {
            return _unitOfWork.ContactInformations.PersonsLocationReportAsync();
        }
    }
}
