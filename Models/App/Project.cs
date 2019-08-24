using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TimeTracker.Models.App
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min character required: 3")]
        public string Name { get; set; }
        //can not be null but can be empty string
        [System.ComponentModel.DefaultValue("")]
        public string Description { get; set; }
        public virtual ICollection<Task> ProjectTasks { get; set; }
    }
}