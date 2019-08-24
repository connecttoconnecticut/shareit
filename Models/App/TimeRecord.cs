using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TimeTracker.Models.User;

namespace TimeTracker.Models.App
{
    public class TimeRecord
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal DurationInHours { get; set; }
        [Required]
        [MinLength(50, ErrorMessage = "Description needs at least 50 characters.")]
        public string Description { get; set; }

        public int User_ID { get; set; }
        [ForeignKey("User_ID")]
        public virtual User.User User { get; set; }

        public int Task_ID { get; set; }
        [ForeignKey("Task_ID")]
        public virtual Task Task { get; set; }
    }
}