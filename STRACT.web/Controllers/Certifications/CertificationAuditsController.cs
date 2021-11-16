using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.Certifications;

namespace STRACT.web.Controllers.Certifications
{
    public class CertificationAuditsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificationAuditsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Audits
        public async Task<IActionResult> Index(int selectedCertificationLineId)
        {
            var applicationDbContext = _context.Audits
                .Include(a => a.CertificationLine)
                    .ThenInclude(cl => cl.Entity)
                .Include(a => a.Location)
                .Include(a => a.User)
                    .ThenInclude(u => u.ApplicationUser)
                .Where(a => a.CertificationLineId == selectedCertificationLineId)
                .OrderByDescending(a => a.DateOfAudit);
            ViewBag.SelectedCertificationLineId = selectedCertificationLineId;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Audits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits
                .Include(a => a.CertificationLine)
                    .ThenInclude(cl => cl.Entity)
                .Include(a => a.Location)
                .Include(a => a.User)
                    .ThenInclude(u => u.ApplicationUser)
                .FirstOrDefaultAsync(m => m.AuditId == id);
            if (audit == null)
            {
                return NotFound();
            }
            ViewBag.SelectedCertificationLineId = audit.CertificationLineId;
            return View(audit);
        }

        // GET: Audits/Create
        public IActionResult Create(int selectedCertificationLineId)
        {
            PopulateCertificationLinesDropDownList(selectedCertificationLineId);
            PopulateLocationsDropDownList(null, selectedCertificationLineId);
            PopulateUserInTeamDropDownList();
            ViewBag.SelectedCertificationLineId = selectedCertificationLineId;
            return View();
        }

        // POST: Audits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuditId,Year,DateOfAudit,Concluded,UserId,CertificationLineId,LocationId")] Audit audit, int selectedCertificationLineId)
        {
            if (ModelState.IsValid)
            {
                if (selectedCertificationLineId != 0)
                {
                    audit.CertificationLineId = selectedCertificationLineId;
                }
                _context.Add(audit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { selectedCertificationLineId });
            }
            PopulateCertificationLinesDropDownList(audit.CertificationLineId);
            PopulateLocationsDropDownList(audit.LocationId);
            PopulateUserInTeamDropDownList(audit.UserId);
            ViewBag.SelectedCertificationLineId = audit.CertificationLineId;
            return View(audit);
        }

        // GET: Audits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits.FindAsync(id);
            if (audit == null)
            {
                return NotFound();
            }
            PopulateCertificationLinesDropDownList(audit.CertificationLineId);
            PopulateLocationsDropDownList(audit.LocationId);
            PopulateUserInTeamDropDownList(audit.UserId);
            ViewBag.SelectedCertificationLineId = audit.CertificationLineId;
            return View(audit);
        }

        // POST: Audits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuditId,Year,DateOfAudit,Concluded,UserId,CertificationLineId,LocationId")] Audit audit)
        {
            if (id != audit.AuditId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditExists(audit.AuditId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { selectedCertificationLineId = audit.CertificationLineId });
            }
            PopulateCertificationLinesDropDownList(audit.CertificationLineId);
            PopulateLocationsDropDownList(audit.LocationId);
            PopulateUserInTeamDropDownList(audit.UserId);
            return View(audit);
        }

        // GET: Audits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits
                .Include(a => a.CertificationLine)
                .Include(a => a.Location)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AuditId == id);
            if (audit == null)
            {
                return NotFound();
            }
            ViewBag.SelectedCertificationLineId = audit.CertificationLineId;
            return View(audit);
        }

        // POST: Audits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var audit = await _context.Audits.FindAsync(id);
            _context.Audits.Remove(audit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { selectedCertificationLineId = audit.CertificationLineId });
        }

        private bool AuditExists(int id)
        {
            return _context.Audits.Any(e => e.AuditId == id);
        }

        private void PopulateLocationsDropDownList(object selectedLocation = null, int selectedCertificationLine = 0)
        {
            var availableLocations = _context.CertificationInLocations
                .Include(c => c.Location)
                .Where(c => c.CertificationLineId == selectedCertificationLine)
                .Select(c => c.Location);
            var query = from sg in availableLocations
                        orderby sg.Name
                        select new
                        {
                            LocationId = sg.LocationId,
                            Description = string.Format("{0}", sg.Name)
                        };
            ViewBag.LocationId = new SelectList(query.AsTracking(), "LocationId", "Description", selectedLocation);
        }

        private void PopulateCertificationLinesDropDownList(object selectedCertificationLine = null)
        {
            var query = from sg in _context.CertificationLines
                        where sg.FactoryAudit == true
                        orderby sg.CertificationLineId
                        select new
                        {
                            CertificationLineId = sg.CertificationLineId,
                            Description = string.Format("{0} ({1})", sg.Description, sg.Entity.Name)
                        };
            ViewBag.CertificationLineId = new SelectList(query.AsTracking(), "CertificationLineId", "Description", selectedCertificationLine);
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
