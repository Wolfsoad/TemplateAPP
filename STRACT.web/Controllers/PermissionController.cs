using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using STRACT.Identity.Helpers;
using STRACT.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STRACT.web.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class PermissionController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public PermissionController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index(string roleId, string searchString)
        {

            var model = new PermissionViewModel();
            List<RoleClaimsViewModel> allPermissions = GetAllPermissions(roleId);
            var role = await _roleManager.FindByIdAsync(roleId);
            model.RoleId = roleId;
            var claims = await _roleManager.GetClaimsAsync(role);
            var allClaimValues = allPermissions.Select(a => a.Value).ToList();
            var roleClaimValues = claims.Select(a => a.Value).ToList();
            var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
            foreach (var permission in allPermissions)
            {
                if (authorizedClaims.Any(a => a == permission.Value))
                {
                    permission.Selected = true;
                }
            }
            model.RoleClaims = allPermissions;

            #region Filtering
            model.SearchString = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                model.RoleClaims = model.RoleClaims.Where(a => a.Value.ToLower().Contains(searchString.ToLower())).ToList();
            }

            #endregion


            return View(model);
        }

        private static List<RoleClaimsViewModel> GetAllPermissions(string roleId)
        {
            var allPermissions = new List<RoleClaimsViewModel>();
            allPermissions.GetPermissions(typeof(Permissions.Declarations), roleId);
            allPermissions.GetPermissions(typeof(Permissions.RoleManager), roleId);
            allPermissions.GetPermissions(typeof(Permissions.ActionGroups), roleId);
            allPermissions.GetPermissions(typeof(Permissions.AlertTypes), roleId);
            allPermissions.GetPermissions(typeof(Permissions.LineOfProducts), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Locations), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Topics), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Currencies), roleId);
            allPermissions.GetPermissions(typeof(Permissions.LineOfProducts), roleId);
            allPermissions.GetPermissions(typeof(Permissions.FinancialLineTypes), roleId);
            allPermissions.GetPermissions(typeof(Permissions.FinancialLineSubTypes), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Activities), roleId);
            allPermissions.GetPermissions(typeof(Permissions.ActivityGroups), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Departments), roleId);
            allPermissions.GetPermissions(typeof(Permissions.SkillGroups), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Skills), roleId);
            allPermissions.GetPermissions(typeof(Permissions.FunctionalRoles), roleId);
            allPermissions.GetPermissions(typeof(Permissions.OrganizationalRoles), roleId);
            allPermissions.GetPermissions(typeof(Permissions.UserInTeams), roleId);
            allPermissions.GetPermissions(typeof(Permissions.UserSkillsEvaluations), roleId);
            allPermissions.GetPermissions(typeof(Permissions.UserHolidays), roleId);
            allPermissions.GetPermissions(typeof(Permissions.SkillInActivities), roleId);
            allPermissions.GetPermissions(typeof(Permissions.DeclarationItems), roleId);
            allPermissions.GetPermissions(typeof(Permissions.DeclarationRevisions), roleId);
            allPermissions.GetPermissions(typeof(Permissions.DeclarationSignatures), roleId);
            allPermissions.GetPermissions(typeof(Permissions.CertificationLines), roleId);
            return allPermissions;
        }

        public async Task<IActionResult> Update(PermissionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            var selectedClaims = model.RoleClaims.Where(a => a.Selected).ToList();
            foreach (var claim in selectedClaims)
            {
                await _roleManager.AddPermissionClaim(role, claim.Value);
            }
            return RedirectToAction("Index", new { roleId = model.RoleId });
        }

    }
}
