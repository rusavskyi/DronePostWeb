using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Support model for veiw.
    /// Contains fields for consumer search.
    /// </summary>
    public class FindConsumerViewModel
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Lastname { get; set; }

        [StringLength(100)]
        public string PESEL { get; set; }

        public int PhoneNumber { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public int CityId { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}