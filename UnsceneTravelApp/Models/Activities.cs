using System;
namespace UnsceneTravelApp.Models
{
    public class Activities
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public int Id { get; set; }

        public Activities()
        {
        }

        public Activities(string name, string location, string description)
        {
            Name = name;
            Location = location;
            Description = description;
        }
    }
}
