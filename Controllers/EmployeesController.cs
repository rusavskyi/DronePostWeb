using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DronePostWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DronePostWeb.Controllers
{
    /// <summary>
    /// This controller handles actions related to employees.
    /// </summary>
    public class EmployeesController : Controller
    {
        // GET: Employe
        /// <summary>
        /// Returns index view of employees category.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns view with worcker details form. 
        /// Handles workers data change, removing of worker and representation of worker information in ready for print version.
        /// </summary>
        /// <param name="worker">(Worker) Worker of interest.</param>
        /// <returns>View</returns>
        public ActionResult EmployeDetails(Worker worker)
        {
            return View(worker);
        }

        /// <summary>
        /// Handles removal of worker.
        /// </summary>
        /// <param name="worker">(Worker) Worker to delete.</param>
        /// <returns>Index view of employees.</returns>
        public ActionResult DeleteEmploye(Worker worker)
        {
            var workerInDb = Holder.Context.Workers.Single(c => c.Id == worker.Id);
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            userManager.Delete(userManager.FindById(Holder.Context.WorkerUserTab.Single(wu => wu.Worker.Id == workerInDb.Id).UserId));
            Holder.Context.Workers.Remove(workerInDb);
            Holder.Context.SaveChanges();
            return View("Index");
        }

        /// <summary>
        /// Handles employe data change.
        /// </summary>
        /// <param name="worker">(Worker) Worker of interest.</param>
        /// <returns>Index view of employees.</returns>
        public ActionResult ChangeEmployeDataForm(Worker worker)
        {
            var workerInDb = Holder.Context.Workers.Include("City").Include("WorkStation").Single(c => c.Id == worker.Id);
            workerInDb.City = Holder.Context.Cities.Single(c => c.Id == worker.City.Id);
            workerInDb.Name = worker.Name;
            workerInDb.Lastname = worker.Lastname;
            workerInDb.Address = worker.Address;
            if (worker.BirthDate.Date != DateTime.MinValue)
                workerInDb.BirthDate = worker.BirthDate.Date;
            workerInDb.PESEL = worker.PESEL;
            workerInDb.PhoneNumber = worker.PhoneNumber;
            workerInDb.WorkStation = Holder.Context.Stations.Single(s => s.Id == worker.WorkStation.Id);
            workerInDb.WorkerType = Holder.Context.WorkerTypes.Single(t => t.Id == worker.WorkerType.Id);
            if (worker.EmployementDate != DateTime.MinValue)
                workerInDb.EmployementDate = worker.EmployementDate;
            workerInDb.Salery = worker.Salery;
            Holder.Context.SaveChanges();
            return View("Index");
        }

        /// <summary>
        /// Returns view with search form.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult FindEmploye()
        {
            return View();
        }

        /// <summary>
        /// Handles employe search.
        /// (Not implemented)
        /// </summary>
        /// <returns>View with search results.</returns>
        public ActionResult FindEmployeForm()
        {
            return View();
        }

        /// <summary>
        /// Returns view with new employe form.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult AddNewEmploye()
        {
            return View();
        }

        /// <summary>
        /// Handles new employe creation.
        /// </summary>
        /// <param name="model">(AddNewEmployeViewModel) Contains all required field for employe creation.</param>
        /// <returns>Index view of employees category.</returns>
        public ActionResult AddNewEmployeForm(AddNewEmployeViewModel model)
        {
            var context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, IsWorker = true };
            userManager.Create(user, model.Password);
            Worker worker = new Worker
            {
                Name = model.Consumer.Name,
                Lastname = model.Consumer.Lastname,
                BirthDate = model.Consumer.BirthDate,
                Address = model.Consumer.Address,
                City = context.Cities.Find(model.CityId),
                WorkStation = context.Stations.Find(model.WorkStationId),
                WorkerType = context.WorkerTypes.Find(model.WorkerTypeId),
                EmployementDate = model.EmployementDate,
                PESEL = model.Consumer.PESEL,
                PhoneNumber = model.Consumer.PhoneNumber,
                Salery = model.WorkerTypeId == 1 ? 15 : 10
            };
            context.Workers.Add(worker);
            context.WorkerUserTab.Add(new WorkerUser { UserId = user.Id, Worker = worker });
            context.SaveChanges();
            return View("Index");
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <returns></returns>
        public ActionResult SearchResultForEmploye()
        {
            return View();
        }
    }
}