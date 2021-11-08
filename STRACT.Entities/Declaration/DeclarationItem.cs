using System;
using System.Collections.Generic;
using System.Linq;
using STRACT.Entities.Users;

namespace STRACT.Entities.Declaration
{
    public class DeclarationItem
    {
        public int DeclarationItemId { get; set; }
        public string Title { get; set; }
        public string Motive { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public UserInTeam User { get; set; }
        public ICollection<DeclarationRevision> Revisions { get; set; }
        public ICollection<DeclarationSignature> Signatures { get; set; }
        public bool IsSigned
        {
            get { return Signatures.Count > 0; }
        }
        public int RevisionCount
        {
            get { return Revisions.Count; }
        }
    }

}
