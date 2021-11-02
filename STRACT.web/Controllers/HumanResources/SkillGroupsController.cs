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
    [Authorize(Policy = "Permissions.SkillGroups.View")]
    public class SkillGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SkillGroups
        public async Task<IActionResult> Index()
        {
            var result = await _context.SkillGroups
                .Include(sg => sg.Skills)
                .ToListAsync();
            return View(result);
        }

        // GET: SkillGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillGroup = await _context.SkillGroups
                .Include(s => s.Skills)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SkillGroupId == id);
            if (skillGroup == null)
            {
                return NotFound();
            }

            return View(skillGroup);
        }

        // GET: SkillGroups/Create
        [Authorize(Policy = "Permissions.SkillGroups.Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkillGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkillGroupId,Name,Description")] SkillGroup skillGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillGroup);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            return View(skillGroup);
        }

        // GET: SkillGroups/Edit/5
        [Authorize(Policy = "Permissions.SkillGroups.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillGroup = await _context.SkillGroups.FindAsync(id);
            if (skillGroup == null)
            {
                return NotFound();
            }
            return View(skillGroup);
        }

        // POST: SkillGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillGroupId,Name,Description")] SkillGroup skillGroup)
        {
            if (id != skillGroup.SkillGroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old = await _context.SkillGroups.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(skillGroup);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillGroupExists(skillGroup.SkillGroupId))
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
            return View(skillGroup);
        }

        // GET: SkillGroups/Delete/5
        [Authorize(Policy = "Permissions.SkillGroups.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillGroup = await _context.SkillGroups
                .FirstOrDefaultAsync(m => m.SkillGroupId == id);
            if (skillGroup == null)
            {
                return NotFound();
            }

            return View(skillGroup);
        }

        // POST: SkillGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skillGroup = await _context.SkillGroups.FindAsync(id);
            _context.SkillGroups.Remove(skillGroup);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool SkillGroupExists(int id)
        {
            return _context.SkillGroups.Any(e => e.SkillGroupId == id);
        }
    }
}
