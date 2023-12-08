using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Domain
{
    public class AppDbContext :DbContext
    {
        public AppDbContext() :base()
        {            
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Office> Offices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-J8JKVLG;Initial Catalog=OfficeRental; Persist Security Info = False; Trusted_Connection=yes; ");
        }

    }
}
