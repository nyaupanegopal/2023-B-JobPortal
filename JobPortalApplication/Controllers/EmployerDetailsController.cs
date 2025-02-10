using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortalApplication.Data;
using JobPortalApplication.Models;
using JobPortalApplication.Services;

namespace JobPortalApplication.Controllers
{
    public class EmployerDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManagementService _userManagementService;

        public EmployerDetailsController(ApplicationDbContext context, UserManagementService userManagementService)
        {
            _context = context;
            _userManagementService = userManagementService;
        }

        // GET: EmployerDetails
        public async Task<IActionResult> Index()
        {
              return _context.EmployerDetails != null ? 
                          View(await _context.EmployerDetails.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.EmployerDetails'  is null.");
        }

        // GET: EmployerDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployerDetails == null)
            {
                return NotFound();
            }

            var employerDetails = await _context.EmployerDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employerDetails == null)
            {
                return NotFound();
            }

            return View(employerDetails);
        }

        // GET: EmployerDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployerDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phone,PrimaryContactPerson,UserId")] EmployerDetails employerDetails)
        {
            if (ModelState.IsValid)
            {
                var userCreation =await _userManagementService.CreateUserAsync("goapl@123.com", "Nepal@123");
                if (userCreation == true)
                {
                    _context.Add(employerDetails);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employerDetails);
        }

        // GET: EmployerDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployerDetails == null)
            {
                return NotFound();
            }

            var employerDetails = await _context.EmployerDetails.FindAsync(id);
            if (employerDetails == null)
            {
                return NotFound();
            }
            return View(employerDetails);
        }

        // POST: EmployerDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phone,PrimaryContactPerson,UserId")] EmployerDetails employerDetails)
        {
            if (id != employerDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employerDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployerDetailsExists(employerDetails.Id))
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
            return View(employerDetails);
        }

        // GET: EmployerDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployerDetails == null)
            {
                return NotFound();
            }

            var employerDetails = await _context.EmployerDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employerDetails == null)
            {
                return NotFound();
            }

            return View(employerDetails);
        }

        // POST: EmployerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployerDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EmployerDetails'  is null.");
            }
            var employerDetails = await _context.EmployerDetails.FindAsync(id);
            if (employerDetails != null)
            {
                _context.EmployerDetails.Remove(employerDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployerDetailsExists(int id)
        {
          return (_context.EmployerDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
