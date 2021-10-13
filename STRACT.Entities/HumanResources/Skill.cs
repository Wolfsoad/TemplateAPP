using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SkillGroupId { get; set; }
        public SkillGroup SkillGroup { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
