using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Support model for view.
    /// Contains fields for package search.
    /// </summary>
    public class FindPackageViewModel
    {
        [Display(Name = "Recipient phone number")]
        public string Phone { get; set; }

        [Display(Name = "Package code")]
        public string Code { get; set; }
    }
}