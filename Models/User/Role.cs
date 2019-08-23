using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TimeTracker.Models.App;

namespace TimeTracker.Models.User
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min character required: 3")]
        public string Name { get; set; }

        public virtual ICollection<User> UsersWithRole { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}