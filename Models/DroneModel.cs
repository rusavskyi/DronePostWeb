using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for DroneModels table.
    /// </summary>
    public class DroneModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Max package size")]
        public PackageSize MaxPackageSize { get; set; }

        [Required]
        [Display(Name = "Max carry weight")]
        public float MaxWeight { get; set; }

        [Required]
        [Display(Name = "Max trevel distance")]
        public float MaxDistance { get; set; }
    }
}
