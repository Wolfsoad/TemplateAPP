﻿using System;
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
    [Authorize(Policy = "Permissions.ActivityGroups.View")]
    public class ActivityGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActivityGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityGroups.ToListAsync());
        }

        // GET: ActivityGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityGroup = await _context.ActivityGroups
                .FirstOrDefaultAsync(m => m.ActivityGroupId == id);
            if (activityGroup == null)
            {
                return NotFound();
            }

            return View(activityGroup);
        }

        // GET: ActivityGroups/Create
        [Authorize(Policy = "Permissions.ActivityGroups.Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActivityGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityGroupId,Name,Description")] ActivityGroup activityGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityGroup);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            return View(activityGroup);
        }

        // GET: ActivityGroups/Edit/5
        [Authorize(Policy = "Permissions.ActivityGroups.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityGroup = await _context.ActivityGroups.FindAsync(id);
            if (activityGroup == null)
            {
                return NotFound();
            }
            return View(activityGroup);
        }

        // POST: ActivityGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityGroupId,Name,Description")] ActivityGroup activityGroup)
        {
            if (id != activityGroup.ActivityGroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old = await _context.ActivityGroups.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(activityGroup);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityGroupExists(activityGroup.ActivityGroupId))
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
            return View(activityGroup);
        }

        // GET: ActivityGroups/Delete/5
        [Authorize(Policy = "Permissions.ActivityGroups.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityGroup = await _context.ActivityGroups
                .FirstOrDefaultAsync(m => m.ActivityGroupId == id);
            if (activityGroup == null)
            {
                return NotFound();
            }

            return View(activityGroup);
        }

        // POST: ActivityGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityGroup = await _context.ActivityGroups.FindAsync(id);
            _context.ActivityGroups.Remove(activityGroup);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityGroupExists(int id)
        {
            return _context.ActivityGroups.Any(e => e.ActivityGroupId == id);
        }
    }
}
