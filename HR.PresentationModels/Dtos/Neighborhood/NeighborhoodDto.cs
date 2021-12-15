using FluentValidation;
using HR.PresentationsModel.Dots.Governorate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.PresentationsModel.Dots.Neighborhood
{
    public class NeighborhoodDto
    {
        public int ID { get; set; }
        [Display(Name = "Neighborhood")]
        public string Name { get; set; }
        [Display(Name = "Governorate")]
        public int GovernorateId { get; set; }
        public virtual GovernorateDto Governorate { get; set; }


    }

}