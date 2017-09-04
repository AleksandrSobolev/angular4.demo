using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;

namespace Project.API
{
    class Program
    {
        private const string SELF_HOST_URL = "selfHostUrl";

        static void Main(string[] args)
        {
            string selfHostUrl = selfHostUrl = ConfigurationManager.AppSettings[Program.SELF_HOST_URL];

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: selfHostUrl))
            {
                Console.WriteLine($"The server is running now. Host Url: '{selfHostUrl}'");
                Console.WriteLine($"Press any key for exit...");
                Console.ReadKey();
            }
        }
    }
}
