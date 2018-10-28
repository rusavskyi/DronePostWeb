using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for ConsumerUsers table.
    /// </summary>
    public class ConsumerUser
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        [Key]
        [Required]
        public Consumer Consumer { get; set; }
    }
}