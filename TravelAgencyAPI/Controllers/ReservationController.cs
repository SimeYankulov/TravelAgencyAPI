﻿using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyAPI.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
