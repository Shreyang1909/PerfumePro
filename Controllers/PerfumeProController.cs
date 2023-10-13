using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace PerfumePro.Controllers
{
    public class PerfumeProController : Controller
    {
        // 
        // GET: /PerefumePro/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /PerfumePro/Welcome/ 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}