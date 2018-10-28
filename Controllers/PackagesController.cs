using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DronePostWeb.Models;
using Microsoft.AspNet.Identity;

namespace DronePostWeb.Controllers
{
    /// <summary>
    /// This controller handles actions related to packages.
    /// </summary>
    public class PackagesController : Controller
    {
        // GET: Packages
        /// <summary>
        /// Returns view of index page of packages catalog.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns view with list of client's packages.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult MyPackages()
        {
            return View();
        }

        /// <summary>
        /// Returns view with FindPackageForm.
        /// </summary>
        /// <returns>View</returns>
        [AllowAnonymous]
        public ActionResult FindPackage()
        {
            return View();
        }

        /// <summary>
        /// Handles package search and returns view with search result.
        /// </summary>
        /// <param name="model">(FindPackageViewModel) Contains search request data.</param>
        /// <returns>Vieew</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult FindPackageForm(FindPackageViewModel model)
        {
            Package resPackage = null;
            int phone;
            var packages = Holder.Context.Packages.ToList();
            foreach (var package in packages)
            {
                if (package.Code.Equals(model.Code) && package.RecipientPhoneNumber.Equals(int.TryParse(model.Phone,out phone) ? phone : 0))
                {
                    resPackage = package;
                }
            }
            return View("PackageSearchResult", resPackage);
        }

        /// <summary>
        /// Returns view with PreparePackageForm.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult PreparePackage()
        {
            return View();
        }

        /// <summary>
        /// Handles new package creation and simulates it's sanding.
        /// </summary>
        /// <param name="model">(PreparePackageViewModel) Contains required fields for new package creation.</param>
        /// <returns>(View) Package creation result.</returns>
        [HttpPost]
        public ActionResult PreparePackageForm(PreparePackageViewModel model)
        {
            var tmp = Holder.Context.ConsumerUserTab.Include("Consumer").ToList();
            Consumer consumer = null;
            foreach (var consumerUser in tmp)
            {
                if (consumerUser.UserId == User.Identity.GetUserId())
                {
                    consumer = consumerUser.Consumer;
                    break;
                }
            }
            Package package = new Package
            {
                RecipientPhoneNumber = model.RecipientPhone,
                Code = "" + (Math.Abs(DateTime.Now.GetHashCode()) + new Random().Next(1000, 10000)),
                Sender = consumer,
                Size = Holder.Context.PackageSizes.Find(model.PackageSizeId),
                TargetStation = Holder.Context.Stations.Find(model.StationId),
                Price = CalculatePrice(model.FromStationId, model.StationId, model.PackageWeight, model.PackageSizeId)
            };
            Transfer transfer = new Transfer
            {
                ArrivalStation = Holder.Context.Stations.Find(model.FromStationId),
                Arrival = DateTime.Now,
                Package = package
            };
            Holder.Context.Packages.Add(package);
            Holder.Context.Transfers.Add(transfer);
            Holder.Context.SaveChanges();
            return View("PackageCreated", package);
        }

        public ActionResult PackageCreated(Package package)
        {
            return View();
        }

        /// <summary>
        /// Returns view with information about cost of new package.
        /// </summary>
        /// <param name="package">(Packare) Created package</param>
        /// <returns>View</returns>
        [AllowAnonymous]
        public ActionResult PackageSearchResult(Package package)
        {
            return View();
        }

        /// <summary>
        /// Support method for package price calculation.
        /// </summary>
        /// <param name="from">(int) Id of station package was sended from.</param>
        /// <param name="to">(int) Id of station package was sended to.</param>
        /// <param name="weight">(float) Weight of package.</param>
        /// <param name="size">(int) Package size id.</param>
        /// <returns>(float) Package price.</returns>
        public static float CalculatePrice(int from, int to, float weight, int size)
        {
            return (from < to ? to - from : from - to) * weight * size + 1f;
        }
    }
}