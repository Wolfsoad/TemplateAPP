using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Common;
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
            var applicationDbContext = _context
                .UserHolidays.Include(u => u.User)
                    .ThenInclude(u => u.ApplicationUser);
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
            PopulateUserInTeamDropDownList();
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
            PopulateUserInTeamDropDownList(userHoliday.UserHolidayId);
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
            PopulateUserInTeamDropDownList(userHoliday.UserHolidayId);
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
            PopulateUserInTeamDropDownList(userHoliday.UserHolidayId);
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

        public IActionResult Calendar()
        {
            return View();
        }

        public JsonResult GetCalendarItems()
        {
            var items = (from e in _context
                        .UserHolidays
                        select new EventInCalendar
                        {
                            id = e.UserHolidayId,
                            name = "Holidays of " + e.User.ApplicationUser.UserName,
                            startDate = e.DataOfHoliday,
                            endDate = e.DataOfHoliday,
                            color = e.User.Color
                        }).Distinct().ToList();

            // Get holidays between dates
            var holidays = (from e in DateTimeExtension.GetNationalHolidaysBetweenDates(new DateTime(2021, 1, 1), new DateTime(2021, 12, 31))
                            select new EventInCalendar
                            {
                                name = e.Key,
                                startDate = e.Value,
                                endDate = e.Value,
                                color = "#a80600"
                            }).Distinct();

            var total = items.Concat(holidays);
            return Json(total);
        }
        private bool UserHolidayExists(int id)
        {
            return _context.UserHolidays.Any(e => e.UserHolidayId == id);
        }

        private void PopulateUserInTeamDropDownList(object selectedUserInTeam = null)
        {
            var userInTeamQuery = from sg in _context.UserInTeam
                                  where sg.Active
                                  orderby sg.ApplicationUser.UserName
                                  select new
                                  {
                                      UserInTeamId = sg.UserInTeamId,
                                      Description = string.Format("{0} | {1}", sg.ApplicationUser.UserName, sg.ApplicationUser.Email)
                                  };

            ViewBag.UserInTeamId = new SelectList(userInTeamQuery.AsTracking(), "UserInTeamId", "Description", selectedUserInTeam);
        }
    }
}
