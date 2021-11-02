using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.HumanResources;

namespace STRACT.web.Controllers.HumanResources
{
    public class SkillInActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillInActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SkillInActivities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SkillInActivity
                .Include(s => s.Activity)
                .Include(s => s.Skill)
                    .ThenInclude(sg => sg.SkillGroup);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SkillInActivities/Details/5
        public async Task<IActionResult> Details(int? skillId, int? activityId)
        {
            if (skillId == null || activityId == null)
            {
                return NotFound();
            }

            var skillInActivity = await _context.SkillInActivity
                .Include(s => s.Activity)
                .Include(s => s.Skill)
                    .ThenInclude(sg => sg.SkillGroup)
                .Where(s => s.ActivityId == activityId)
                .FirstOrDefaultAsync(m => m.SkillId == skillId);
            if (skillInActivity == null)
            {
                return NotFound();
            }

            return View(skillInActivity);
        }

        // GET: SkillInActivities/Create
        public IActionResult Create()
        {
            PopulateActivityDropDownList();
            PopulateSkillDropDownList();
            return View();
        }

        // POST: SkillInActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityId,SkillId,RequestedScore")] SkillInActivity skillInActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillInActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateActivityDropDownList(skillInActivity.ActivityId);
            PopulateSkillDropDownList(skillInActivity.SkillId);
            return View(skillInActivity);
        }

        // GET: SkillInActivities/Edit/5
        public async Task<IActionResult> Edit(int? skillId, int? activityId)
        {
            if (skillId == null || activityId == null)
            {
                return NotFound();
            }

            var skillInActivity = await _context.SkillInActivity
                .Include(s => s.Activity)
                .Include(s => s.Skill)
                    .ThenInclude(sg => sg.SkillGroup)
                .Where(s => s.ActivityId == activityId)
                .FirstOrDefaultAsync(m => m.SkillId == skillId);
            if (skillInActivity == null)
            {
                return NotFound();
            }
            PopulateActivityDropDownList(skillInActivity.ActivityId);
            PopulateSkillDropDownList(skillInActivity.SkillId);
            return View(skillInActivity);
        }

        // POST: SkillInActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? skillId, int? activityId, [Bind("ActivityId,SkillId,RequestedScore")] SkillInActivity skillInActivity)
        {
            if (skillId != skillInActivity.SkillId || activityId != skillInActivity.ActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skillInActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillInActivityExists(skillInActivity.SkillId, skillInActivity.ActivityId))
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
            PopulateActivityDropDownList(skillInActivity.ActivityId);
            PopulateSkillDropDownList(skillInActivity.SkillId);
            return View(skillInActivity);
        }

        // GET: SkillInActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillInActivity = await _context.SkillInActivity
                .Include(s => s.Activity)
                .Include(s => s.Skill)
                    .ThenInclude(sg => sg.SkillGroup)
                .FirstOrDefaultAsync(m => m.SkillId == id);
            if (skillInActivity == null)
            {
                return NotFound();
            }

            return View(skillInActivity);
        }

        // POST: SkillInActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skillInActivity = await _context.SkillInActivity.FindAsync(id);
            _context.SkillInActivity.Remove(skillInActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillInActivityExists(int skillId, int activityId)
        {
            return _context.SkillInActivity.Where(e => e.SkillId == skillId).Any(e => e.ActivityId == activityId);
        }

        private void PopulateSkillDropDownList(object selectedSkill = null)
        {
            var skillQuery = from sg in _context.Skills
                                   orderby sg.Name
                                   select new
                                   {
                                       SkillId = sg.SkillId,
                                       Description = string.Format("{0} | {1}", sg.SkillGroup.Name, sg.Name)
                                   };
            ViewBag.SkillId = new SelectList(skillQuery.AsTracking(), "SkillId", "Description", selectedSkill);
        }

        private void PopulateActivityDropDownList(object selectedActivity = null)
        {
            var activityQuery = from sg in _context.Activities
                             orderby sg.Name
                             select sg;
            ViewBag.ActivityId = new SelectList(activityQuery.AsTracking(), "ActivityId", "Name", selectedActivity);
        }
    }
}
