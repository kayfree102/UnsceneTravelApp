﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private IAuthorizationService authorizationService;
        private UserManager<IdentityUser> userManager;

        public ActivitiesController(ActivitiesDbContext dbContext, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base()
        {
            context = dbContext;
            this.authorizationService = authorizationService;
            this.userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            List<Activities> activities = context.Activities.ToList();
                

            return View(activities);
        }
        [Authorize]
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
                var currentUserId = userManager.GetUserId(User);
                Activities newActivities = new Activities

                {
                    Name = addActivitiesViewModel.Name,
                    Location = addActivitiesViewModel.Location,
                    Description = addActivitiesViewModel.Description,
                    UrlLocation = addActivitiesViewModel.UrlLocation,
                    UserId = currentUserId
                };

                context.Activities.Add(newActivities);
                context.SaveChanges();

                return Redirect("/Activities");
            }
            return View(addActivitiesViewModel);
        }
        [Authorize]
        public IActionResult Delete()
        {
            var currentUserId = userManager.GetUserId(User);
            ViewBag.activities = context.Activities
                .Where(e => e.UserId == currentUserId)
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] activitiesIds)
        { 
            foreach (int userId in activitiesIds)
        {
                var currentUserId = userManager.GetUserId(User);
                Activities theActivity = context.Activities.Find(userId);
            context.Activities.Remove(theActivity);
        }
            context.SaveChanges();

            return Redirect("/Activities");
    }
    }
}