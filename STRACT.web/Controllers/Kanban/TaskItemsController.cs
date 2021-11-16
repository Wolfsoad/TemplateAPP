using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.Kanban;

namespace STRACT.web.Controllers.Kanban
{
    public class TaskItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaskItems
                .Include(t => t.Audit)
                .Include(t => t.Priority)
                .Include(t => t.RequestedBy)
                .Include(t => t.TaskType)
                .Include(t => t.UserResponsible)
                .Include(t => t.OrganizationalRole);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaskItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItems
                .Include(t => t.Audit)
                .Include(t => t.Priority)
                .Include(t => t.RequestedBy)
                .Include(t => t.TaskType)
                .Include(t => t.UserResponsible)
                .Include(t => t.OrganizationalRole)
                .FirstOrDefaultAsync(m => m.TaskItemId == id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // GET: TaskItems/Create
        public IActionResult Create()
        {
            PopulateAuditsDropDownList();
            PopulatePrioritiesDropDownList();
            PopulateDepartmentsDownList();
            PopulateTaskTypesDownList();
            PopulateUserInTeamDropDownList();
            PopulateOrganizationalRolesDropDownList();
            return View();
        }

        // POST: TaskItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskItemId,FeatureActivity,Reason,Details,Points,Hours,IsRepeatable,UserInTeamId,OrganizationRoleId,TaskTypeId,AuditId,PriorityId,DepartmentId")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateAuditsDropDownList(taskItem.AuditId);
            PopulatePrioritiesDropDownList(taskItem.PriorityId);
            PopulateDepartmentsDownList(taskItem.DepartmentId);
            PopulateTaskTypesDownList(taskItem.TaskTypeId);
            PopulateUserInTeamDropDownList(taskItem.UserInTeamId);
            PopulateOrganizationalRolesDropDownList(taskItem.OrganizationRoleId);
            return View(taskItem);
        }

        // GET: TaskItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            PopulateAuditsDropDownList(taskItem.AuditId);
            PopulatePrioritiesDropDownList(taskItem.PriorityId);
            PopulateDepartmentsDownList(taskItem.DepartmentId);
            PopulateTaskTypesDownList(taskItem.TaskTypeId);
            PopulateUserInTeamDropDownList(taskItem.UserInTeamId);
            PopulateOrganizationalRolesDropDownList(taskItem.OrganizationRoleId);
            return View(taskItem);
        }

        // POST: TaskItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskItemId,FeatureActivity,Reason,Details,Points,Hours,IsRepeatable,UserInTeamId,OrganizationRoleId,TaskTypeId,AuditId,PriorityId,DepartmentId")] TaskItem taskItem)
        {
            if (id != taskItem.TaskItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskItemExists(taskItem.TaskItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateAuditsDropDownList(taskItem.AuditId);
            PopulatePrioritiesDropDownList(taskItem.PriorityId);
            PopulateDepartmentsDownList(taskItem.DepartmentId);
            PopulateTaskTypesDownList(taskItem.TaskTypeId);
            PopulateUserInTeamDropDownList(taskItem.UserInTeamId);
            PopulateOrganizationalRolesDropDownList(taskItem.OrganizationRoleId);
            return View(taskItem);
        }

        // GET: TaskItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItems
                .Include(t => t.Audit)
                .Include(t => t.Priority)
                .Include(t => t.RequestedBy)
                .Include(t => t.TaskType)
                .Include(t => t.UserResponsible)
                .Include(t => t.OrganizationalRole)
                .FirstOrDefaultAsync(m => m.TaskItemId == id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // POST: TaskItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskItemExists(int id)
        {
            return _context.TaskItems.Any(e => e.TaskItemId == id);
        }

        private void PopulateAuditsDropDownList(object selectedAudit = null)
        {
            var query = from sg in _context.Audits
                            .Include(a => a.CertificationLine)
                            .Include(a => a.Location)
                        orderby sg.Year descending
                        select new
                        {
                            AuditId = sg.AuditId,
                            Description = string.Format("{0} ({1}/{2})", sg.CertificationLine.Description, sg.Location.Name, sg.Year)
                        };
            ViewBag.AuditId = new SelectList(query.AsTracking(), "AuditId", "Description", selectedAudit);
        }

        private void PopulatePrioritiesDropDownList(object selectedPriority = null)
        {
            var query = from sg in _context.Priority
                        orderby sg.PriorityId
                        select new
                        {
                            PriorityId = sg.PriorityId,
                            Description = string.Format("{0}", sg.Description)
                        };
            ViewBag.PriorityId = new SelectList(query.AsTracking(), "PriorityId", "Description", selectedPriority);
        }

        private void PopulateDepartmentsDownList(object selectedDepartment = null)
        {
            var query = from sg in _context.Departments
                        orderby sg.Name
                        select new
                        {
                            DepartmentId = sg.DepartmentId,
                            Description = string.Format("{0}", sg.Name)
                        };
            ViewBag.DepartmentId = new SelectList(query.AsTracking(), "DepartmentId", "Description", selectedDepartment);
        }

        private void PopulateTaskTypesDownList(object selectedTaskType = null)
        {
            var query = from sg in _context.TaskTypes
                        orderby sg.Description
                        select new
                        {
                            TaskTypeId = sg.TaskTypeId,
                            Description = string.Format("{0}", sg.Description)
                        };
            ViewBag.TaskTypeId = new SelectList(query.AsTracking(), "TaskTypeId", "Description", selectedTaskType);
        }

        private void PopulateUserInTeamDropDownList(object selectedUserInTeam = null)
        {
            var userInTeamQuery = from sg in _context.UserInTeam
                                  where sg.Active
                                  orderby sg.ApplicationUser.UserName
                                  select new
                                  {
                                      UserInTeamId = sg.UserInTeamId,
                                      Description = string.Format("{0} | {1}", sg.ApplicationUser.UserName, sg.ApplicationUser.Email)
                                  };

            ViewBag.UserInTeamId = new SelectList(userInTeamQuery.AsTracking(), "UserInTeamId", "Description", selectedUserInTeam);
        }

        private void PopulateOrganizationalRolesDropDownList(object selectedOrganizationRole = null)
        {
            var query = from sg in _context.OrganizationalRoles
                                  orderby sg.Name
                                  select new
                                  {
                                      OrganizationRoleId = sg.OrganizationalRoleId,
                                      Description = string.Format("{0}", sg.Description)
                                  };

            ViewBag.OrganizationRoleId = new SelectList(query.AsTracking(), "OrganizationRoleId", "Description", selectedOrganizationRole);
        }
    }
}
