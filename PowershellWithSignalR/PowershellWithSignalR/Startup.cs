using Microsoft.Owin;
using Owin;
using PowershellWithSignalR.Hubs;

[assembly: OwinStartup(typeof(PowershellWithSignalR.Startup))]

namespace PowershellWithSignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}