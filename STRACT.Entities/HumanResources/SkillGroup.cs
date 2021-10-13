using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class SkillGroup
    {
        public int SkillGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
