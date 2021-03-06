using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HR.PresentationsModel.Dots.Qualification;

namespace HR.PresentationsModel.Dots.Employee
{
    public class EmployeeForCreateDto
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Display(Name = "Governorate")]
        [Required]
        

        public int BirthGovernorateId { get; set; }
        [Display(Name = "Neighborhood")]
        [Required]

        public int BirthNeighborhoodId { get; set; }
        [Display(Name = "Career")]
        [Required]

        public int CareerFieldId { get; set; }
        [Display(Name = "Address")]
        [Required]
        [MaxLength(500)]

        public string Address { get; set; }
        [Display(Name = "Company Job")]
        [Required]

        public int CompanyJobId { get; set; }
        [Display(Name = "Qualifications")]
        [Required]

        public int[] QualificationsSelected { get; set; }


    }



}