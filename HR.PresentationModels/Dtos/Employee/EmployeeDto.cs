using FluentValidation;
using HR.PresentationsModel.Dots.CareerField;
using HR.PresentationsModel.Dots.CompanyJob;
using HR.PresentationsModel.Dots.Governorate;
using HR.PresentationsModel.Dots.Neighborhood;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.PresentationsModel.Dots.Employee
{
    public class EmployeeDto
    {
        public int ID { get; set; }

        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Display(Name = "Governorate")]

        public int BirthGovernorateId { get; set; }
        [Display(Name = "Neighborhood")]

        public int BirthNeighborhoodId { get; set; }
        [Display(Name = "Career")]

        public int CareerFieldId { get; set; }
        [Display(Name = "Address")]

        public string Address { get; set; }
        [Display(Name = "Company Job")]

        public int CompanyJobId { get; set; }
        public virtual CareerFieldSDto CareerField { get; set; }
        public virtual CompanyJobDto CompanyJob { get; set; }
        public virtual GovernorateDto Governorate { get; set; }
        public virtual NeighborhoodDto Neighborhood { get; set; }
    }
}