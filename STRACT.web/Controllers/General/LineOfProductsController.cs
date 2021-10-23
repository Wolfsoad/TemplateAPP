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
using STRACT.Entities.General;

namespace STRACT.web.Controllers.General
{
    [Authorize(Policy = "Permissions.LineOfProducts.View")]
    public class LineOfProductsController : Controller
    {
        private readonly PDCContext _context;

        public LineOfProductsController(PDCContext context)
        {
            _context = context;
        }

        // GET: LineOfProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.LinesOfProducts.ToListAsync());
        }

        // GET: LineOfProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineOfProduct = await _context.LinesOfProducts
                .FirstOrDefaultAsync(m => m.LineOfProductId == id);
            if (lineOfProduct == null)
            {
                return NotFound();
            }

            return View(lineOfProduct);
        }

        // GET: LineOfProducts/Create
        [Authorize(Policy = "Permissions.LineOfProducts.Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LineOfProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LineOfProductId,Description")] LineOfProduct lineOfProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lineOfProduct);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            return View(lineOfProduct);
        }

        // GET: LineOfProducts/Edit/5
        [Authorize(Policy = "Permissions.LineOfProducts.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineOfProduct = await _context.LinesOfProducts.FindAsync(id);
            if (lineOfProduct == null)
            {
                return NotFound();
            }
            return View(lineOfProduct);
        }

        // POST: LineOfProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LineOfProductId,Description")] LineOfProduct lineOfProduct)
        {
            if (id != lineOfProduct.LineOfProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old = await _context.LinesOfProducts.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(lineOfProduct);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineOfProductExists(lineOfProduct.LineOfProductId))
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
            return View(lineOfProduct);
        }

        // GET: LineOfProducts/Delete/5
        [Authorize(Policy = "Permissions.LineOfProducts.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineOfProduct = await _context.LinesOfProducts
                .FirstOrDefaultAsync(m => m.LineOfProductId == id);
            if (lineOfProduct == null)
            {
                return NotFound();
            }

            return View(lineOfProduct);
        }

        // POST: LineOfProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lineOfProduct = await _context.LinesOfProducts.FindAsync(id);
            _context.LinesOfProducts.Remove(lineOfProduct);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool LineOfProductExists(int id)
        {
            return _context.LinesOfProducts.Any(e => e.LineOfProductId == id);
        }
    }
}
