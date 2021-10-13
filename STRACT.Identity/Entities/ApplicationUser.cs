using Microsoft.AspNetCore.Identity;
using STRACT.Identity.Interfaces;
using System.Collections.Generic;

namespace STRACT.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[] ProfilePicture { get; set; }
    }
}
