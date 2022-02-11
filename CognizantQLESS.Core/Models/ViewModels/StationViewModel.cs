using System;
using System.Collections.Generic;
using System.Text;

namespace CognizantQLESS.Core.Models.ViewModels
{
    public class StationViewModel
    {
        public int StationId { get; set; }
        public string Name { get; set; }
        public int StationLineId { get; set; }
        public int Order { get; set; }
    }
}
