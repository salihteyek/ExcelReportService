using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Contact.Core.Models
{
    public class Person
    {
        public Person()
        {
            ContactInformations = new Collection<ContactInformation>();
        }

        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public ICollection<ContactInformation> ContactInformations { get; set; }
    }
}
