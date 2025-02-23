using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortalApplication.Data;
using JobPortalApplication.Models;
using NuGet.Packaging;

namespace JobPortalApplication.Controllers
{
    public class EducationalQualificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationalQualificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EducationalQualifications
        public async Task<IActionResult> Index()
        {
            return View(await _context.EducationalQualification.ToListAsync());
        }

        // GET: EducationalQualifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalQualification = await _context.EducationalQualification
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationalQualification == null)
            {
                return NotFound();
            }

            return View(educationalQualification);
        }

        // GET: EducationalQualifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationalQualifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Level,Board")] EducationalQualification educationalQualification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationalQualification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationalQualification);
        }

        // GET: EducationalQualifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalQualification = await _context.EducationalQualification.FindAsync(id);
            if (educationalQualification == null)
            {
                return NotFound();
            }
            return View(educationalQualification);
        }

        // POST: EducationalQualifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Level,Board")] EducationalQualification educationalQualification)
        {
            if (id != educationalQualification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationalQualification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationalQualificationExists(educationalQualification.Id))
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
            return View(educationalQualification);
        }

        // GET: EducationalQualifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalQualification = await _context.EducationalQualification
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationalQualification == null)
            {
                return NotFound();
            }

            return View(educationalQualification);
        }

        // POST: EducationalQualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationalQualification = await _context.EducationalQualification.FindAsync(id);
            if (educationalQualification != null)
            {
                _context.EducationalQualification.Remove(educationalQualification);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationalQualificationExists(int id)
        {
            return _context.EducationalQualification.Any(e => e.Id == id);
        }
    }
}
