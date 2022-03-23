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
    }
}