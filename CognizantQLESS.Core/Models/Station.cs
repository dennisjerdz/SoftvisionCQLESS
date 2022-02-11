using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CognizantQLESS.Core.Models
{
    public class Station
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StationId { get; set; }
        public string Name { get; set; }
        public short Order { get; set; }

        public int StationLineId { get; set; }
        [ForeignKey("StationLineId")]
        public StationLine StationLine { get; set; }

        public virtual List<Travel> TravelsAsOrigin { get; set; }
        public virtual List<Travel> TravelsAsDestination { get; set; }
        public virtual List<Fare> FaresAsOrigin { get; set; }
        public virtual List<Fare> FaresAsDestination { get; set; }
    }
}
