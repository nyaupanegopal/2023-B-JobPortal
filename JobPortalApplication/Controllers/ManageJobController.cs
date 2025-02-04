using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortalApplication.Data;
using JobPortalApplication.Models;

namespace JobPortalApplication.Controllers
{
    public class ManageJobController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageJobController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ManageJob
        public async Task<IActionResult> Index()
        {
              return _context.JobDetails != null ? 
                          View(await _context.JobDetails.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.JobDetails'  is null.");
        }

        // GET: ManageJob/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JobDetails == null)
            {
                return NotFound();
            }

            var jobDetailsDto = await _context.JobDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobDetailsDto == null)
            {
                return NotFound();
            }

            return View(jobDetailsDto);
        }

        // GET: ManageJob/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageJob/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Province,District,Municipality")] JobDetailsDto jobDetailsDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobDetailsDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobDetailsDto);
        }

        // GET: ManageJob/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JobDetails == null)
            {
                return NotFound();
            }

            var jobDetailsDto = await _context.JobDetails.FindAsync(id);
            if (jobDetailsDto == null)
            {
                return NotFound();
            }
            return View(jobDetailsDto);
        }

        // POST: ManageJob/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,Province,District,Municipality")] JobDetailsDto jobDetailsDto)
        {
            if (id != jobDetailsDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobDetailsDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobDetailsDtoExists(jobDetailsDto.Id))
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
            return View(jobDetailsDto);
        }

        // GET: ManageJob/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JobDetails == null)
            {
                return NotFound();
            }

            var jobDetailsDto = await _context.JobDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobDetailsDto == null)
            {
                return NotFound();
            }

            return View(jobDetailsDto);
        }

        // POST: ManageJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JobDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.JobDetails'  is null.");
            }
            var jobDetailsDto = await _context.JobDetails.FindAsync(id);
            if (jobDetailsDto != null)
            {
                _context.JobDetails.Remove(jobDetailsDto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobDetailsDtoExists(int id)
        {
          return (_context.JobDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
