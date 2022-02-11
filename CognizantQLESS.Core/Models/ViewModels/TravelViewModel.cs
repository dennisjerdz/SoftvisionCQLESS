using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CognizantQLESS.Core.Models.ViewModels
{
    public class TravelViewModel
    {
        [Display(Name = "Origin Station")]
        public int OriginStationId { get; set; }
        [Display(Name = "Destination Station")]
        public int DestinationStationId { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
    }
}
