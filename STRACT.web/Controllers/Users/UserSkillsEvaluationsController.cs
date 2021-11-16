using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Data.Validators;
using STRACT.Entities.Users;

namespace STRACT.web.Controllers.Users
{
    [Authorize(Policy = "Permissions.UserSkillsEvaluations.View")]
    public class UserSkillsEvaluationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserSkillsEvaluationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserSkillsEvaluations
        public async Task<IActionResult> Index(int userInTeamId)
        {
            var applicationDbContext = _context.UserSkillsEvaluations
                .Include(u => u.Skill)
                    .ThenInclude(s => s.SkillGroup)
                .Include(u => u.User)
                    .ThenInclude(u => u.ApplicationUser)
                .Where(u => u.UserId == userInTeamId);
            ViewBag.SelectedUserInTeamId = userInTeamId;
            ViewBag.SelectedUserInTeamName = _context.UserInTeam
                .Include(u => u.ApplicationUser)
                .FirstOrDefault(u => u.UserInTeamId == userInTeamId).ApplicationUser.UserName;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserSkillsEvaluations/Details/5
        public async Task<IActionResult> Details(int? skillId, int? userId)
        {
            if (skillId == null || userId == null)
            {
                return NotFound();
            }

            var userSkillsEvaluation = await _context.UserSkillsEvaluations
                .Include(u => u.Skill)
                    .ThenInclude(s => s.SkillGroup)
                .Include(u => u.User)
                    .ThenInclude(u => u.ApplicationUser)
                .Where(m => m.SkillId == skillId)
                .FirstOrDefaultAsync(m => m.UserId == userId);
            if (userSkillsEvaluation == null)
            {
                return NotFound();
            }

            ViewBag.SelectedUserInTeamId = userId;
            ViewBag.SelectedUserInTeamName = _context.UserInTeam
                .Include(u => u.ApplicationUser)
                .FirstOrDefault(u => u.UserInTeamId == userId).ApplicationUser.UserName;

            return View(userSkillsEvaluation);
        }

        // GET: UserSkillsEvaluations/Create
        [Authorize(Policy = "Permissions.UserSkillsEvaluations.Create")]
        public IActionResult Create(int userInTeamId)
        {
            ViewData["UserInTeamId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId", _context.UserInTeam.FirstOrDefault(m => m.UserInTeamId == userInTeamId).UserInTeamId);
            PopulateSkillDropDownList(userInTeamId);
            ViewBag.SelectedUserInTeamId = userInTeamId;
            ViewBag.SelectedUserInTeamName = _context.UserInTeam
                .Include(u => u.ApplicationUser)
                .FirstOrDefault(u => u.UserInTeamId == userInTeamId).ApplicationUser.UserName;
            return View();
        }

        // POST: UserSkillsEvaluations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,SkillId,SkillScore")] UserSkillsEvaluation userSkillsEvaluation, int userInTeamId)
        {
            if (ModelState.IsValid)
            {
                if (userInTeamId != 0) { userSkillsEvaluation.UserId = userInTeamId; }
                _context.Add(userSkillsEvaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { userInTeamId });
            }
            PopulateSkillDropDownList(userSkillsEvaluation.UserId, userSkillsEvaluation.SkillId);

            //ViewBag itens
            ViewBag.SelectedUserInTeamId = userInTeamId;
            ViewBag.SelectedUserInTeamName = _context.UserInTeam
                .Include(u => u.ApplicationUser)
                .FirstOrDefault(u => u.UserInTeamId == userInTeamId).ApplicationUser.UserName;
            ViewData["UserInTeamId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId", _context.UserInTeam.FirstOrDefault(m => m.UserInTeamId == userInTeamId).UserInTeamId);

            return View(userSkillsEvaluation);
        }

        // GET: UserSkillsEvaluations/Edit/5
        [Authorize(Policy = "Permissions.UserSkillsEvaluations.Edit")]
        public async Task<IActionResult> Edit(int? skillId, int? userId)
        {
            if (skillId == null || userId == null)
            {
                return NotFound();
            }

            var userSkillsEvaluation = await _context.UserSkillsEvaluations
                .Where(m => m.UserId == userId)
                .FirstOrDefaultAsync(m => m.SkillId == skillId);
            if (userSkillsEvaluation == null)
            {
                return NotFound();
            }
            PopulateSkillDropDownList(userSkillsEvaluation.UserId, userSkillsEvaluation.SkillId);

            //ViewBag itens
            ViewBag.SelectedUserInTeamId = userId;
            ViewBag.SelectedUserInTeamName = _context.UserInTeam
                .Include(u => u.ApplicationUser)
                .FirstOrDefault(u => u.UserInTeamId == userId).ApplicationUser.UserName;
            ViewData["UserInTeamId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId", _context.UserInTeam.FirstOrDefault(m => m.UserInTeamId == userId).UserInTeamId);

            return View(userSkillsEvaluation);
        }

        // POST: UserSkillsEvaluations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? skillId, int? userId, [Bind("UserId,SkillId,SkillScore")] UserSkillsEvaluation userSkillsEvaluation)
        {
            if (skillId != userSkillsEvaluation.SkillId || userId != userSkillsEvaluation.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSkillsEvaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSkillsEvaluationExists(userSkillsEvaluation.UserId, userSkillsEvaluation.SkillId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { userInTeamId = userId});
            }

            //ViewBag itens
            ViewBag.SelectedUserInTeamId = userId;
            ViewBag.SelectedUserInTeamName = _context.UserInTeam
                .Include(u => u.ApplicationUser)
                .FirstOrDefault(u => u.UserInTeamId == userId).ApplicationUser.UserName;
            ViewData["UserInTeamId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId", _context.UserInTeam.FirstOrDefault(m => m.UserInTeamId == userId).UserInTeamId);

            PopulateSkillDropDownList(userSkillsEvaluation.UserId, userSkillsEvaluation.SkillId);
            return View(userSkillsEvaluation);
        }

        // GET: UserSkillsEvaluations/Delete/5
        [Authorize(Policy = "Permissions.UserSkillsEvaluations.Delete")]
        public async Task<IActionResult> Delete(int? skillId, int? userId)
        {
            if (skillId == null || userId == null)
            {
                return NotFound();
            }

            var userSkillsEvaluation = await _context.UserSkillsEvaluations
                .Include(u => u.Skill)
                .Include(u => u.User)
                .Where(m => m.SkillId == skillId)
                .FirstOrDefaultAsync(m => m.UserId == userId);
            if (userSkillsEvaluation == null)
            {
                return NotFound();
            }

            //ViewBag itens
            ViewBag.SelectedUserInTeamId = userId;
            ViewBag.SelectedUserInTeamName = _context.UserInTeam
                .Include(u => u.ApplicationUser)
                .FirstOrDefault(u => u.UserInTeamId == userId).ApplicationUser.UserName;
            ViewData["UserInTeamId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId", _context.UserInTeam.FirstOrDefault(m => m.UserInTeamId == userId).UserInTeamId);

            return View(userSkillsEvaluation);
        }

        // POST: UserSkillsEvaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? skillId, int? userId)
        {
            var userSkillsEvaluation = await _context.UserSkillsEvaluations
                .Where(m => m.SkillId == skillId)
                .FirstOrDefaultAsync(m => m.UserId == userId);
            _context.UserSkillsEvaluations.Remove(userSkillsEvaluation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { userInTeamId = userId });
        }

        private bool UserSkillsEvaluationExists(int userId, int skillId)
        {
            return _context.UserSkillsEvaluations.Where(e => e.SkillId == skillId).Any(e => e.UserId == userId);
        }

        private void PopulateSkillDropDownList(int userInTeamId, object selectedSkill = null)
        {
            string actualSkillId = selectedSkill != null ? selectedSkill.ToString() : string.Empty;
            var skillsAlreadyClassified = from skillEvaluation in _context.UserSkillsEvaluations
                                          where (skillEvaluation.UserId == userInTeamId && skillEvaluation.SkillId.ToString() != actualSkillId)
                                          select skillEvaluation.SkillId;
            var skillQuery = from sg in _context.Skills
                             where !skillsAlreadyClassified.Contains(sg.SkillId)
                             orderby sg.Name
                             select new
                             {
                                 SkillId = sg.SkillId,
                                 Description = string.Format("{0} | {1}", sg.SkillGroup.Name, sg.Name)
                             };
            ViewBag.SkillId = new SelectList(skillQuery.AsTracking(), "SkillId", "Description", selectedSkill);
        }

    }
}
