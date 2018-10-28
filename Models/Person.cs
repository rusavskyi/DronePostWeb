using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Model for table Persons.
    /// </summary>
    public abstract class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Lastname { get; set; }

        [StringLength(100)]
        public string PESEL { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        public City City { get; set; }

        /*
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        */

        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
    }
}
