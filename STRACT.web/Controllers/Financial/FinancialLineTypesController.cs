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
    [Authorize(Policy = "Permissions.FinancialLineTypes.View")]
    public class FinancialLineTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FinancialLineTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FinancialLineTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FinancialLineTypes.ToListAsync());
        }

        // GET: FinancialLineTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialLineType = await _context.FinancialLineTypes
                .FirstOrDefaultAsync(m => m.FinancialLineTypeId == id);
            if (financialLineType == null)
            {
                return NotFound();
            }

            return View(financialLineType);
        }

        // GET: FinancialLineTypes/Create
        [Authorize(Policy = "Permissions.FinancialLineTypes.Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinancialLineTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinancialLineTypeId,Description")] FinancialLineType financialLineType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financialLineType);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            return View(financialLineType);
        }

        // GET: FinancialLineTypes/Edit/5
        [Authorize(Policy = "Permissions.FinancialLineTypes.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialLineType = await _context.FinancialLineTypes.FindAsync(id);
            if (financialLineType == null)
            {
                return NotFound();
            }
            return View(financialLineType);
        }

        // POST: FinancialLineTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinancialLineTypeId,Description")] FinancialLineType financialLineType)
        {
            if (id != financialLineType.FinancialLineTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old = await _context.FinancialLineTypes.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(financialLineType);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinancialLineTypeExists(financialLineType.FinancialLineTypeId))
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
            return View(financialLineType);
        }

        // GET: FinancialLineTypes/Delete/5
        [Authorize(Policy = "Permissions.FinancialLineTypes.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialLineType = await _context.FinancialLineTypes
                .FirstOrDefaultAsync(m => m.FinancialLineTypeId == id);
            if (financialLineType == null)
            {
                return NotFound();
            }

            return View(financialLineType);
        }

        // POST: FinancialLineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var financialLineType = await _context.FinancialLineTypes.FindAsync(id);
            _context.FinancialLineTypes.Remove(financialLineType);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool FinancialLineTypeExists(int id)
        {
            return _context.FinancialLineTypes.Any(e => e.FinancialLineTypeId == id);
        }
    }
}
