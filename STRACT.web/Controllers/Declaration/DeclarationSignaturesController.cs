using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STRACT.Data.Identity;
using STRACT.Entities.Declaration;

namespace STRACT.web.Controllers.Declaration
{
    public class DeclarationSignaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeclarationSignaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeclarationSignatures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeclarationSignatures.Include(d => d.Declaration).Include(d => d.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeclarationSignatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationSignature = await _context.DeclarationSignatures
                .Include(d => d.Declaration)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DeclarationItemId == id);
            if (declarationSignature == null)
            {
                return NotFound();
            }

            return View(declarationSignature);
        }

        // GET: DeclarationSignatures/Create
        public IActionResult Create()
        {
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId");
            ViewData["UserId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId");
            return View();
        }

        // POST: DeclarationSignatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SignatureId,DateSigned,DeclarationItemId,UserId")] DeclarationSignature declarationSignature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(declarationSignature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId", declarationSignature.DeclarationItemId);
            ViewData["UserId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId", declarationSignature.UserId);
            return View(declarationSignature);
        }

        // GET: DeclarationSignatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationSignature = await _context.DeclarationSignatures.FindAsync(id);
            if (declarationSignature == null)
            {
                return NotFound();
            }
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId", declarationSignature.DeclarationItemId);
            ViewData["UserId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId", declarationSignature.UserId);
            return View(declarationSignature);
        }

        // POST: DeclarationSignatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("SignatureId,DateSigned,DeclarationItemId,UserId")] DeclarationSignature declarationSignature)
        {
            if (id != declarationSignature.DeclarationItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(declarationSignature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeclarationSignatureExists(declarationSignature.DeclarationItemId))
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
            ViewData["DeclarationItemId"] = new SelectList(_context.Declarations, "DeclarationItemId", "DeclarationItemId", declarationSignature.DeclarationItemId);
            ViewData["UserId"] = new SelectList(_context.UserInTeam, "UserInTeamId", "UserInTeamId", declarationSignature.UserId);
            return View(declarationSignature);
        }

        // GET: DeclarationSignatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declarationSignature = await _context.DeclarationSignatures
                .Include(d => d.Declaration)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DeclarationItemId == id);
            if (declarationSignature == null)
            {
                return NotFound();
            }

            return View(declarationSignature);
        }

        // POST: DeclarationSignatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var declarationSignature = await _context.DeclarationSignatures.FindAsync(id);
            _context.DeclarationSignatures.Remove(declarationSignature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeclarationSignatureExists(int? id)
        {
            return _context.DeclarationSignatures.Any(e => e.DeclarationItemId == id);
        }
    }
}
