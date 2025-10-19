using IT59_Pharmacy.Data;
using IT59_Pharmacy.Seeders;
using IT59_Pharmacy.Views;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IT59_Pharmacy {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // Set the data directory for LocalDB
            AppDomain.CurrentDomain.SetData("DataDirectory",
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"));

            // Ensure the Data directory exists
            var dataDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Initialize database on startup
            InitializeDatabase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }

        public static void InitializeDatabase() {
            using (var context = new AppDbContext())
            {
                try
                {
                    // Ensure database is created based on the entities
                    context.Database.Initialize(force: false);

                    // Check if there are any users in the database
                    if (!context.Users.Any())
                    {
                        // Seed initial data only if there are no users
                        DatabaseSeeder.Seed(context);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while initializing the database: {ex.Message}", ex);
                }
            }
        }
    }
}