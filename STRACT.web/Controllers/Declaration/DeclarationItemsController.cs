using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.Declaration;
using STRACT.Identity.Entities;

namespace STRACT.web.Controllers.Declaration
{
    [Authorize(Policy = "Permissions.DeclarationItems.View")]
    public class DeclarationItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeclarationItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: DeclarationItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Declarations
                .Include(d => d.User)
                    .ThenInclude(a => a.ApplicationUser)
                .Include(d => d.Revisions)
                .Include(d => d.Signatures);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeclarationItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationItem = await _context.Declarations
                .Include(d => d.User)
                    .ThenInclude(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.DeclarationItemId == id);
            if (declarationItem == null)
            {
                return NotFound();
            }

            return View(declarationItem);
        }

        // GET: DeclarationItems/Create
        [Authorize(Policy = "Permissions.DeclarationItems.Create")]
        public IActionResult Create()
        {
            PopulateUserInTeamDropDownList();
            return View();
        }

        // POST: DeclarationItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeclarationItemId,Title,Motive,DateCreated,UserId")] DeclarationItem declarationItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(declarationItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateUserInTeamDropDownList(declarationItem.UserId);
            return View(declarationItem);
        }

        // GET: DeclarationItems/Edit/5
        [Authorize(Policy = "Permissions.DeclarationItems.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationItem = await _context.Declarations.FindAsync(id);
            if (declarationItem == null)
            {
                return NotFound();
            }
            PopulateUserInTeamDropDownList(declarationItem.UserId);
            return View(declarationItem);
        }

        // POST: DeclarationItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeclarationItemId,Title,Motive,DateCreated,UserId")] DeclarationItem declarationItem)
        {
            if (id != declarationItem.DeclarationItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(declarationItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeclarationItemExists(declarationItem.DeclarationItemId))
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
            PopulateUserInTeamDropDownList(declarationItem.UserId);
            return View(declarationItem);
        }

        // GET: DeclarationItems/Delete/5
        [Authorize(Policy = "Permissions.DeclarationItems.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationItem = await _context.Declarations
                .Include(d => d.User)
                    .ThenInclude(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.DeclarationItemId == id);
            if (declarationItem == null)
            {
                return NotFound();
            }

            return View(declarationItem);
        }

        // POST: DeclarationItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var declarationItem = await _context.Declarations.FindAsync(id);
            _context.Declarations.Remove(declarationItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeclarationItemExists(int id)
        {
            return _context.Declarations.Any(e => e.DeclarationItemId == id);
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
