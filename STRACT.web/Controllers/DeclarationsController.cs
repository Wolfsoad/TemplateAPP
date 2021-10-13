using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Entities.Declaration;
using STRACT.Data.Identity;
using System.Security.Claims;
using STRACT.Data;

namespace STRACT.web.Controllers
{
    public class DeclarationsController : Controller
    {
        private readonly PDCContext _context;

        public DeclarationsController(PDCContext context)
        {
            _context = context;
        }

        // GET: Declarations
        [Authorize(Policy = "Permissions.Declarations.View")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Declarations.ToListAsync());
        }

        // GET: Declarations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declaration = await _context.Declarations
                .FirstOrDefaultAsync(m => m.DeclarationItemId == id);
            if (declaration == null)
            {
                return NotFound();
            }

            return View(declaration);
        }

        [Authorize(Policy = "Permissions.Declarations.Create")]
        // GET: Declarations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Declarations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Motive,DateCreated,IdResponsible")] DeclarationItem declaration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(declaration);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            return View(declaration);
        }

        // GET: Declarations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declaration = await _context.Declarations.FindAsync(id);
            if (declaration == null)
            {
                return NotFound();
            }
            return View(declaration);
        }

        // POST: Declarations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permissions.Declarations.Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Motive,DateCreated,IdResponsible")] DeclarationItem declaration)
        {
            if (id != declaration.DeclarationItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(declaration);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeclarationExists(declaration.DeclarationItemId))
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
            return View(declaration);
        }

        // GET: Declarations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declaration = await _context.Declarations
                .FirstOrDefaultAsync(m => m.DeclarationItemId == id);
            if (declaration == null)
            {
                return NotFound();
            }

            return View(declaration);
        }

        // POST: Declarations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permissions.Declarations.Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var declaration = await _context.Declarations.FindAsync(id);
            _context.Declarations.Remove(declaration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeclarationExists(int id)
        {
            return _context.Declarations.Any(e => e.DeclarationItemId == id);
        }
    }
}
