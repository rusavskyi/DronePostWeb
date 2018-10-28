using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for Dornes table.
    /// </summary>
    public class Drone
    {
        public int Id { get; set; }

        [Required]
        public DroneModel Model { get; set; }

        public string Latitude { get; set; }

        public string Wideness { get; set; }
    }
}
