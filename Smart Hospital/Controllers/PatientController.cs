using Microsoft.AspNetCore.Mvc;

namespace Smart_Hospital.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

    }
}
