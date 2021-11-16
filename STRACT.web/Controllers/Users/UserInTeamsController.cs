using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.Users;
using STRACT.Identity.Entities;

namespace STRACT.web.Controllers.Users
{
    [Authorize(Policy = "Permissions.UserInTeams.View")]
    public class UserInTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserInTeamsController(ApplicationDbContext context)
        {
            _context = context;

        }

        // GET: UserInTeams
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserInTeam
                .Include(u => u.OrganizationalRole)
                .Include(u => u.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserInTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInTeam = await _context.UserInTeam
                .Include(u => u.OrganizationalRole)
                .Include(u => u.ApplicationUser)
                .FirstOrDefaultAsync(m => m.UserInTeamId == id);
            if (userInTeam == null)
            {
                return NotFound();
            }

            return View(userInTeam);
        }

        // GET: UserInTeams/Create
        [Authorize(Policy = "Permissions.UserInTeams.Create")]
        public IActionResult Create()
        {
            PopulateApplicationUserDropDownList();
            PopulateOrganizationalRoleDropDownList();
            return View();
        }

        // POST: UserInTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserInTeamId,Active,Color,OrganizationalRoleId,ApplicationUserId")] UserInTeam userInTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userInTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateApplicationUserDropDownList(userInTeam.ApplicationUserId);
            PopulateOrganizationalRoleDropDownList(userInTeam.OrganizationalRoleId);
            return View(userInTeam);
        }

        // GET: UserInTeams/Edit/5
        [Authorize(Policy = "Permissions.UserInTeams.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInTeam = await _context.UserInTeam
                .Include(u => u.OrganizationalRole)
                .Include(u => u.ApplicationUser)
                .FirstOrDefaultAsync(u => u.UserInTeamId == id);
            if (userInTeam == null)
            {
                return NotFound();
            }
            PopulateApplicationUserDropDownList(userInTeam.ApplicationUserId);
            PopulateOrganizationalRoleDropDownList(userInTeam.OrganizationalRoleId);
            return View(userInTeam);
        }

        // POST: UserInTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserInTeamId,Active,Color,OrganizationalRoleId,ApplicationUserId")] UserInTeam userInTeam)
        {
            if (id != userInTeam.UserInTeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInTeamExists(userInTeam.UserInTeamId))
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
            PopulateApplicationUserDropDownList(userInTeam.ApplicationUserId);
            PopulateOrganizationalRoleDropDownList(userInTeam.OrganizationalRoleId);
            return View(userInTeam);
        }

        // GET: UserInTeams/Delete/5
        [Authorize(Policy = "Permissions.UserInTeams.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInTeam = await _context.UserInTeam
                .Include(u => u.OrganizationalRole)
                .Include(u => u.ApplicationUser)
                .FirstOrDefaultAsync(m => m.UserInTeamId == id);
            if (userInTeam == null)
            {
                return NotFound();
            }

            return View(userInTeam);
        }

        // POST: UserInTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userInTeam = await _context.UserInTeam.FindAsync(id);
            _context.UserInTeam.Remove(userInTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInTeamExists(int id)
        {
            return _context.UserInTeam.Any(e => e.UserInTeamId == id);
        }

        private void PopulateApplicationUserDropDownList(object selectedApplicatinUser = null)
        {
            string actualUserId = selectedApplicatinUser != null ? selectedApplicatinUser.ToString() : string.Empty;
            var usersAlreadyInTeam = from user in _context.UserInTeam
                                     where user.ApplicationUser.Id != actualUserId
                                     select user.ApplicationUser.Id;

            var applicationUserQuery = from sg in _context.Users
                                       where !usersAlreadyInTeam.Contains(sg.Id)
                                       orderby sg.UserName
                                       select new 
                                       {
                                           ApplicationUserId = sg.Id,
                                           Description = string.Format("{0} | {1}", sg.UserName, sg.Email)
                                       };
            ViewBag.ApplicationUserId = new SelectList(applicationUserQuery.AsTracking(), "ApplicationUserId", "Description", selectedApplicatinUser);
        }

        private void PopulateOrganizationalRoleDropDownList(object selectedOrganizationalRole = null)
        {
            var organizationalRoleQuery = from sg in _context.OrganizationalRoles
                                       orderby sg.Name
                                       select new
                                       {
                                           OrganizationalRoleId = sg.OrganizationalRoleId,
                                           Description = sg.Name
                                       };
            ViewBag.OrganizationalRoleId = new SelectList(organizationalRoleQuery.AsTracking(), "OrganizationalRoleId", "Description", selectedOrganizationalRole);
        }
    }
}
