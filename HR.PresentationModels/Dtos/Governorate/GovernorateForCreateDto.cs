using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.PresentationsModel.Dots.Governorate
{
    public class GovernorateForCreateDto
    {
        public int ID { get; set; }
        [Display(Name = "Governorate")]
        [Required]
        public string Name { get; set; }
    }
 
}