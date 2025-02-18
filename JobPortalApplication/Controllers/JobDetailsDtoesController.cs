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
    public class JobDetailsDtoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobDetailsDtoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobDetailsDtoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobDetails.Include(j => j.EmployerDetails).Include(j => j.JobCategory).Include(j => j.JobType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobDetailsDtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDetailsDto = await _context.JobDetails
                .Include(j => j.EmployerDetails)
                .Include(j => j.JobCategory)
                .Include(j => j.JobType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobDetailsDto == null)
            {
                return NotFound();
            }

            return View(jobDetailsDto);
        }

        // GET: JobDetailsDtoes/Create
        public IActionResult Create()
        {
            ViewData["ComapnayId"] = new SelectList(_context.EmployerDetails, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.JobCategory, "Id", "Name");
            ViewData["JobTypeId"] = new SelectList(_context.JobType, "Id", "Name");
            return View();
        }

        // POST: JobDetailsDtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobTitle,ComapnayId,CategoryId,JobTypeId,VacancyNo,JobLevel,JobLocation,OfferedSalary,DeadLine,EducationLevel,ExperienceRequired,OtherSpecification,JobWorkDescription")] JobDetailsDto jobDetailsDto)
        {
            
                _context.Add(jobDetailsDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: JobDetailsDtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDetailsDto = await _context.JobDetails.FindAsync(id);
            if (jobDetailsDto == null)
            {
                return NotFound();
            }
            ViewData["ComapnayId"] = new SelectList(_context.EmployerDetails, "Id", "Name", jobDetailsDto.ComapnayId);
            ViewData["CategoryId"] = new SelectList(_context.JobCategory, "Id", "Name", jobDetailsDto.CategoryId);
            ViewData["JobTypeId"] = new SelectList(_context.JobType, "Id", "Name", jobDetailsDto.JobTypeId);
            return View(jobDetailsDto);
        }

        // POST: JobDetailsDtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobTitle,ComapnayId,CategoryId,JobTypeId,VacancyNo,JobLevel,JobLocation,OfferedSalary,DeadLine,EducationLevel,ExperienceRequired,OtherSpecification,JobWorkDescription")] JobDetailsDto jobDetailsDto)
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
            ViewData["ComapnayId"] = new SelectList(_context.EmployerDetails, "Id", "Name", jobDetailsDto.ComapnayId);
            ViewData["CategoryId"] = new SelectList(_context.JobCategory, "Id", "Id", jobDetailsDto.CategoryId);
            ViewData["JobTypeId"] = new SelectList(_context.JobType, "Id", "Name", jobDetailsDto.JobTypeId);
            return View(jobDetailsDto);
        }

        // GET: JobDetailsDtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDetailsDto = await _context.JobDetails
                .Include(j => j.EmployerDetails)
                .Include(j => j.JobCategory)
                .Include(j => j.JobType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobDetailsDto == null)
            {
                return NotFound();
            }

            return View(jobDetailsDto);
        }

        // POST: JobDetailsDtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
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
            return _context.JobDetails.Any(e => e.Id == id);
        }
    }
}
