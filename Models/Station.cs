using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for table Stations.
    /// </summary>
    public class Station
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public City City { get; set; }

        public string Latitude { get; set; }

        public string Wideness { get; set; }
    }
}
