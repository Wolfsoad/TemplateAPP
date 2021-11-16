using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.Kanban;

namespace STRACT.web.Controllers.Kanban
{
    public class LocationInKanbansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationInKanbansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocationInKanbans
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationInKanbans.ToListAsync());
        }

        // GET: LocationInKanbans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationInKanban = await _context.LocationInKanbans
                .FirstOrDefaultAsync(m => m.LocationInKanbanId == id);
            if (locationInKanban == null)
            {
                return NotFound();
            }

            return View(locationInKanban);
        }

        // GET: LocationInKanbans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationInKanbans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationInKanbanId,Description,Color")] LocationInKanban locationInKanban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationInKanban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationInKanban);
        }

        // GET: LocationInKanbans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationInKanban = await _context.LocationInKanbans.FindAsync(id);
            if (locationInKanban == null)
            {
                return NotFound();
            }
            return View(locationInKanban);
        }

        // POST: LocationInKanbans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationInKanbanId,Description,Color")] LocationInKanban locationInKanban)
        {
            if (id != locationInKanban.LocationInKanbanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationInKanban);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationInKanbanExists(locationInKanban.LocationInKanbanId))
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
            return View(locationInKanban);
        }

        // GET: LocationInKanbans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationInKanban = await _context.LocationInKanbans
                .FirstOrDefaultAsync(m => m.LocationInKanbanId == id);
            if (locationInKanban == null)
            {
                return NotFound();
            }

            return View(locationInKanban);
        }

        // POST: LocationInKanbans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationInKanban = await _context.LocationInKanbans.FindAsync(id);
            _context.LocationInKanbans.Remove(locationInKanban);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationInKanbanExists(int id)
        {
            return _context.LocationInKanbans.Any(e => e.LocationInKanbanId == id);
        }
    }
}
