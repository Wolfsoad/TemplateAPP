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
using STRACT.Entities.Certifications;
using STRACT.web.Models.Certifications;

namespace STRACT.web.Controllers.Certifications
{
    [Authorize(Policy = "Permissions.CertificationLines.View")]
    public class CertificationLinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificationLinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CertificationLines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CertificationLines
                .Include(c => c.Entity)
                .Include(c => c.Audits)
                    .ThenInclude(a => a.Location)
                .Include(c => c.CertificationInLocations)
                    .ThenInclude(c => c.Location)
                .Include(c => c.Certificates);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CertificationLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificationLine = await _context.CertificationLines
                .Include(c => c.Entity)
                .FirstOrDefaultAsync(m => m.CertificationLineId == id);
            if (certificationLine == null)
            {
                return NotFound();
            }

            return View(certificationLine);
        }

        [Authorize(Policy = "Permissions.CertificationLines.Create")]
        // GET: CertificationLines/Create
        public IActionResult Create()
        {
            PopulateAssignedLocationsData(new CertificationLine { });
            PopulateEntitiesDropDownList();
            return View();
        }

        // POST: CertificationLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CertificationLineId,Description,FactoryAudit,FolderPath,AuditFrequency,StartDate,EntityId")] CertificationLine certificationLine, string[] selectedLocations)
        {
            if (ModelState.IsValid)
            {
                UpdateLocations(selectedLocations, certificationLine);
                _context.Add(certificationLine);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedLocationsData(certificationLine);
            PopulateEntitiesDropDownList(certificationLine.EntityId);
            return View(certificationLine);
        }

        // GET: CertificationLines/Edit/5
        [Authorize(Policy = "Permissions.CertificationLines.Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificationLine = await _context.CertificationLines
                .Include(cl => cl.CertificationInLocations)
                    .ThenInclude(cl => cl.Location)
                    .FirstOrDefaultAsync(m => m.CertificationLineId == id);
            if (certificationLine == null)
            {
                return NotFound();
            }
            PopulateAssignedLocationsData(certificationLine);
            PopulateEntitiesDropDownList(certificationLine.EntityId);
            return View(certificationLine);
        }

        // POST: CertificationLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CertificationLineId,Description,FactoryAudit,FolderPath,AuditFrequency,StartDate,EntityId")] CertificationLine certificationLine, string[] selectedLocations)
        {
            if (id != certificationLine.CertificationLineId)
            {
                return NotFound();
            }

            var certificationLineToUpdate = await _context.CertificationLines
                .Include(cl => cl.CertificationInLocations)
                    .ThenInclude(cl => cl.Location)
                .FirstOrDefaultAsync(m => m.CertificationLineId == id);

            if (await TryUpdateModelAsync<CertificationLine>(
                certificationLineToUpdate, "", i => i.CertificationLineId, i => i.Description))
            {
                UpdateLocations(selectedLocations, certificationLineToUpdate);
                try
                {
                    var old = await _context.CertificationLines.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(certificationLineToUpdate);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificationLineExists(certificationLine.CertificationLineId))
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
            UpdateLocations(selectedLocations, certificationLineToUpdate);
            PopulateAssignedLocationsData(certificationLineToUpdate);
            PopulateEntitiesDropDownList(certificationLine.EntityId);
            return View(certificationLine);
        }

        // GET: CertificationLines/Delete/5
        [Authorize(Policy = "Permissions.CertificationLines.Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificationLine = await _context.CertificationLines
                .Include(c => c.Entity)
                .FirstOrDefaultAsync(m => m.CertificationLineId == id);
            if (certificationLine == null)
            {
                return NotFound();
            }

            return View(certificationLine);
        }

        // POST: CertificationLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificationLine = await _context.CertificationLines
                .Include(cl => cl.CertificationInLocations)
                    .ThenInclude(cl => cl.Location)
                .FirstOrDefaultAsync(m => m.CertificationLineId == id);
            _context.CertificationLines.Remove(certificationLine);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool CertificationLineExists(int id)
        {
            return _context.CertificationLines.Any(e => e.CertificationLineId == id);
        }

        private void PopulateEntitiesDropDownList(object selectedEntity = null)
        {
            var query = from sg in _context.Entities
                        orderby sg.Name
                        select new
                        {
                            EntityId = sg.EntityId,
                            Description = string.Format("{0} ({1})", sg.Name, sg.SupplierCode)
                        };
            ViewBag.EntityId = new SelectList(query.AsTracking(), "EntityId", "Description", selectedEntity);
        }

        private void PopulateAssignedLocationsData(CertificationLine certificationLine)
        {
            var allLocations = _context.Locations;
            var locations = certificationLine.CertificationInLocations == null ? new HashSet<int>() : new HashSet<int>(certificationLine.CertificationInLocations.Select(c => c.LocationId));
            var viewModel = new List<AssignedLocation>();
            foreach (var location in allLocations)
            {
                viewModel.Add(new AssignedLocation
                {
                    LocationId = location.LocationId,
                    Name = location.Name,
                    Assigned = locations.Contains(location.LocationId)
                });
            }
            ViewData["Locations"] = viewModel;
        }

        private void UpdateLocations(string[] selectedLocations, CertificationLine certificationLineToUpdate)
        {
            if (selectedLocations == null)
            {
                certificationLineToUpdate.CertificationInLocations = new List<CertificationInLocation>();
                return;
            }

            var selectedLocationsHashSet = new HashSet<string>(selectedLocations);
            var certificationLineLocations = certificationLineToUpdate.CertificationInLocations == null ? new HashSet<int>() : new HashSet<int>(certificationLineToUpdate.CertificationInLocations.Select(c => c.LocationId));
            foreach (var location in _context.Locations)
            {
                if (selectedLocationsHashSet.Contains(location.LocationId.ToString()))
                {
                    if (!certificationLineLocations.Contains(location.LocationId))
                    {
                        if (certificationLineToUpdate.CertificationInLocations == null)
                        {
                            certificationLineToUpdate.CertificationInLocations = new List<CertificationInLocation>();
                        }
                        certificationLineToUpdate.CertificationInLocations.Add(new CertificationInLocation
                        {
                            CertificationLineId = certificationLineToUpdate.CertificationLineId,
                            LocationId = location.LocationId
                        });
                    }
                }
                else
                {
                    if (certificationLineLocations.Contains(location.LocationId))
                    {
                        CertificationInLocation certLineToRemove = certificationLineToUpdate.CertificationInLocations.FirstOrDefault(a => a.LocationId == location.LocationId);
                        _context.Remove(certLineToRemove);
                    }
                }
            }
        }
    }
}
