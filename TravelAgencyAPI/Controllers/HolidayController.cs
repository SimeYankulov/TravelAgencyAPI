using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyAPI.Controllers
{
    public class HolidayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
