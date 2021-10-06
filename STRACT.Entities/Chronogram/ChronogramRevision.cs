using STRACT.Entities.Projects;
using STRACT.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Chronogram
{
    public class ChronogramRevision
    {
        public int ChronogramRevisionId { get; set; }
        public string RevisionDescription { get; set; }
        public DateTime RevisionDate { get; set; }
        public int Version { get; set; }
        public int? UserId { get; set; }
        public UserInTeam User { get; set; }
        public int ProjectItemId { get; set; }
        public ProjectItem ProjectItem { get; set; }
        public ICollection<ChronogramLine> ChronogramLines { get; set; }
    }
}
