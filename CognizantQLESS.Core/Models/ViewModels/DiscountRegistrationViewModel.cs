using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CognizantQLESS.Core.Models.ViewModels
{
    public class DiscountRegistrationViewModel
    {
        public DiscountRegistrationViewModel()
        {

        }

        [MinLength(10)]
        [StringLength(10)]
        [Display(Name = "Senior Citizen Control Number")]
        public string SeniorCitizenControlNumber { get; set; }

        [MinLength(12)]
        [StringLength(12)]
        [Display(Name = "PWD ID Number")]
        public string PWDIdNumber { get; set; }

        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
    }
}
