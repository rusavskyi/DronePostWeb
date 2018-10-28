using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for table Transfers.
    /// </summary>
    public class Transfer
    {
        public long Id { get; set; }

        public Drone Drone { get; set; }

        public Station DepartureStation { get; set; }

        public Station ArrivalStation { get; set; }

        public Package Package { get; set; }

        public DateTime? Departure { get; set; }
            
        public DateTime? Arrival { get; set; }
    }
}
