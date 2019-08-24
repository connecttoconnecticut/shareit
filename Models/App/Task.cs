using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TimeTracker.Models.User;

namespace TimeTracker.Models.App
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min character required: 3")]
        public string Name { get; set; }
        [System.ComponentModel.DefaultValue("")]
        public string Description { get; set; }
        [Required]
        //custom to 2 decimal
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal TimeEstimateInHours { get; set; }

        
        public Guid Project_ID { get; set; }
        public Guid Role_ID { get; set; }


        [ForeignKey("Project_ID")]
        public virtual Project Project { get; set; }
        [ForeignKey("Role_ID")]
        public virtual Role Role { get; set; }
        public virtual ICollection<TimeRecord> TimeRecords { get; set; }
    }
}