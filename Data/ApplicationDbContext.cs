using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using STLSplash2019.Models;

namespace STLSplash2019.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet<LocationCategory> LocationCategories { get; set; }
        public DbSet<LocationRating> LocationRatings { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
