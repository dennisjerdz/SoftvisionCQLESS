using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CognizantQLESS.Core.Models
{
    public class TransportCard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransportCardId { get; set; }
        public float Load { get; set; }
        [Required]
        [Display(Name ="Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Discount Registration Date")]
        public DateTime? DiscountRegistrationDate { get; set; }
        public DateTime? LastUsedDate { get; set; }

        [StringLength(10)]
        [Display(Name = "Senior Citizen Control Number")]
        public string SeniorCitizenControlNumber { get; set; }

        [StringLength(12)]
        [Display(Name = "PWD ID Number")]
        public string PWDIdNumber { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        #region Unmapped Members

        [NotMapped]
        public string FormattedSeniorCitizenControlNumber
        {
            get
            {
                return (SeniorCitizenControlNumber != null)
                    ? $"{SeniorCitizenControlNumber.Substring(0,2)}-{SeniorCitizenControlNumber.Substring(2,4)}-{SeniorCitizenControlNumber.Substring(6, 4)}"
                    : null;
            }
        }

        [NotMapped]
        public string FormattedPWDIdNumber
        {
            get
            {
                return (PWDIdNumber != null)
                    ? $"{PWDIdNumber.Substring(0, 4)}-{PWDIdNumber.Substring(4, 4)}-{PWDIdNumber.Substring(8, 4)}"
                    : null;
            }
        }

        [NotMapped]
        public bool IsDiscountType {
            get
            {
                return (DiscountRegistrationDate != null);
            }
        }

        [NotMapped]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate {
            get
            {
                return (LastUsedDate == null) ? (PurchaseDate.AddYears(5)) : LastUsedDate.Value.AddYears(5);
            }
        }

        [NotMapped]
        public bool IsValid { 
            get 
            {
                return (DateTime.Now < this.ExpirationDate);
            }
        }

        [NotMapped]
        public bool CanBeRegisteredAsDiscount {
            get
            {
                return (DiscountRegistrationDate != null) ? false : (DateTime.Now < PurchaseDate.AddMonths(6));
            }
        }

        public string GenerateSerialNumber()
        {
            return (PurchaseDate != null)
                    ? $"{TransportCardId}{PurchaseDate.ToString("MMddYY")}"
                    : null;
        }
        #endregion
    }
}
