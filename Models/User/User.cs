using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TimeTracker.Models.App;

namespace TimeTracker.Models.User
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [MinLength(10,ErrorMessage ="Min character required: 10")]
        public string FullName { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Min character required: 10")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="Invalid email format.")]
        public string Email { get; set; }
        public Guid? UserRole_ID { get; set; }


        [ForeignKey(nameof(UserRole_ID))]
        public virtual Role UserRole { get; set; }
        public virtual ICollection<TimeRecord> TimeRecords { get; set; }

        public User(string FullName, string Email)
        {
            this.FullName = FullName;
            this.Email = Email;
        }
    }
}