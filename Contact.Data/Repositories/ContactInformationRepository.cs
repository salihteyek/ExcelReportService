using Contact.Core.Models;
using Contact.Core.Repositories;

namespace Contact.Data.Repositories
{
    public class ContactInformationRepository : Repository<ContactInformation>, IContactInformationRepository
    {
        public ContactInformationRepository(RiseAssessmentDbContext context) : base(context)
        {

        }
    }
}
