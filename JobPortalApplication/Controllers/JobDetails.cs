using JobPortalApplication.Data; // Importing the application's database context
using JobPortalApplication.Models; // Importing the application's models
using JobPortalApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; // Importing ASP.NET Core MVC functionalities
using System.ComponentModel.DataAnnotations; // Importing validation attributes

namespace JobPortalApplication.Controllers
{
    /// <summary>
    /// Controller to handle CRUD operations for Job Details
    /// </summary>
    public class JobDetailsController : Controller
    {
        private readonly UserManagementService _userManagementService;
        private readonly ApplicationDbContext _context; // Database context to interact with the database

        /// <summary>
        /// Constructor to initialize the database context
        /// </summary>
        /// <param name="context">Application database context</param>
        public JobDetailsController(ApplicationDbContext context, UserManagementService ser
            )
        {
            _context = context;
            _userManagementService = ser;
        }

        /// <summary>
        /// Displays the form to create a new job detail
        /// </summary>
        /// <returns>View for job detail creation</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Handles form submission to create a new job detail
        /// </summary>
        /// <param name="model">Job details data from the form</param>
        /// <returns>Redirects to the Index action after saving</returns>
        [HttpPost]
        public IActionResult Create(JobDetailsDto model)
        {
            var listdata = _context.JobDetails.ToList(); // Fetches all job details (unused in this method)

            // Assigning default values for testing purposes
            model.District = "test";
            model.Municipality = "test";

            _context.JobDetails.Add(model); // Adds the new job detail record to the database
            _context.SaveChanges(); // Saves changes to the database
            return RedirectToAction("Index"); // Redirects to the Index page
        }

        /// <summary>
        /// Displays a list of all job details
        /// </summary>
        /// <returns>View with a list of job details</returns>
        /// 
        [AllowAnonymous]
        public IActionResult Index()
        {
            var listrole = _userManagementService.GetAllRolesAsync();
            var listdata = _context.JobDetails.ToList(); // Retrieves all job details from the database
            return View(listdata); // Passes data to the view
        }

        /// <summary>
        /// Deletes a specific job detail record based on ID
        /// </summary>
        /// <param name="id">ID of the job detail to be deleted</param>
        /// <returns>Redirects to the Index action</returns>
        public ActionResult Delete(int id)
        {
            var dataToDelete = _context.JobDetails.Where(x => x.Id == id).FirstOrDefault(); // Finds the record to delete
            if (dataToDelete != null)
            {
                _context.JobDetails.Remove(dataToDelete); // Removes the record from the database
                _context.SaveChanges(); // Saves changes to the database
            }
            return RedirectToAction("Index"); // Redirects to the Index page
        }

        /// <summary>
        /// Displays the edit form for a specific job detail
        /// </summary>
        /// <param name="id">ID of the job detail to be edited</param>
        /// <returns>View with job detail data</returns>
        public IActionResult Edit(int id)
        {
            var data = _context.JobDetails.Where(x => x.Id == id).FirstOrDefault(); // Fetches the job detail based on ID
            return View(data); // Passes data to the edit view
        }

        /// <summary>
        /// Handles form submission to update an existing job detail
        /// </summary>
        /// <param name="editedData">Updated job detail data</param>
        /// <returns>Redirects to the Index action after saving</returns>
        [HttpPost]
        public IActionResult Edit(JobDetailsDto editedData)
        {
            _context.JobDetails.Update(editedData); // Updates the existing job detail record
            _context.SaveChanges(); // Saves changes to the database
            return RedirectToAction("Index"); // Redirects to the Index page
        }

        /// <summary>
        /// Displays the details of a specific job
        /// </summary>
        /// <param name="id">ID of the job detail</param>
        /// <returns>View with job detail data</returns>
        public IActionResult Details(int id)
        {
            var jobDetail = _context.JobDetails.Where(x => x.Id == id).FirstOrDefault(); // Fetches job details based on ID
            return View(jobDetail); // Passes data to the details view
        }
    }
}
