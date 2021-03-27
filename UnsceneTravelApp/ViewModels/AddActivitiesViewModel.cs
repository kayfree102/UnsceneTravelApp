using System;
using System.ComponentModel.DataAnnotations;
namespace UnsceneTravelApp.ViewModels


{
    public class AddActivitiesViewModel
    {
        [Required(ErrorMessage = "Name of Activity required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Location is required")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Description required")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Add URL map location here")]
    public string UrlLocation { get; set; }

        public AddActivitiesViewModel(string name, string location, string description, string urlLocation)
    {
        Name = name;
        Location = location;
        Description = description;
        UrlLocation = urlLocation;

    }
    public AddActivitiesViewModel() { }
    }

}