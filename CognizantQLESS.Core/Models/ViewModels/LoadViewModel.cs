using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CognizantQLESS.Core.Models.ViewModels
{
    public class LoadViewModel
    {
        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        
        [Required]
        [Range(100,10000)]
        public short Amount { get; set; }

        [Required]
        public short Cash { get; set; }

        public float Change
        {
            get { return (float)Cash - Amount; }
        }

        public bool IsCashAmountValid
        {
            get { return (Cash >= Amount); }
        }

        public bool IsAmountValid
        {
            get { return (Amount >= 100 && Amount <= 10000); }
        }
    }
}
