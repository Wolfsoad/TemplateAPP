using System;
using STRACT.Entities.Users;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Declaration
{
    public class DeclarationSignature
    {
        public int SignatureId { get; set; }
        public DateTime DateSigned { get; set; }
        public int? DeclarationItemId { get; set; }
        public DeclarationItem Declaration { get; set; }
        public int? UserId { get; set; }
        public UserInTeam User { get; set; }
    }
}
