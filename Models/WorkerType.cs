using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for table WorkerTypes.
    /// </summary>
    public class WorkerType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Office position")]
        public string Name { get; set; }
    }
}
