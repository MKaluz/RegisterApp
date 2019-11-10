using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectApi.Helpers
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions options) :base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<VisitDate> VisitDates { get; set; }
        public DbSet<VisitLocation> VisitLocations { get; set; }
        public DbSet<VisitType> VisitTypes { get; set; }

    }
}
