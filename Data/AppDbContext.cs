using System.Data.Entity;
using IT59_Pharmacy.Entities;

namespace IT59_Pharmacy.Data {
    public class AppDbContext : DbContext {

        public AppDbContext() {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<MedicineCategory> MedicineCategories { get; set; }
        // Add other DbSets as needed

        // public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //
        // protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //     base.OnModelCreating(modelBuilder);
        //
        //     // Apply configurations from the current assembly
        //     modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        // }
        //
        // // DbSets for your entities
        // public DbSet<User> Users { get; set; } = null!;
        // public DbSet<Supplier> Suppliers { get; set; } = null!;
        // // Add other DbSets as needed
        //
    }
}