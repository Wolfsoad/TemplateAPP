using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STRACT.Data.Identity;
using STRACT.Entities.Enums;
using STRACT.Entities.Kanban;

namespace STRACT.Data
{
    public class PDCContextSeed
    {
        public static async Task SeedDatabase(ApplicationDbContext context)
        {
            await SeedKanbanPriorityAsync(context);
            await SeedKanbanTaskTypesAsync(context);
        }
        public static async Task SeedKanbanPriorityAsync(ApplicationDbContext context)
        {
            //Seed Roles
            if (!context.Priority.Any())
            {
                var priorities = new List<Priority>
                {
                    new Priority { Description = Enums.Priorities.High.ToString(), Color="D62828" },
                    new Priority { Description = Enums.Priorities.Medium.ToString(), Color="F77F00" },
                    new Priority { Description = Enums.Priorities.Low.ToString(), Color="EAE2B7" },
                };

                await context.AddRangeAsync(priorities);
                await context.SaveChangesAsync();
            }
            
        }
        public static async Task SeedKanbanTaskTypesAsync(ApplicationDbContext context)
        {
            //Seed Roles
            if (!context.TaskTypes.Any())
            {
                var tasktypes = new List<TaskType>
                {
                    new TaskType { Description = Enums.TaskTypes.Content.ToString(), Color="00587a" },
                    new TaskType { Description = Enums.TaskTypes.Update.ToString(), Color="00C7B0" },
                    new TaskType { Description = Enums.TaskTypes.Feature.ToString(), Color="FFCE52" },
                    new TaskType { Description = Enums.TaskTypes.Task.ToString(), Color="FFA257" },
                    new TaskType { Description = Enums.TaskTypes.Research.ToString(), Color="FF6038" },
                };

                await context.AddRangeAsync(tasktypes);
                await context.SaveChangesAsync();
            }

        }
        public static async Task SeedKanbanLocationsAsync(ApplicationDbContext context)
        {
            //Seed Roles
            if (!context.LocationInKanbans.Any())
            {
                var locations = new List<LocationInKanban>
                {
                    //new LocationInKanban { Description = Enums.TaskTypes.Content.ToString(), Color="00587a" },
                    //new LocationInKanban { Description = Enums.TaskTypes.Update.ToString(), Color="00C7B0" },
                    //new LocationInKanban { Description = Enums.TaskTypes.Feature.ToString(), Color="FFCE52" },
                    //new LocationInKanban { Description = Enums.TaskTypes.Task.ToString(), Color="FFA257" },
                    //new LocationInKanban { Description = Enums.TaskTypes.Research.ToString(), Color="FF6038" },
                };

                await context.AddRangeAsync(locations);
                await context.SaveChangesAsync();
            }

        }
    }
}
