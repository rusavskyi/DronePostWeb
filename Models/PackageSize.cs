using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for table PackageSizes
    /// </summary>
    public class PackageSize
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [Required]
        public float Height { get; set; }

        [Required]
        public float Width { get; set; }

        [Required]
        public float Length { get; set; }
    }
}
