using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TimeTracker.Models.App;
using TimeTracker.Models.User;

namespace TimeTracker.DataAccessLayer
{
    public class TimeTrackerDBContext : DbContext
    {
        //connection string
        public TimeTrackerDBContext() : base("TimeTrackerDBContext")
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TimeRecord> TimeRecords { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}