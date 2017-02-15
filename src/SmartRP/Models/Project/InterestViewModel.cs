using SmartRP.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SmartRP.Models
{
    public class InterestViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Interest Status")]
        public string Status { get; set; }

        public int StudentId { get; set; }
        public int SupervisorId { get; set; }

 
    }
}