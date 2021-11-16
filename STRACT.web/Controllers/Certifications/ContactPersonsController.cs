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
    public class ContactPersonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactPersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactPersons
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ContactPeople
                .Include(c => c.Entity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ContactPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPerson = await _context.ContactPeople
                .Include(c => c.Entity)
                .FirstOrDefaultAsync(m => m.ContactPersonId == id);
            if (contactPerson == null)
            {
                return NotFound();
            }

            return View(contactPerson);
        }

        // GET: ContactPersons/Create
        public IActionResult Create()
        {
            PopulateEntitiesDropDownList();
            return View();
        }

        // POST: ContactPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactPersonId,Name,PhoneNumber,IsMainContact,EntityId")] ContactPerson contactPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateEntitiesDropDownList(contactPerson.EntityId);
            return View(contactPerson);
        }

        // GET: ContactPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPerson = await _context.ContactPeople.FindAsync(id);
            if (contactPerson == null)
            {
                return NotFound();
            }
            PopulateEntitiesDropDownList(contactPerson.EntityId);
            return View(contactPerson);
        }

        // POST: ContactPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactPersonId,Name,PhoneNumber,IsMainContact,EntityId")] ContactPerson contactPerson)
        {
            if (id != contactPerson.ContactPersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactPersonExists(contactPerson.ContactPersonId))
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
            PopulateEntitiesDropDownList(contactPerson.EntityId);
            return View(contactPerson);
        }

        // GET: ContactPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPerson = await _context.ContactPeople
                .Include(c => c.Entity)
                .FirstOrDefaultAsync(m => m.ContactPersonId == id);
            if (contactPerson == null)
            {
                return NotFound();
            }

            return View(contactPerson);
        }

        // POST: ContactPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactPerson = await _context.ContactPeople.FindAsync(id);
            _context.ContactPeople.Remove(contactPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactPersonExists(int id)
        {
            return _context.ContactPeople.Any(e => e.ContactPersonId == id);
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
    }
}
