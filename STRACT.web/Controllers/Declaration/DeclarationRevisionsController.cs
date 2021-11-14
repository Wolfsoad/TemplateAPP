using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.Declaration;

namespace STRACT.web.Controllers.Declaration
{
    [Authorize(Policy = "Permissions.DeclarationRevisions.View")]
    public class DeclarationRevisionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeclarationRevisionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeclarationRevisions
        public async Task<IActionResult> Index(int selectedDeclarationId)
        {
            var applicationDbContext = _context.DeclarationRevisions
                .Include(d => d.DeclarationItem)
                .Include(d => d.User)
                    .ThenInclude(u => u.ApplicationUser)
                .Where(m => m.DeclarationItemId == selectedDeclarationId)
                .OrderByDescending(m => m.RevisionDate);
            ViewBag.SelectedDeclaration = selectedDeclarationId;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeclarationRevisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationRevision = await _context.DeclarationRevisions
                .Include(d => d.DeclarationItem)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DeclarationRevisionId == id);
            if (declarationRevision == null)
            {
                return NotFound();
            }
            ViewBag.SelectedDeclaration = declarationRevision.DeclarationItemId;

            return View(declarationRevision);
        }

        // GET: DeclarationRevisions/Create
        [Authorize(Policy = "Permissions.DeclarationRevisions.Create")]
        public IActionResult Create(int selectedDeclarationId)
        {
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId",_context.Declarations.FirstOrDefault(m => m.DeclarationItemId == selectedDeclarationId).DeclarationItemId);
            PopulateUserInTeamDropDownList();
            ViewBag.SelectedDeclaration = selectedDeclarationId;
            return View();
        }

        // POST: DeclarationRevisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeclarationRevisionId,RevisionDescription,RevisionDate,UserId,DeclarationItemId")] DeclarationRevision declarationRevision, int selectedDeclarationId, int selectedUser)
        {
            if (ModelState.IsValid)
            {
                if (selectedDeclarationId != 0) { declarationRevision.DeclarationItemId = selectedDeclarationId; }
                if (selectedUser != 0) { declarationRevision.UserId = selectedUser; }
                _context.Add(declarationRevision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),new { selectedDeclarationId });
            }
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId", declarationRevision.DeclarationItemId);
            PopulateUserInTeamDropDownList(declarationRevision.UserId);
            ViewBag.SelectedDeclaration = selectedDeclarationId;
            return View(declarationRevision);
        }

        // GET: DeclarationRevisions/Edit/5
        [Authorize(Policy = "Permissions.DeclarationRevisions.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationRevision = await _context.DeclarationRevisions.FindAsync(id);
            if (declarationRevision == null)
            {
                return NotFound();
            }
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId", declarationRevision.DeclarationItemId);
            PopulateUserInTeamDropDownList(declarationRevision.UserId);
            ViewBag.SelectedDeclaration = declarationRevision.DeclarationItemId;
            return View(declarationRevision);
        }

        // POST: DeclarationRevisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeclarationRevisionId,RevisionDescription,RevisionDate,UserId,DeclarationItemId")] DeclarationRevision declarationRevision)
        {
            if (id != declarationRevision.DeclarationRevisionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(declarationRevision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeclarationRevisionExists(declarationRevision.DeclarationRevisionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { selectedDeclarationId = declarationRevision.DeclarationItemId });
            }
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId", declarationRevision.DeclarationItemId);
            PopulateUserInTeamDropDownList(declarationRevision.UserId);
            return View(declarationRevision);
        }

        // GET: DeclarationRevisions/Delete/5
        [Authorize(Policy = "Permissions.DeclarationRevisions.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationRevision = await _context.DeclarationRevisions
                .Include(d => d.DeclarationItem)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DeclarationRevisionId == id);
            if (declarationRevision == null)
            {
                return NotFound();
            }
            ViewBag.SelectedDeclaration = declarationRevision.DeclarationItemId;
            return View(declarationRevision);
        }

        // POST: DeclarationRevisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var declarationRevision = await _context.DeclarationRevisions.FindAsync(id);
            _context.DeclarationRevisions.Remove(declarationRevision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { selectedDeclarationId = declarationRevision.DeclarationItemId });
        }

        private bool DeclarationRevisionExists(int id)
        {
            return _context.DeclarationRevisions.Any(e => e.DeclarationRevisionId == id);
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
