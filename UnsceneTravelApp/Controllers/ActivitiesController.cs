using System;
using Microsoft.AspNetCore.Mvc;
namespace UnsceneTravelApp.Controllers
{
    public class ActivitiesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}