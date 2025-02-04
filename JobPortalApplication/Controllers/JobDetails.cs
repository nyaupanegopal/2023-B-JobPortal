using JobPortalApplication.Data;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobPortalApplication.Controllers
{
    public class JobDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public JobDetailsController(ApplicationDbContext context)
        {
            _context = context; 
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(JobDetailsDto model) 
        {
            var listdata=_context.JobDetails.ToList();
            model.District = "test";
            model.Municipality = "test";
            _context.JobDetails.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var listdata=_context.JobDetails.ToList();
            return View(listdata);
        }
        public ActionResult Delete(int id) {
         var dataToDelete=_context.JobDetails.Where(x => x.Id == id).FirstOrDefault();
            _context.JobDetails.Remove(dataToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id) {
            var data=_context.JobDetails.Where(x=>x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(JobDetailsDto editedData)
        {
            _context.JobDetails.Update(editedData);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var jobDetail = _context.JobDetails.Where(x => x.Id==id).FirstOrDefault();
            return View(jobDetail);
        }

    }
}
