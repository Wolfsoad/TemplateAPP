using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.Enums;
using STRACT.Entities.Kanban;
using STRACT.Entities.HumanResources;

namespace STRACT.Data
{
    public class PDCContextSeed
    {
        public static async Task SeedDatabase(ApplicationDbContext context)
        {
            await SeedKanbanPriorityAsync(context);
            await SeedKanbanTaskTypesAsync(context);
            await SeedActivityGroupsAsync(context);
        }
        public static async Task SeedKanbanPriorityAsync(ApplicationDbContext context)
        {
            //Seed Roles
            if (!context.Priority.Any())
            {
                var priorities = new List<Priority>
                {
                    new Priority { Description = Enums.Priorities.High.ToString(), Color="#D62828" },
                    new Priority { Description = Enums.Priorities.Medium.ToString(), Color="#F77F00" },
                    new Priority { Description = Enums.Priorities.Low.ToString(), Color="#EAE2B7" },
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
                    new TaskType { Description = Enums.TaskTypes.Content.ToString(), Color="#00587a" },
                    new TaskType { Description = Enums.TaskTypes.Update.ToString(), Color="#00C7B0" },
                    new TaskType { Description = Enums.TaskTypes.Feature.ToString(), Color="#FFCE52" },
                    new TaskType { Description = Enums.TaskTypes.Task.ToString(), Color="#FFA257" },
                    new TaskType { Description = Enums.TaskTypes.Research.ToString(), Color="#FF6038" },
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

        public static async Task SeedActivityGroupsAsync(ApplicationDbContext context)
        {
            //Seed Roles
            if (!context.ActivityGroups.Any())
            {
                var activityGroups = new List<ActivityGroup>
                {
                    new ActivityGroup { Name = "Gestão de Certificações", Description = ""},
                    new ActivityGroup { Name = "Gestão de Projetos", Description = ""},
                    new ActivityGroup { Name = "Desenvolvimento de Linhas", Description = ""},
                    new ActivityGroup { Name = "Desenvolvimento de Componentes", Description = ""},
                    new ActivityGroup { Name = "Desenvolvimento de Aplicações", Description = "" }

                };

                await context.AddRangeAsync(activityGroups);
                await context.SaveChangesAsync();

            }
            if (!context.Activities.Any())
            {
                var activities = new List<Activity>
                    {
                        new Activity { Name = "Contactar organismo", Description = ""},
                        new Activity { Name = "Preparar dossier certificação", Description = ""},
                        new Activity { Name = "Desenhar componente em 3D", Description = ""},
                        new Activity { Name = "Desenhar componente em 2D", Description = ""},
                        new Activity { Name = "Programar orientado a objetos", Description = "" }

                    };

                await context.AddRangeAsync(activities);
                await context.SaveChangesAsync();
            }
            if (!context.ActivityInGroups.Any())
            {
                var activityInGroup = new List<ActivityInGroup>
                    {
                        new ActivityInGroup { ActivityId = 1, ActivityGroupId = 1},
                        new ActivityInGroup { ActivityId = 2, ActivityGroupId = 1},
                        new ActivityInGroup { ActivityId = 3, ActivityGroupId = 3},
                        new ActivityInGroup { ActivityId = 3, ActivityGroupId = 4},
                        new ActivityInGroup { ActivityId = 4, ActivityGroupId = 3},
                        new ActivityInGroup { ActivityId = 4, ActivityGroupId = 4},
                        new ActivityInGroup { ActivityId = 5, ActivityGroupId = 5}

                    };

                await context.AddRangeAsync(activityInGroup);
                await context.SaveChangesAsync();
            }

        }
    }
}
