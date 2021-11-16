using STRACT.Entities.Certifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STRACT.Entities.Test.Certifications
{
    public class EntityTest
    {
        [Fact]
        public void GetMainContact_TestNullContact()
        {
            List<ContactPerson> contactPeople = new List<ContactPerson>();

            Entity entity = new Entity
            {
                EntityId = 1,
                Contacts = contactPeople,
            };

            Assert.Null(entity.MainContact);
        }

        [Fact]
        public void GetMainContact_TestNoMainContact()
        {
            List<ContactPerson> contactPeople = new List<ContactPerson>
            {
                new ContactPerson(){ ContactPersonId = 1, IsMainContact = false },
                new ContactPerson(){ ContactPersonId = 2, IsMainContact = false },
            };

            Entity entity = new Entity
            {
                EntityId = 1,
                Contacts = contactPeople,
            };

            Assert.Null(entity.MainContact);
        }

        [Fact]
        public void GetMainContact_TestMainContact()
        {
            List<ContactPerson> contactPeople = new List<ContactPerson>
            {
                new ContactPerson(){ ContactPersonId = 1, IsMainContact = false },
                new ContactPerson(){ ContactPersonId = 2, IsMainContact = true },
            };

            Entity entity = new Entity
            {
                EntityId = 1,
                Contacts = contactPeople,
            };

            Assert.Equal(2, entity.MainContact.ContactPersonId);
        }
    }
}
