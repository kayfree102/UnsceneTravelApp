using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnsceneTravelApp.Models;
namespace UnsceneTravelApp.Data
{
    public class ActivitiesDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Activities> Activities { get; set; }

        public ActivitiesDbContext(DbContextOptions<ActivitiesDbContext> options): base(options)
        {

        }

    }
}
