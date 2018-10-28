using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for table WorkerUsers.
    /// </summary>
    public class WorkerUser
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        [Key]
        [Required]
        public Worker Worker { get; set; }
    }
}