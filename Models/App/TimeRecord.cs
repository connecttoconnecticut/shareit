using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.Models.App
{
    public class TimeRecord
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal DurationInHours { get; set; }

        public string Description { get; set; }
    }
}