using System;

namespace Contact.Core.Models
{
    public class ContactInformation
    {
        public Guid UUID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        
        public Guid PersonUUID { get; set; }
        public virtual Person Person { get; set; }
    }
}
