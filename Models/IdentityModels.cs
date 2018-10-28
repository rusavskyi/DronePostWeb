using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DronePostWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Is employe")]
        public bool IsWorker { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<City> Cities { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<DroneModel> DroneModels { get; set; }
        public DbSet<PackageSize> PackageSizes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerType> WorkerTypes { get; set; }
        public DbSet<ConsumerUser> ConsumerUserTab { get; set; }
        public DbSet<WorkerUser> WorkerUserTab { get; set; }



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
    }
}