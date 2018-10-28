using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for table Workers.
    /// </summary>
    public class Worker : Person
    {
        [Required]
        public WorkerType WorkerType { get; set; }

        [Required]
        [Display(Name = "Employement date")]
        [DataType(DataType.DateTime)]
        public DateTime EmployementDate { get; set; }

        [Required]
        public Station WorkStation { get; set; }

        [Required]
        [Display(Name = "Salery per hour")]
        public float Salery { get; set; }
    }
}
