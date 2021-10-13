using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Certifications
{
    public class ContactPerson
    {
        public int ContactPersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsMainContact { get; set; }
        public int EntityId { get; set; }
        public Entity Entity { get; set; }
    }
}
