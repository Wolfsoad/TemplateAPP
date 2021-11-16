using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Certifications
{
    public class Entity
    {
        public int EntityId { get; set; }
        public string Name { get; set; }
        public string SupplierCode { get; set; }
        public ICollection<ContactPerson> Contacts { get; set; }
        public ICollection<CertificationLine> CertificationLines { get; set; }
        
        //Private Properties
        private ContactPerson _mainContact;

        //Public extra properties
        public ContactPerson MainContact
        {
            get 
            { 
                GetMainContact();
                return _mainContact; 
            }
        }

        //Private Methods
        private void GetMainContact()
        {
            _mainContact = Contacts.Where(c => c.IsMainContact).FirstOrDefault();
        }

        //Public Methods


    }
}
