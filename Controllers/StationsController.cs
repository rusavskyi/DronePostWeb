using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DronePostWeb.Controllers
{
    /// <summary>
    /// This controller handles actions related to stations.
    /// </summary>
    public class StationsController : Controller
    {
        // GET: Stations
        /// <summary>
        /// Returns view of index page of stations catalog.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns view with list of stations.
        /// </summary>
        /// <returns>View</returns>
        [AllowAnonymous]
        public ActionResult OurStations()
        {
            return View();
        }
    }
}