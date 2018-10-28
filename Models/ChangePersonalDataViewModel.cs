using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Contains consumer and additional (currently not) data of consumer.
    /// </summary>
    public class ChangePersonalDataViewModel
    {
        public Consumer Consumer { get; set; }
        
    }
}