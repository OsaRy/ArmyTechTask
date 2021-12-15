using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.PresentationsModel.Dots.Neighborhood
{
    public class NeighborhoodForCreateDto
    {
        public int ID { get; set; }
        [Display(Name = "Neighborhood")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Governorate")]
        public int GovernorateId { get; set; }

    }
   
}