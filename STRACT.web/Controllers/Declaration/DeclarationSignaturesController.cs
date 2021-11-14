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
    [Authorize(Policy = "Permissions.DeclarationSignatures.View")]
    public class DeclarationSignaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeclarationSignaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeclarationSignatures
        public async Task<IActionResult> Index(int selectedDeclarationId)
        {
            var applicationDbContext = _context.DeclarationSignatures
                .Include(d => d.Declaration)
                .Include(d => d.User)
                    .ThenInclude(u => u.ApplicationUser)
                .Where(m => m.DeclarationItemId == selectedDeclarationId);
            ViewBag.SelectedDeclaration = selectedDeclarationId;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeclarationSignatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationSignature = await _context.DeclarationSignatures
                .Include(d => d.Declaration)
                .Include(d => d.User)
                    .ThenInclude(u => u.ApplicationUser)
                .FirstOrDefaultAsync(m => m.SignatureId == id);
            if (declarationSignature == null)
            {
                return NotFound();
            }
            ViewBag.SelectedDeclaration = declarationSignature.DeclarationItemId;

            return View(declarationSignature);
        }

        // GET: DeclarationSignatures/Create
        [Authorize(Policy = "Permissions.DeclarationSignatures.Create")]
        public IActionResult Create(int selectedDeclarationId)
        {
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId", _context.Declarations.FirstOrDefault(m => m.DeclarationItemId == selectedDeclarationId).DeclarationItemId);
            PopulateUserInTeamDropDownList();
            return View();
        }

        // POST: DeclarationSignatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SignatureId,DateSigned,DeclarationItemId,UserId")] DeclarationSignature declarationSignature, int selectedDeclarationId, int selectedUser)
        {
            if (ModelState.IsValid)
            {
                if (selectedDeclarationId != 0) { declarationSignature.DeclarationItemId = selectedDeclarationId; }
                if (selectedUser != 0) { declarationSignature.UserId = selectedUser; }
                _context.Add(declarationSignature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { selectedDeclarationId = declarationSignature.DeclarationItemId });
            }
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId", declarationSignature.DeclarationItemId);
            PopulateUserInTeamDropDownList(declarationSignature.UserId);
            ViewBag.SelectedDeclaration = selectedDeclarationId;
            return View(declarationSignature);
        }

        // GET: DeclarationSignatures/Edit/5
        [Authorize(Policy = "Permissions.DeclarationSignatures.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationSignature = await _context.DeclarationSignatures.FindAsync(id);
            if (declarationSignature == null)
            {
                return NotFound();
            }
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId", declarationSignature.DeclarationItemId);
            PopulateUserInTeamDropDownList(declarationSignature.UserId);
            ViewBag.SelectedDeclaration = declarationSignature.DeclarationItemId;
            return View(declarationSignature);
        }

        // POST: DeclarationSignatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("SignatureId,DateSigned,DeclarationItemId,UserId")] DeclarationSignature declarationSignature)
        {
            if (id != declarationSignature.DeclarationItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(declarationSignature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeclarationSignatureExists(declarationSignature.DeclarationItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { selectedDeclarationId = declarationSignature.DeclarationItemId});
            }
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId", declarationSignature.DeclarationItemId);
            PopulateUserInTeamDropDownList(declarationSignature.UserId);
            return View(declarationSignature);
        }

        // GET: DeclarationSignatures/Delete/5
        [Authorize(Policy = "Permissions.DeclarationSignatures.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationSignature = await _context.DeclarationSignatures
                .Include(d => d.Declaration)
                .Include(d => d.User)
                    .ThenInclude(u => u.ApplicationUser)
                .FirstOrDefaultAsync(m => m.SignatureId == id);
            if (declarationSignature == null)
            {
                return NotFound();
            }
            ViewBag.SelectedDeclaration = declarationSignature.DeclarationItemId;
            return View(declarationSignature);
        }

        // POST: DeclarationSignatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var declarationSignature = await _context.DeclarationSignatures.FindAsync(id);
            _context.DeclarationSignatures.Remove(declarationSignature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { selectedDeclarationId = declarationSignature.DeclarationItemId });
        }

        private bool DeclarationSignatureExists(int? id)
        {
            return _context.DeclarationSignatures.Any(e => e.DeclarationItemId == id);
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
