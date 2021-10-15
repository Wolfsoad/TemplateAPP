using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Enums
{
    public class Enums
    {
        public enum Priorities
        {
            High,
            Medium,
            Low
        }

        public enum TaskTypes
        {
            Task,
            Update,
            Research,
            Content,
            Feature
        }
        public enum LocationInKanbans
        {
            Backlog,
            ToDoThisSprint,
            InProgress,
            TestVerify,
            Done,
            ProjectItemsConcluded
        }
    }
}
