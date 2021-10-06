﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class SkillInActivity
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int RequestedScore { get; set; }

    }
}
