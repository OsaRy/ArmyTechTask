using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.PresentationsModel.Dots.CompanyJob
{
    public class CompanyJobDto
    {
        public int ID { get; set; }
        [Display(Name = "Position")]
        public string Name { get; set; }
        [Display(Name = "Job Arrangement")]

        public int JobArrangement { get; set; }


    }

}