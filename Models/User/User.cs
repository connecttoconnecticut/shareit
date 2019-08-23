using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TimeTracker.Models.App;

namespace TimeTracker.Models.User
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MinLength(10,ErrorMessage ="Min character required: 10")]
        public string FullName { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Min character required: 10")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="Invalid email format.")]
        public string Email { get; set; }

        public Role UserRole { get; set; }
        public ICollection<TimeRecord> TimeRecords { get; set; }
    }
}