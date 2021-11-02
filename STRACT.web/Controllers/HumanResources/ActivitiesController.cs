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
using STRACT.web.Models.HumanResources;

namespace STRACT.web.Controllers.HumanResources
{
    [Authorize(Policy = "Permissions.Activities.View")]
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new ActivityInGroupsData();
            viewModel.Activities = await _context.Activities
                .Include(a => a.ActivityInGroups)
                    .ThenInclude(a => a.ActivityGroup)
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ToListAsync();

            if (id != null)
            {
                ViewData["ActivityId"] = id.Value;
                Activity activity = viewModel.Activities.Where(i => i.ActivityId == id.Value).Single();
                viewModel.ActivityGroups = activity.ActivityInGroups.Select(s => s.ActivityGroup);
                viewModel.SkillInActivities = _context.SkillInActivity
                    .Include(s => s.Skill)
                        .ThenInclude(sg => sg.SkillGroup)
                    .Include(a => a.Activity)
                    .Where(a => a.ActivityId == activity.ActivityId);
            }

            return View(viewModel);
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (activity == null)
            {
                return NotFound();
            }
            
            return View(activity);
        }

        // GET: Activities/Create
        [Authorize(Policy = "Permissions.Activities.Create")]
        public IActionResult Create()
        {
            PopulateAssignedActivityGroupsData(new Activity { });
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityId,Name,Description")] Activity activity, string[] selectedGroups)
        {
            if (ModelState.IsValid)
            {
                UpdateActivityGroups(selectedGroups, activity);
                _context.Add(activity);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedActivityGroupsData(activity);
            return View(activity);
        }

        // GET: Activities/Edit/5
        [Authorize(Policy = "Permissions.Activities.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.ActivityInGroups)
                    .ThenInclude(a => a.ActivityGroup)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (activity == null)
            {
                return NotFound();
            }
            PopulateAssignedActivityGroupsData(activity);
            return View(activity);
        }

        //POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedGroups)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityToUpdate = await _context.Activities
                .Include(a => a.ActivityInGroups)
                    .ThenInclude(a => a.ActivityGroup)
                .FirstOrDefaultAsync(m => m.ActivityId == id);

            if (await TryUpdateModelAsync<Activity>(
                activityToUpdate, "", i => i.Name, i => i.Description))
            {
                UpdateActivityGroups(selectedGroups, activityToUpdate);
                try
                {
                    var old = await _context.Activities.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(activityToUpdate);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activityToUpdate.ActivityId))
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
            UpdateActivityGroups(selectedGroups, activityToUpdate);
            PopulateAssignedActivityGroupsData(activityToUpdate);
            return View(activityToUpdate);
        }


        // GET: Activities/Delete/5
        [Authorize(Policy = "Permissions.Activities.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.Activities
                .Include(a => a.ActivityInGroups)
                .SingleAsync(i => i.ActivityId == id);
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityExists(int id)
        {
            return _context.Activities.Any(e => e.ActivityId == id);
        }

        private void PopulateAssignedActivityGroupsData(Activity activity)
        {
            var allActivityGroups = _context.ActivityGroups;
            var activityGroups = activity.ActivityInGroups == null ? 
                new HashSet<int>() : 
                new HashSet<int>(activity.ActivityInGroups.Select(c => c.ActivityGroupId));
            var viewModel = new List<AssignedActivityGroups>();
            foreach (var group in allActivityGroups)
            {
                viewModel.Add(new AssignedActivityGroups
                {
                    ActivityGroupId = group.ActivityGroupId,
                    Name = group.Name,
                    Assigned = activityGroups.Contains(group.ActivityGroupId)
                }) ;
            }
            ViewData["ActivityGroups"] = viewModel;
        }

        private void UpdateActivityGroups(string[] selectedGroups, Activity activityToUpdate)
        {
            if (selectedGroups == null)
            {
                activityToUpdate.ActivityInGroups = new List<ActivityInGroup>();
                return;
            }

            var selectedGroupsHashSet = new HashSet<string>(selectedGroups);
            var activityGroups = activityToUpdate.ActivityInGroups == null ?
                new HashSet<int>() :
                new HashSet<int>(activityToUpdate.ActivityInGroups.Select(c => c.ActivityGroupId));
            foreach (var group in _context.ActivityGroups)
            {
                if (selectedGroupsHashSet.Contains(group.ActivityGroupId.ToString()))
                {
                    if (!activityGroups.Contains(group.ActivityGroupId))
                    {
                        if (activityToUpdate.ActivityInGroups == null) 
                        { 
                            activityToUpdate.ActivityInGroups = new List<ActivityInGroup>(); 
                        }
                        activityToUpdate.ActivityInGroups.Add(new ActivityInGroup { ActivityId = activityToUpdate.ActivityId, ActivityGroupId = group.ActivityGroupId });
                    }
                }
                else
                {
                    if (activityGroups.Contains(group.ActivityGroupId))
                    {
                        ActivityInGroup groupToRemove = activityToUpdate.ActivityInGroups.FirstOrDefault(a => a.ActivityGroupId == group.ActivityGroupId);
                        _context.Remove(groupToRemove);
                    }
                }
            }
        }
    }
}
