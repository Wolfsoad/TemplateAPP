﻿using System;
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
    public class TaskTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskTypes.ToListAsync());
        }

        // GET: TaskTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskType = await _context.TaskTypes
                .FirstOrDefaultAsync(m => m.TaskTypeId == id);
            if (taskType == null)
            {
                return NotFound();
            }

            return View(taskType);
        }

        // GET: TaskTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskTypeId,Description,Color")] TaskType taskType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskType);
        }

        // GET: TaskTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskType = await _context.TaskTypes.FindAsync(id);
            if (taskType == null)
            {
                return NotFound();
            }
            return View(taskType);
        }

        // POST: TaskTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskTypeId,Description,Color")] TaskType taskType)
        {
            if (id != taskType.TaskTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskTypeExists(taskType.TaskTypeId))
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
            return View(taskType);
        }

        // GET: TaskTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskType = await _context.TaskTypes
                .FirstOrDefaultAsync(m => m.TaskTypeId == id);
            if (taskType == null)
            {
                return NotFound();
            }

            return View(taskType);
        }

        // POST: TaskTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskType = await _context.TaskTypes.FindAsync(id);
            _context.TaskTypes.Remove(taskType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskTypeExists(int id)
        {
            return _context.TaskTypes.Any(e => e.TaskTypeId == id);
        }
    }
}
