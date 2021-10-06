using STRACT.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.General
{
    public class AlertType
    {
        public int AlertTypeId { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public ICollection<AlertInProject> AlertInProjects { get; set; }
    }
}
