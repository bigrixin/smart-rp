using SmartRP.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SmartRP.Models
{
    public class ProjectViewModel
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

        [Display(Name = "Project Status")]
        public string Status { get; set; }
        [Display(Name = "Project Type")]
        public string Type { get; set; }
        [Display(Name = "Approved Number")]
        public string ApprovedNumber { get; set; }
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Team Size")]
        public int TeamSize { get; set; }

        public int SupervisorId { get; set; }

        [Required]
        [Display(Name = "Expire Date")]
        public DateTime? ExpiredAt { get; set; }

        public IEnumerable<SelectListItem> StatusList { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }
    }
}