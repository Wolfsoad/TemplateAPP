using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.HumanResources;

namespace STRACT.web.Controllers.HumanResources
{
    [Authorize(Policy = "Permissions.FunctionalRoles.View")]
    public class FunctionalRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FunctionalRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FunctionalRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.FunctionalRoles.ToListAsync());
        }

        // GET: FunctionalRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionalRole = await _context.FunctionalRoles
                .FirstOrDefaultAsync(m => m.FunctionalRoleId == id);
            if (functionalRole == null)
            {
                return NotFound();
            }

            return View(functionalRole);
        }

        // GET: FunctionalRoles/Create
        [Authorize(Policy = "Permissions.FunctionalRoles.Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FunctionalRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FunctionalRoleId,Name,Description")] FunctionalRole functionalRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(functionalRole);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            return View(functionalRole);
        }

        // GET: FunctionalRoles/Edit/5
        [Authorize(Policy = "Permissions.FunctionalRoles.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionalRole = await _context.FunctionalRoles.FindAsync(id);
            if (functionalRole == null)
            {
                return NotFound();
            }
            return View(functionalRole);
        }

        // POST: FunctionalRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FunctionalRoleId,Name,Description")] FunctionalRole functionalRole)
        {
            if (id != functionalRole.FunctionalRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old = await _context.FunctionalRoles.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(functionalRole);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunctionalRoleExists(functionalRole.FunctionalRoleId))
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
            return View(functionalRole);
        }

        // GET: FunctionalRoles/Delete/5
        [Authorize(Policy = "Permissions.FunctionalRoles.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionalRole = await _context.FunctionalRoles
                .FirstOrDefaultAsync(m => m.FunctionalRoleId == id);
            if (functionalRole == null)
            {
                return NotFound();
            }

            return View(functionalRole);
        }

        // POST: FunctionalRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var functionalRole = await _context.FunctionalRoles.FindAsync(id);
            _context.FunctionalRoles.Remove(functionalRole);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool FunctionalRoleExists(int id)
        {
            return _context.FunctionalRoles.Any(e => e.FunctionalRoleId == id);
        }
    }
}
