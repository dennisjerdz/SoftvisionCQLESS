using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CognizantQLESS.Core.Models
{
    public class Travel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TravelId { get; set; }

        public int TransportCardId { get; set; }
        [ForeignKey("TransportCardId")]
        public TransportCard TransportCard { get; set; }

        public int OriginStationId { get; set; }
        [ForeignKey("OriginStationId")]
        public Station OriginStation { get; set; }

        public int DestinationStationId { get; set; }
        [ForeignKey("DestinationStationId")]
        public Station DestinationStation { get; set; }

        public DateTime TravelDate { get; set; }
    }
}