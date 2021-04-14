using System;
using UnsceneTravelApp.Models;

namespace UnsceneTravelApp.ViewModels
{
    public class ActivitiesDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string UrlLocation { get; set; }


        public ActivitiesDetailViewModel(Activities theActivity)
        {
            Name = theActivity.Name;
            Location = theActivity.Location;
            Description = theActivity.Description;
            UrlLocation = theActivity.UrlLocation;
            Id = theActivity.Id;

        }
    }
}