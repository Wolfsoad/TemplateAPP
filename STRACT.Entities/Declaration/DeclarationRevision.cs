using System;
using STRACT.Entities.Users;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Declaration
{
    public class DeclarationRevision
    {
        public int DeclarationRevisionId { get; set; }
        public string RevisionDescription { get; set; }
        public DateTime RevisionDate { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? DeclarationItemId { get; set; }
        public DeclarationItem DeclarationItem { get; set; }

    }
}
