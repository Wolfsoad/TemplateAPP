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
using STRACT.Entities.Projects;

namespace STRACT.web.Controllers.Projects
{
    [Authorize(Policy = "Permissions.ActionGroups.View")]
    public class ActionGroupsController : Controller
    {
        private readonly PDCContext _context;

        public ActionGroupsController(PDCContext context)
        {
            _context = context;
        }

        // GET: ActionGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActionGroups.ToListAsync());
        }

        // GET: ActionGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionGroup = await _context.ActionGroups
                .FirstOrDefaultAsync(m => m.ActionGroupId == id);
            if (actionGroup == null)
            {
                return NotFound();
            }

            return View(actionGroup);
        }

        // GET: ActionGroups/Create
        [Authorize(Policy = "Permissions.ActionGroups.Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActionGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActionGroupId,Description")] ActionGroup actionGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actionGroup);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            return View(actionGroup);
        }

        // GET: ActionGroups/Edit/5
        [Authorize(Policy = "Permissions.ActionGroups.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionGroup = await _context.ActionGroups.FindAsync(id);
            if (actionGroup == null)
            {
                return NotFound();
            }
            return View(actionGroup);
        }

        // POST: ActionGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActionGroupId,Description")] ActionGroup actionGroup)
        {
            if (id != actionGroup.ActionGroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old = await _context.ActivityGroups.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(actionGroup);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActionGroupExists(actionGroup.ActionGroupId))
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
            return View(actionGroup);
        }

        // GET: ActionGroups/Delete/5
        [Authorize(Policy = "Permissions.ActionGroups.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionGroup = await _context.ActionGroups
                .FirstOrDefaultAsync(m => m.ActionGroupId == id);
            if (actionGroup == null)
            {
                return NotFound();
            }

            return View(actionGroup);
        }

        // POST: ActionGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actionGroup = await _context.ActionGroups.FindAsync(id);
            _context.ActionGroups.Remove(actionGroup);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool ActionGroupExists(int id)
        {
            return _context.ActionGroups.Any(e => e.ActionGroupId == id);
        }
    }
}
