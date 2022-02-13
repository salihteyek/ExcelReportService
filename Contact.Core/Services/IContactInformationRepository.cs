using Contact.Core.Models;
using Contact.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Core.Services
{
    public interface IContactInformationService : IService<ContactInformation>
    {
        Task<List<ReportModelView>> PersonsLocationReportAsync();
    }
}
