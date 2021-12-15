using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.PresentationsModel.Dots.Employee
{
    public class EmployeeForUpdateDto
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]

        public string Name { get; set; }
        [Required]

        public int BirthGovernorateId { get; set; }
        [Required]

        public int BirthNeighborhoodId { get; set; }
        [Required]

        public int CareerFieldId { get; set; }
        [Required]
        [MaxLength(500)]

        public string Address { get; set; }
        [Required]

        public int CompanyJobId { get; set; }
        [Required]

        public int[] QualificationsSelected { get; set; }



    }
}