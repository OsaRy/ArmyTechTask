using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.PresentationsModel.Dots.CareerField
{
    public class CareerFieldSDto
    {
        public int ID { get; set; }
        [Display(Name = "job")]
        public string Name { get; set; }
       
    }

}