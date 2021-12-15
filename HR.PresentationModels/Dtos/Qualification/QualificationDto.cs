using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.PresentationsModel.Dots.Qualification
{
    public class QualificationDto
    {
        public int ID { get; set; }
        [Display(Name = "Qualification")]
        public string Name { get; set; }
       
    }

}