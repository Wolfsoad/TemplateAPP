using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.Projects;

namespace STRACT.web.Controllers.Projects
{
    public class ProjectItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectItems
                .Include(p => p.Coordinator)
                    .ThenInclude(u => u.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectItem = await _context.ProjectItems
                .Include(p => p.Coordinator)
                    .ThenInclude(u => u.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProjectItemId == id);
            if (projectItem == null)
            {
                return NotFound();
            }

            return View(projectItem);
        }

        // GET: ProjectItems/Create
        public IActionResult Create()
        {
            PopulateUserInTeamDropDownList();
            return View();
        }

        // POST: ProjectItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectItemId,Title,Description,DetailOfProblem,MappedBenefits,ExpectedResults,ConceptsDeveloped,MainConclusions,FolderPath,UserId")] ProjectItem projectItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateUserInTeamDropDownList(projectItem.UserId);
            return View(projectItem);
        }

        // GET: ProjectItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectItem = await _context.ProjectItems.
                Include(p => p.Coordinator)
                    .ThenInclude(u => u.ApplicationUser)
                .FirstOrDefaultAsync(p => p.ProjectItemId == id);
            if (projectItem == null)
            {
                return NotFound();
            }
            PopulateUserInTeamDropDownList(projectItem.UserId);
            return View(projectItem);
        }

        // POST: ProjectItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectItemId,Title,Description,DetailOfProblem,MappedBenefits,ExpectedResults,ConceptsDeveloped,MainConclusions,FolderPath,UserId")] ProjectItem projectItem)
        {
            if (id != projectItem.ProjectItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectItemExists(projectItem.ProjectItemId))
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
            PopulateUserInTeamDropDownList(projectItem.UserId);
            return View(projectItem);
        }

        // GET: ProjectItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectItem = await _context.ProjectItems.
                Include(p => p.Coordinator)
                    .ThenInclude(u => u.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProjectItemId == id);
            if (projectItem == null)
            {
                return NotFound();
            }

            return View(projectItem);
        }

        // POST: ProjectItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectItem = await _context.ProjectItems.
                Include(p => p.Coordinator)
                    .ThenInclude(u => u.ApplicationUser)
                .FirstOrDefaultAsync(p => p.ProjectItemId == id);
            _context.ProjectItems.Remove(projectItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectItemExists(int id)
        {
            return _context.ProjectItems.Any(e => e.ProjectItemId == id);
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
    }
}
