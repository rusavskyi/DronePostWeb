using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DronePostWeb.Models
{
    /// <summary>
    /// Static class for holding static values.
    /// </summary>
    public class Holder
    {
        public static string ApplicationName = "Drone Post";
        public static string AdminRole = "Admin";
        public static string ManagerType = "Manager";
        public static string TechnicalType = "TechnicalWorker";
        public static string ServiceType = "ServiceWorker";
        public static UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        public static ApplicationDbContext Context = new ApplicationDbContext();

        
    }
}