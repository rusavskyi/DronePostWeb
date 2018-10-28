using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Suport model for view.
    /// Contains required field for new package creation.
    /// </summary>
    public class PreparePackageViewModel
    {
        [Required]
        [Display(Name = "Recipient phone number")]
        public int RecipientPhone { get; set; }

        [Required]
        [Display(Name = "Target station")]
        public int StationId { get; set; }

        [Required]
        [Display(Name = "From station")]
        public int FromStationId { get; set; }

        [Required]
        [Display(Name = "Package weight")]
        public float PackageWeight { get; set; }

        [Required]
        [Display(Name = "Package size")]
        public int PackageSizeId { get; set; }

    }
}