using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CognizantQLESS.Core.Models
{
    public class StationLine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StationLineId { get; set; }
        public string Name { get; set; }
        public virtual List<Station> Stations { get; set; }
    }
}
