using Contact.Core.Models;
using Contact.Core.Repositories;
using Contact.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Data.Repositories
{
    public class ContactInformationRepository : Repository<ContactInformation>, IContactInformationRepository
    {
        private RiseAssessmentDbContext dbContext { get => _context as RiseAssessmentDbContext; }
        public ContactInformationRepository(RiseAssessmentDbContext context) : base(context)
        {

        }

        
        public async Task<List<ReportModelView>> PersonsLocationReportAsync()
        {
            var list = await Task.Run(async () =>
            {
                var result = dbContext.ContactInformations
                                .GroupBy(g => g.Location)
                                .Select(s => new
                                {
                                    Locatin = s.Key,
                                    TotalPerson = s.Select(s2 => s2.PersonUUID).Count(),
                                    TotalPhone = s.Where(s2 => s2.Phone != null || s2.Phone != string.Empty).Select(s2 => s2.Phone).Count()
                                }).ToList();
                return result;
            });

            List<ReportModelView> resultList = new List<ReportModelView>();
            foreach (var item in list)
            {
                resultList.Add(new ReportModelView() { Location = item.Locatin, TotalPerson = item.TotalPerson, TotalPhone = item.TotalPhone });
            }
            return resultList;
        }
    }
}
