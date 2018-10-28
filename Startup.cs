using System.Globalization;
using System.Threading;
using Microsoft.Owin;
using Owin;

namespace DronePostWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
