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
    [Authorize(Policy = "Permissions.OrganizationalRoles.View")]
    public class OrganizationalRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizationalRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizationalRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrganizationalRoles.ToListAsync());
        }

        // GET: OrganizationalRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationalRole = await _context.OrganizationalRoles
                .FirstOrDefaultAsync(m => m.OrganizationalRoleId == id);
            if (organizationalRole == null)
            {
                return NotFound();
            }

            return View(organizationalRole);
        }

        // GET: OrganizationalRoles/Create
        [Authorize(Policy = "Permissions.OrganizationalRoles.Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizationalRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizationalRoleId,Name,Description")] OrganizationalRole organizationalRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizationalRole);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            return View(organizationalRole);
        }

        // GET: OrganizationalRoles/Edit/5
        [Authorize(Policy = "Permissions.OrganizationalRoles.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationalRole = await _context.OrganizationalRoles.FindAsync(id);
            if (organizationalRole == null)
            {
                return NotFound();
            }
            return View(organizationalRole);
        }

        // POST: OrganizationalRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizationalRoleId,Name,Description")] OrganizationalRole organizationalRole)
        {
            if (id != organizationalRole.OrganizationalRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old = await _context.OrganizationalRoles.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(organizationalRole);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationalRoleExists(organizationalRole.OrganizationalRoleId))
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
            return View(organizationalRole);
        }

        // GET: OrganizationalRoles/Delete/5
        [Authorize(Policy = "Permissions.OrganizationalRoles.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationalRole = await _context.OrganizationalRoles
                .FirstOrDefaultAsync(m => m.OrganizationalRoleId == id);
            if (organizationalRole == null)
            {
                return NotFound();
            }

            return View(organizationalRole);
        }

        // POST: OrganizationalRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizationalRole = await _context.OrganizationalRoles.FindAsync(id);
            _context.OrganizationalRoles.Remove(organizationalRole);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationalRoleExists(int id)
        {
            return _context.OrganizationalRoles.Any(e => e.OrganizationalRoleId == id);
        }
    }
}
