using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.HumanResources;

namespace STRACT.web.Controllers.HumanResources
{
    [Authorize(Policy = "Permissions.UserHolidays.View")]
    public class UserHolidaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserHolidaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserHolidays
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserHolidays.Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserHolidays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHoliday = await _context.UserHolidays
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserHolidayId == id);
            if (userHoliday == null)
            {
                return NotFound();
            }

            return View(userHoliday);
        }

        // GET: UserHolidays/Create
        [Authorize(Policy = "Permissions.UserHolidays.Create")]
        public IActionResult Create()
        {
            ViewData["UserInTeamId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId");
            return View();
        }

        // POST: UserHolidays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserHolidayId,DataOfHoliday,UserInTeamId")] UserHoliday userHoliday)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userHoliday);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserInTeamId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId", userHoliday.UserInTeamId);
            return View(userHoliday);
        }

        // GET: UserHolidays/Edit/5
        [Authorize(Policy = "Permissions.UserHolidays.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHoliday = await _context.UserHolidays.FindAsync(id);
            if (userHoliday == null)
            {
                return NotFound();
            }
            ViewData["UserInTeamId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId", userHoliday.UserInTeamId);
            return View(userHoliday);
        }

        // POST: UserHolidays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserHolidayId,DataOfHoliday,UserInTeamId")] UserHoliday userHoliday)
        {
            if (id != userHoliday.UserHolidayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userHoliday);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserHolidayExists(userHoliday.UserHolidayId))
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
            ViewData["UserInTeamId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId", userHoliday.UserInTeamId);
            return View(userHoliday);
        }

        // GET: UserHolidays/Delete/5
        [Authorize(Policy = "Permissions.UserHolidays.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHoliday = await _context.UserHolidays
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserHolidayId == id);
            if (userHoliday == null)
            {
                return NotFound();
            }

            return View(userHoliday);
        }

        // POST: UserHolidays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userHoliday = await _context.UserHolidays.FindAsync(id);
            _context.UserHolidays.Remove(userHoliday);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserHolidayExists(int id)
        {
            return _context.UserHolidays.Any(e => e.UserHolidayId == id);
        }
    }
}
