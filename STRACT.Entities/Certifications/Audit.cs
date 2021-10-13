using STRACT.Entities.General;
using STRACT.Entities.Kanban;
using STRACT.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Certifications
{
    public class Audit
    {
        public int AuditId { get; set; }
        public int Year { get; set; }
        public DateTime DateOfAudit { get; set; }
        public bool Concluded { get; set; }
        public int UserId { get; set; }
        public UserInTeam User { get; set; }
        public int CertificationLineId { get; set; }
        public CertificationLine CertificationLine { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; }
    }
}
