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
using STRACT.Entities.Financial;

namespace STRACT.web.Controllers.Financial
{
    [Authorize(Policy = "Permissions.FinancialLineSubTypes.View")]
    public class FinancialLineSubTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FinancialLineSubTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FinancialLineSubTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FinancialLineSubTypes.ToListAsync());
        }

        // GET: FinancialLineSubTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialLineSubType = await _context.FinancialLineSubTypes
                .FirstOrDefaultAsync(m => m.FinancialLineSubTypeId == id);
            if (financialLineSubType == null)
            {
                return NotFound();
            }

            return View(financialLineSubType);
        }

        // GET: FinancialLineSubTypes/Create
        [Authorize(Policy = "Permissions.FinancialLineSubTypes.Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinancialLineSubTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinancialLineSubTypeId,Description")] FinancialLineSubType financialLineSubType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financialLineSubType);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            return View(financialLineSubType);
        }

        // GET: FinancialLineSubTypes/Edit/5
        [Authorize(Policy = "Permissions.FinancialLineSubTypes.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialLineSubType = await _context.FinancialLineSubTypes.FindAsync(id);
            if (financialLineSubType == null)
            {
                return NotFound();
            }
            return View(financialLineSubType);
        }

        // POST: FinancialLineSubTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinancialLineSubTypeId,Description")] FinancialLineSubType financialLineSubType)
        {
            if (id != financialLineSubType.FinancialLineSubTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old = await _context.FinancialLineSubTypes.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(financialLineSubType);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinancialLineSubTypeExists(financialLineSubType.FinancialLineSubTypeId))
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
            return View(financialLineSubType);
        }

        // GET: FinancialLineSubTypes/Delete/5
        [Authorize(Policy = "Permissions.FinancialLineSubTypes.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialLineSubType = await _context.FinancialLineSubTypes
                .FirstOrDefaultAsync(m => m.FinancialLineSubTypeId == id);
            if (financialLineSubType == null)
            {
                return NotFound();
            }

            return View(financialLineSubType);
        }

        // POST: FinancialLineSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var financialLineSubType = await _context.FinancialLineSubTypes.FindAsync(id);
            _context.FinancialLineSubTypes.Remove(financialLineSubType);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool FinancialLineSubTypeExists(int id)
        {
            return _context.FinancialLineSubTypes.Any(e => e.FinancialLineSubTypeId == id);
        }
    }
}
