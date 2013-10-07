using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskApp.View.Models
{
    public class TaskModel
    {
        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Notes")]
        public string notes { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }

        [Display(Name = "Priority")]
        [Required]
        public int priority { get; set; }        

        [Display(Name = "Due Date")]
        [Required]
        public System.DateTime dueDate { get; set; }

        [Display(Name = "Due Date")]
        [Required]
        public System.DateTime dateCreated { get; set; }

        [Display(Name = "Estimated Time")]
        [Required]
        public int time { get; set; }

        [Display(Name = "Estimated Time Unit")]
        [Required]
        public string type { get; set; }

    }

}