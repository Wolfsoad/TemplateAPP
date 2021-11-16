using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.Certifications;
using STRACT.web.Models.Certifications;

namespace STRACT.web.Controllers.Certifications
{
    public class CertificatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Certificates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Certificates.Include(c => c.CertificationLine);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Certificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificates
                .Include(c => c.CertificationLine)
                .FirstOrDefaultAsync(m => m.CertificateId == id);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // GET: Certificates/Create
        public IActionResult Create()
        {
            PopulateAssignedLinesOfProductsData(new Certificate { });
            PopulateCertificationLinesDropDownList();
            return View();
        }

        // POST: Certificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CertificateId,Description,Number,EmissionDate,ValidUntil,CertificateUrl,CertificationLineId")] Certificate certificate, string[] selectedLinesOfProducts)
        {
            if (ModelState.IsValid)
            {
                UpdateLinesOfProducts(selectedLinesOfProducts, certificate);
                _context.Add(certificate);
                await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedLinesOfProductsData(certificate);
            PopulateCertificationLinesDropDownList(certificate.CertificationLineId);
            return View(certificate);
        }

        // GET: Certificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificates
                .Include(c => c.CertificateProductLines)
                    .ThenInclude(c => c.LineOfProduct)
                    .FirstOrDefaultAsync(m => m.CertificateId == id);
            if (certificate == null)
            {
                return NotFound();
            }
            PopulateAssignedLinesOfProductsData(certificate);
            PopulateCertificationLinesDropDownList(certificate.CertificationLineId);
            return View(certificate);
        }

        // POST: Certificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CertificateId,Description,Number,EmissionDate,ValidUntil,CertificateUrl,CertificationLineId")] Certificate certificate, string[] selectedLinesOfProducts)
        {
            if (id != certificate.CertificateId)
            {
                return NotFound();
            }

            var certificateToUpdate = await _context.Certificates
                .Include(c => c.CertificateProductLines)
                    .ThenInclude(c => c.LineOfProduct)
                .FirstOrDefaultAsync(m => m.CertificateId == id);

            if (await TryUpdateModelAsync<Certificate>(certificateToUpdate, "", i => i.CertificateId, i => i.Description))
            {
                UpdateLinesOfProducts(selectedLinesOfProducts, certificateToUpdate);
                try
                {
                    var old = await _context.Certificates.FindAsync(id);
                    _context.Entry(old).CurrentValues.SetValues(certificateToUpdate);
                    await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificateExists(certificate.CertificateId))
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
            UpdateLinesOfProducts(selectedLinesOfProducts, certificate);
            PopulateAssignedLinesOfProductsData(certificate);
            PopulateCertificationLinesDropDownList(certificate.CertificationLineId);
            return View(certificate);
        }

        // GET: Certificates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificates
                .Include(c => c.CertificationLine)
                .FirstOrDefaultAsync(m => m.CertificateId == id);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // POST: Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificate = await _context.Certificates
                .Include(c => c.CertificateProductLines)
                    .ThenInclude(c => c.LineOfProduct)
                .FirstOrDefaultAsync(m => m.CertificateId == id);
            _context.Certificates.Remove(certificate);
            await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return RedirectToAction(nameof(Index));
        }

        private bool CertificateExists(int id)
        {
            return _context.Certificates.Any(e => e.CertificateId == id);
        }

        private void PopulateCertificationLinesDropDownList(object selectedCertificationLine = null)
        {
            var query = from sg in _context.CertificationLines
                        orderby sg.Description
                        select new
                        {
                            CertificationLineId = sg.CertificationLineId,
                            Description = string.Format("{0}", sg.Description)
                        };
            ViewBag.CertificationLineId = new SelectList(query.AsTracking(), "CertificationLineId", "Description", selectedCertificationLine);
        }

        private void PopulateAssignedLinesOfProductsData(Certificate certificate)
        {
            var allLinesOfProducts = _context.LinesOfProducts;
            var linesOfProducts = certificate.CertificateProductLines == null ? new HashSet<int>() : new HashSet<int>(certificate.CertificateProductLines.Select(c => c.ProductLineId));
            var viewModel = new List<AssignedProductLine>();
            foreach (var lineOfProduct in allLinesOfProducts)
            {
                viewModel.Add(new AssignedProductLine
                {
                    ProductLineId = lineOfProduct.LineOfProductId,
                    Name = lineOfProduct.Description,
                    Assigned = linesOfProducts.Contains(lineOfProduct.LineOfProductId)
                });
            }
            ViewData["LinesOfProducts"] = viewModel;
        }

        private void UpdateLinesOfProducts(string[] selectedLinesOfProducts, Certificate certificateToUpdate)
        {
            if (selectedLinesOfProducts == null)
            {
                certificateToUpdate.CertificateProductLines = new List<CertificateProductLine>();
                return;
            }

            var selectedProductLines = new HashSet<string>(selectedLinesOfProducts);
            var certificateProductLines = certificateToUpdate.CertificateProductLines == null ? new HashSet<int>() : new HashSet<int>(certificateToUpdate.CertificateProductLines.Select(c => c.ProductLineId));
            foreach (var productLine in _context.LinesOfProducts)
            {
                if (selectedProductLines.Contains(productLine.LineOfProductId.ToString()))
                {
                    if (!certificateProductLines.Contains(productLine.LineOfProductId))
                    {
                        if (certificateToUpdate.CertificateProductLines == null)
                        {
                            certificateToUpdate.CertificateProductLines = new List<CertificateProductLine>();
                        }
                        certificateToUpdate.CertificateProductLines.Add(new CertificateProductLine
                        {
                            CertificateId = certificateToUpdate.CertificateId,
                            ProductLineId = productLine.LineOfProductId
                        });
                    }
                }
                else
                {
                    if (certificateProductLines.Contains(productLine.LineOfProductId))
                    {
                        CertificateProductLine productLineToRemove = certificateToUpdate.CertificateProductLines.FirstOrDefault(a => a.ProductLineId == productLine.LineOfProductId);
                        _context.Remove(productLineToRemove);
                    }
                }
            }
        }
    }
}
