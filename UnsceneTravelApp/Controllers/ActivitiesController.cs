using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnsceneTravelApp.Data;
using UnsceneTravelApp.Models;
using UnsceneTravelApp.ViewModels;

namespace UnsceneTravelApp.Controllers
{
    public class ActivitiesController : Controller
    {
        private ActivitiesDbContext context;

        public ActivitiesController(ActivitiesDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Activities> activities = context.Activities.ToList();

            return View(activities);
        }

        public IActionResult Add()
        {
            AddActivitiesViewModel addActivitiesViewModel = new AddActivitiesViewModel();
            return View(addActivitiesViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddActivitiesViewModel addActivitiesViewModel)
        {
            if (ModelState.IsValid)
            {
                Activities newActivities = new Activities

                {
                    Name = addActivitiesViewModel.Name,
                    Location = addActivitiesViewModel.Location,
                    Description = addActivitiesViewModel.Description
                };

                context.Activities.Add(newActivities);
                context.SaveChanges();

                return Redirect("/Activities");
            }
            return View(addActivitiesViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.activities = context.Activities.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] activitiesIds)
        { 
            foreach (int activitiesId in activitiesIds)
        {
            Activities theActivity = context.Activities.Find(activitiesId);
            context.Activities.Remove(theActivity);
        }
            context.SaveChanges();

            return Redirect("/Activities");
    }
    }
}