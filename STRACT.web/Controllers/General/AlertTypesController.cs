using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data;
using STRACT.Data.Identity;
using STRACT.Entities.General;

namespace STRACT.web.Controllers.General
{
    [Authorize(Policy = "Permissions.AlertTypes.View")]
    public class AlertTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlertTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlertTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlertTypes.ToListAsync());
        }

        // GET: AlertTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertType = await _context.AlertTypes
                .FirstOrDefaultAsync(m => m.AlertTypeId == id);
            if (alertType == null)
            {
                return NotFound();
            }

            return View(alertType);
        }

        // GET: AlertTypes/Create
        [Authorize(Policy = "Permissions.AlertTypes.Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlertTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlertTypeId,Description,Color")] AlertType alertType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alertType);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            return View(alertType);
        }

        // GET: AlertTypes/Edit/5
        [Authorize(Policy = "Permissions.AlertTypes.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertType = await _context.AlertTypes.FindAsync(id);
            if (alertType == null)
            {
                return NotFound();
            }
            return View(alertType);
        }

        // POST: AlertTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlertTypeId,Description,Color")] AlertType alertType)
        {
            if (id != alertType.AlertTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old = await _context.AlertTypes.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(alertType);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertTypeExists(alertType.AlertTypeId))
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
            return View(alertType);
        }

        // GET: AlertTypes/Delete/5
        [Authorize(Policy = "Permissions.AlertTypes.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertType = await _context.AlertTypes
                .FirstOrDefaultAsync(m => m.AlertTypeId == id);
            if (alertType == null)
            {
                return NotFound();
            }

            return View(alertType);
        }

        // POST: AlertTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alertType = await _context.AlertTypes.FindAsync(id);
            _context.AlertTypes.Remove(alertType);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool AlertTypeExists(int id)
        {
            return _context.AlertTypes.Any(e => e.AlertTypeId == id);
        }
    }
}
