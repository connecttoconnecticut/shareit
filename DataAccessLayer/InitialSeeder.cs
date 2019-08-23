using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.DataAccessLayer
{
    public class InitialSeeder : System.Data.Entity.DropCreateDatabaseIfModelChanges<TimeTrackerDBContext>
    {
        protected override void Seed(TimeTrackerDBContext context)
        {
            base.Seed(context);
        }
    }
}