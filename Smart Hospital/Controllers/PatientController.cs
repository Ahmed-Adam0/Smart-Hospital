using Microsoft.AspNetCore.Mvc;
using Smart_Hospital.Data;
using Smart_Hospital.Models;

namespace Smart_Hospital.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext context;

        public PatientController(ApplicationDbContext applicationDbContext)
        {
            this.context = applicationDbContext;
        }
        public IActionResult Index()
        { 
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
                return View(patient);

            context.patients.Add(patient);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
