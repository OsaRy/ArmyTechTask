using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.PresentationsModel.Dots.Neighborhood
{
    public class NeighborhoodForUpdateDto
    {
        public int ID { get; set; }
        [Display(Name = "Neighborhood")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Governorate")]
        [Required]

        public int GovernorateId { get; set; }

    }
 
}