using IT59_Pharmacy.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace IT59_Pharmacy
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }

        // private static void ConfigureServices(IServiceCollection services)
        // {
        //     // Get a connection string from a standard connectionStrings section
        //     var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
        //                            ?? throw new InvalidOperationException(
        //                                "Connection string 'DefaultConnection' not found.");
        //
        //     // Add data services (DbContext and repositories)
        //     services.AddDataServices(connectionString);
        //
        //     // Add application services
        //     services.AddScoped<IAuthenticationService, AuthenticationService>();
        //
        //     // Add forms (if needed for DI)
        //     services.AddTransient<FormLogin>();
        // }
    }
}
