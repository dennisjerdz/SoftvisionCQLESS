using System;
using System.Collections.Generic;
using System.Text;

namespace CognizantQLESS.Core.Models.ViewModels
{
    public class FareCacheViewModel
    {
        public int OriginStationId { get; set; }
        public int DestinationStationId { get; set; }
        public float Rate { get; set; }
    }
}
