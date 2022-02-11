using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CognizantQLESS.Core.Models
{
    public class Fare
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FareId { get; set; }

        public int OriginStationId { get; set; }
        [ForeignKey("OriginStationId")]
        public Station OriginStation { get; set; }

        public int DestinationStationId { get; set; }
        [ForeignKey("DestinationStationId")]
        public Station DestinationStation { get; set; }

        public float Rate { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
