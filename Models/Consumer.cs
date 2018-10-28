using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for table Consumers.
    /// </summary>
    public class Consumer : Person
    {
        [Required]
        public float Balance { get; set; }  
    }
}
