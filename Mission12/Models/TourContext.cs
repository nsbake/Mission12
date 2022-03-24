using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mission12.Models
{
    public partial class TourContext : DbContext
    {
        public TourContext()
        {
        }

        public TourContext(DbContextOptions<TourContext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Tour>().HasData(
                new Tour
                {
                    /*favorite movie of all time, felt necessary to comment this*/
                    Id = 1,
                    Date = "08/08/08",
                    Time = 12,
                    Name = "Barnabus",
                    Size = 6,
                    Email = "floob@icon.com",
                    PhoneNumber = "615-616-6176"
                }
            );
        }
    }
}