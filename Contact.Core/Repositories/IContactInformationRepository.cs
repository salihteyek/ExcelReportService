using Contact.Core.Models;
using Contact.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Core.Repositories
{
    public interface IContactInformationRepository : IRepository<ContactInformation>
    {
        Task<List<ReportModelView>> PersonsLocationReportAsync();
    }
}
