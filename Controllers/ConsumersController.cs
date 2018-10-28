using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DronePostWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DronePostWeb.Controllers
{
    /// <summary>
    /// This controller handles actions related to consumers.
    /// </summary>
    public class ConsumersController : Controller
    {
        // GET: Consumers
        /// <summary>
        /// Returns consumers index view.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns view with consumer search form.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult FindConsumer()
        {
            return View();
        }

        /// <summary>
        /// Handles consumer search.
        /// </summary>
        /// <param name="model">Contains required for search fields.</param>
        /// <returns>View with list of consumers or view with consumer's data if there only one consumer found.</returns>
        public ActionResult FindConsumerForm(FindConsumerViewModel model)
        {
            var consumersAll = Holder.Context.Consumers.Include("City").ToList();
            List<Consumer> seConsumers = new List<Consumer>();
            foreach (var consumer in consumersAll)
            {
                if (model.Name == null || consumer.Name == model.Name || model.Name == string.Empty &&
                    model.Lastname == null || consumer.Lastname == model.Lastname || model.Lastname == string.Empty &&
                    model.PESEL == null || consumer.PESEL == model.PESEL || model.PESEL == string.Empty &&
                    model.Address == null || consumer.Address == model.Address || model.Address == string.Empty &&
                    consumer.PhoneNumber == model.PhoneNumber || model.PhoneNumber == 0 &&
                    model.BirthDate == null || model.BirthDate == consumer.BirthDate || model.BirthDate == new DateTime() &&
                    model.CityId == 0 || model.CityId == consumer.City.Id)
                {
                    seConsumers.Add(consumer);
                }
            }
            if (seConsumers.Count == 1)
                return View("ConsumerDetails", seConsumers[0]);
            else
                return View("SearchResultForConsumers", seConsumers);
        }

        /// <summary>
        /// Returns view with list of found consumers.
        /// </summary>
        /// <param name="consumers">(List(Consumer)) List wwith search results.</param>
        /// <returns>View</returns>
        public ActionResult SearchResultForConsumers(List<Consumer> consumers)
        {
            return View();
        }

        /// <summary>
        /// Returns view with consumers informaion.
        /// Handles consumers data change, consumer removal and generates ready to print view.
        /// </summary>
        /// <param name="consumer">(Consumer) Consumer of interest.</param>
        /// <returns>View</returns>
        //[HttpPost]
        public ActionResult ConsumerDetails(Consumer consumer)
        {
            return View(consumer);
        }

        /// <summary>
        /// Handles consumer removal.
        /// </summary>
        /// <param name="consumer">(Consumer) Consumer to remove.</param>
        /// <returns>Consumers index view.</returns>
        [HttpPost]
        public ActionResult DeleteConsumer(Consumer consumer)
        {
            var consumerInDb = Holder.Context.Consumers.Single(c => c.Id == consumer.Id);
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            string uId = Holder.Context.ConsumerUserTab.Single(cu => cu.Consumer.Id == consumerInDb.Id).UserId;
            userManager.Delete(userManager.FindById(uId));
            Holder.Context.Consumers.Remove(consumerInDb);
            Holder.Context.SaveChanges();
            return View("Index");
        }

        /// <summary>
        /// Handels consumer's information change.
        /// </summary>
        /// <param name="consumer">(Consumer) Consumer of interest.</param>
        /// <returns>Consumers index view.</returns>
        [HttpPost]
        public ActionResult ChangeConsumerDataForm(Consumer consumer)
        {
            var consumerInDb = Holder.Context.Consumers.Include("City").Single(c => c.Id == consumer.Id);
            consumerInDb.City = Holder.Context.Cities.Single(c => c.Id == consumer.City.Id);
            consumerInDb.Name = consumer.Name;
            consumerInDb.Lastname = consumer.Lastname;
            consumerInDb.Address = consumer.Address;
            if (consumer.BirthDate != DateTime.MinValue)
                consumerInDb.BirthDate = consumer.BirthDate;
            consumerInDb.PESEL = consumer.PESEL;
            consumerInDb.PhoneNumber = consumer.PhoneNumber;
            Holder.Context.SaveChanges();
            return View("Index");
        }

        /// <summary>
        /// Returns view with add new consumer form.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult AddNewConsumer()
        {
            return View();
        }

        /// <summary>
        /// Handles new consumer creation.
        /// </summary>
        /// <param name="model">(RegisterViewModel) Contains all required fields for new consumer creation.</param>
        /// <returns>Consumers index view.</returns>
        public ActionResult AddNewConsumerForm(RegisterViewModel model)
        {
            var context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, IsWorker = false };
            userManager.Create(user, model.Password);
            model.Consumer.City = context.Cities.Find(model.CityId);
            context.Consumers.Add(model.Consumer);
            context.ConsumerUserTab.Add(new ConsumerUser { UserId = user.Id, Consumer = model.Consumer });
            context.SaveChanges();
            return View("Index");
        }

        /// <summary>
        /// Returns view with ready to print vesion.
        /// </summary>
        /// <returns>View.</returns>
        public ActionResult PrintVersionAll()
        {
            return View();
        }

        /// <summary>
        /// Returns view with single consumer information in ready to print version.
        /// </summary>
        /// <param name="consumer">(Consumer) Consumer of interest.</param>
        /// <returns>View.</returns>
        public ActionResult PrintVersionSingle(Consumer consumer)
        {
            return View(consumer);
        }
    }
}