using System;
using Microsoft.EntityFrameworkCore;
using UnsceneTravelApp.Models;
namespace UnsceneTravelApp.Data
{
    public class ActivitiesDbContext : DbContext
    {
        public DbSet<Activities> Activities { get; set; }

        public ActivitiesDbContext(DbContextOptions<ActivitiesDbContext> options): base(options)
        {

        }
    }
}
