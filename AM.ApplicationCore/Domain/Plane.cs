using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boing, AirBus}
    public class Plane
    {
        
        public int PlaneId {  get; set; }
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }
        public PlaneType PlaneType { get; set; }
        public DateTime ManufactureDate { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public override string? ToString()
        {
            return "Plane Type: {}"+PlaneType +" ManufactureDate: "+ ManufactureDate + " Capacity: "+Capacity;
        }
    }
}
