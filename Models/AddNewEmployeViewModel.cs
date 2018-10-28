using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model contains fields for new employe creation.
    /// </summary>
    public class AddNewEmployeViewModel : RegisterViewModel
    {
        [Required]
        [Display(Name = "Work position")]
        public int WorkerTypeId { get; set; }

        [Required]
        [Display(Name = "Work at station")]
        public int WorkStationId { get; set; }

        [Required]
        [Display(Name = "Employement date")]
        public DateTime EmployementDate { get; set; }
    }
}