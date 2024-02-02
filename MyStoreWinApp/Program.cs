using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace MyStoreWinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            string user = GetStringConfig("Account:Username");
            String pass = GetStringConfig("Account:Password");
            Application.Run(new FormLogin(user, pass));
            //Application.Run(new FormMemberManagerment());
        }

        static string GetStringConfig(String location)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string a = config[location];
            return a;
        }
    }
}
