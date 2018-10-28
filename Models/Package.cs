using System.ComponentModel.DataAnnotations;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for table Packages.
    /// </summary>
    public class Package
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Recipient phone number")]
        public int RecipientPhoneNumber { get; set; }

        //[Required]
        public Consumer Sender { get; set; }

        [Required]
        public PackageSize Size { get; set; }

        [Required]
        [Display(Name = "Target station")]
        public Station TargetStation { get; set; }

        [Required]
        [StringLength(16)]
        public string Code { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        public float Price { get; set; }
    }
}
