using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Destination {  get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival {  get; set; }
        public int EstimatedDuration { get; set; }
        public string Departure {  get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public int PlaneId {  get; set; }
        [ForeignKey("PlaneId")]
        public virtual Plane plane { get; set; }
        public string AirlineLogo { get; set; }

        public override string? ToString()
        {
            return " FlightDate: "+ FlightDate+ " EstimatedDuration: "+ EstimatedDuration+ " Destination: "+ Destination;
        }
    }
}
