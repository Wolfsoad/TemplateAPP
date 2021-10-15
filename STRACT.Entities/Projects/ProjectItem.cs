using STRACT.Entities.Users;
using STRACT.Entities.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STRACT.Entities.Chronogram;
using STRACT.Entities.General;
using STRACT.Common;

namespace STRACT.Entities.Projects
{
    public class ProjectItem
    {
        public int ProjectItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DetailOfProblem { get; set; }
        public string MappedBenefits { get; set; }
        public string ExpectedResults { get; set; }
        public string ConceptsDeveloped { get; set; }
        public string MainConclusions { get; set; }
        public string FolderPath { get; set; }
        public int UserId { get; set; }
        public UserInTeam Coordinator { get; set; }
        public ICollection<ActionItem> ActionItems { get; set; }
        public ICollection<AlertInProject> Alerts { get; set; }
        public ICollection<TopicInProject> Topics { get; set; }
        public ICollection<ProjectMember> ProjectMembers { get; set; }
        public ICollection<ChronogramRevision> Chronograms { get; set; }
        public ICollection<ToDoTask> toDoTasks { get; set; }
        public KanbanBoard KanbanBoard { get; set; }
        //Public Methods
        public double GetActionCompletionPercentage()
        {
            if (Chronograms.Count != 0)
            {
                return Chronograms.Where(c => c.IsMain).FirstOrDefault().AverageCompletion;
            }
            else
            {
                throw new Exception(string.Format(Messages.NoItemsFoundException,Chronograms.ToString()));
            }
        }

    }
}
