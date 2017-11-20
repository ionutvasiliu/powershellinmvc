using Microsoft.AspNet.SignalR;
using PowershellWithSignalR.Hubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Web;
using System.Web.Mvc;

namespace PowershellWithSignalR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult ExecuteScript()
        {
            var shell = PowerShell.Create();

            // Add the script to the PowerShell object
            shell.Commands.AddScript(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "powershell-demo.ps1"));
            var context = GlobalHost.ConnectionManager.GetHubContext<PowershellHub>();
            shell.Streams.Progress.DataAdded += (object sender, DataAddedEventArgs e) =>
           {
               var records = (PSDataCollection<ProgressRecord>)sender;
               context.Clients.All.addNewMessageToPage(records[e.Index].Activity);
           };
            // Execute the script

            var results = shell.BeginInvoke();

            return RedirectToAction("Index");
        }
    }
}