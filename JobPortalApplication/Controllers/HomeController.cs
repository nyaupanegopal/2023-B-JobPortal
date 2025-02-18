using JobPortalApplication.Data;
using JobPortalApplication.Models;
using JobPortalApplication.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JobPortalApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Query the database to get job vacancies and related employer data
            var jobVacancies = _context.JobDetails
                .Include(j => j.EmployerDetails)   // Include related EmployerDetails
                .Include(j => j.JobCategory)      // Include related JobCategory
                .Include(j => j.JobType)          // Include related JobType
                .Select(j => new JobVacancyList
                {
                    VacancyNo = j.VacancyNo,
                    Title = j.JobTitle,
                    Description = j.JobWorkDescription,
                    Company = j.EmployerDetails.Name,  // Assuming EmployerDetails has CompanyName property
                    Type = j.JobType.Name,            // Assuming JobType has JobTypeName property
                    DeadLine = j.DeadLine,   // Convert DeadLine from string to DateTime (apply after query execution)
                    Location = j.JobLocation,
                    Salary = decimal.Parse(j.OfferedSalary), // Convert OfferedSalary from string to decimal
                    Status = j.DeadLine>DateTime.Now?"Open":"Closed",                      // Assuming JobLevel represents the status
                })
                .ToList();

            // Now, create the DashboardViewModel and populate it
            if (jobVacancies.Count>0)
            {
                var dashboardViewModel = new DashboardViewModel
                {
                    TotalEmployer = _context.EmployerDetails.Count(),  // Assuming EmployerDetails table contains employers
                    TotalJobPost = _context.JobDetails.Count(),    // Assuming JobDetailsDto is where job posts are stored
                    MonthlyJobPost = _context.JobDetails
                        .Where(j => j.DeadLine != null && j.DeadLine.Month == DateTime.Now.Month)
                        .Count(),  // Count jobs posted this month
                    JobVacancyList = jobVacancies  // Assign the fetched job vacancies
                };
                return View(dashboardViewModel);
            }
            else return View(new DashboardViewModel());  // Return the view with an empty DashboardViewModel

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}