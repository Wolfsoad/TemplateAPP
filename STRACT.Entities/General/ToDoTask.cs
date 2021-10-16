using STRACT.Entities.Projects;
using STRACT.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.General
{
    public class ToDoTask
    {
        public int ToDoTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsConcluded { get; set; }
        public bool IsPublic { get; set; }
        public int ActionItemId { get; set; }
        public ActionItem ActionItem { get; set; }
        public int UserInTeamId { get; set; }
        public UserInTeam User { get; set; }
    }
}
