using System.Data.Entity;
using IT59_Pharmacy.Entities;

namespace IT59_Pharmacy.Data {
    public class AppDbContext : DbContext {

        public AppDbContext() : base("name=AppDbContext") {
            // Enable automatic database creation if it doesn't exist
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Configure self-referencing relationships for User
            modelBuilder.Entity<User>()
                .HasOptional(u => u.CreatedBy)
                .WithMany()
                .HasForeignKey(u => u.CreatedById)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(u => u.UpdatedBy)
                .WithMany()
                .HasForeignKey(u => u.UpdatedById)
                .WillCascadeOnDelete(false);

            // // Configure audit relationships for Supplier
            // modelBuilder.Entity<Supplier>()
            //     .HasOptional(s => s.CreatedBy)
            //     .WithMany()
            //     .HasForeignKey(s => s.CreatedById)
            //     .WillCascadeOnDelete(false);
            //
            // modelBuilder.Entity<Supplier>()
            //     .HasOptional(s => s.UpdatedBy)
            //     .WithMany()
            //     .HasForeignKey(s => s.UpdatedById)
            //     .WillCascadeOnDelete(false);
            //
            // // Configure audit relationships for MedicineCategory
            // modelBuilder.Entity<MedicineCategory>()
            //     .HasOptional(mc => mc.CreatedBy)
            //     .WithMany()
            //     .HasForeignKey(mc => mc.CreatedById)
            //     .WillCascadeOnDelete(false);
            //
            // modelBuilder.Entity<MedicineCategory>()
            //     .HasOptional(mc => mc.UpdatedBy)
            //     .WithMany()
            //     .HasForeignKey(mc => mc.UpdatedById)
            //     .WillCascadeOnDelete(false);
            //
            // // Configure audit relationships for Medicine
            // modelBuilder.Entity<Medicine>()
            //     .HasOptional(m => m.CreatedBy)
            //     .WithMany()
            //     .HasForeignKey(m => m.CreatedById)
            //     .WillCascadeOnDelete(false);
            //
            // modelBuilder.Entity<Medicine>()
            //     .HasOptional(m => m.UpdatedBy)
            //     .WithMany()
            //     .HasForeignKey(m => m.UpdatedById)
            //     .WillCascadeOnDelete(false);
            //
            // // Configure audit relationships for MedicineBatch
            // modelBuilder.Entity<MedicineBatch>()
            //     .HasOptional(mb => mb.CreatedBy)
            //     .WithMany()
            //     .HasForeignKey(mb => mb.CreatedById)
            //     .WillCascadeOnDelete(false);
            //
            // modelBuilder.Entity<MedicineBatch>()
            //     .HasOptional(mb => mb.UpdatedBy)
            //     .WithMany()
            //     .HasForeignKey(mb => mb.UpdatedById)
            //     .WillCascadeOnDelete(false);
            //
            // // Configure audit relationships for ReceiptNote
            // modelBuilder.Entity<ReceiptNote>()
            //     .HasOptional(rn => rn.CreatedBy)
            //     .WithMany()
            //     .HasForeignKey(rn => rn.CreatedById)
            //     .WillCascadeOnDelete(false);
            //
            // modelBuilder.Entity<ReceiptNote>()
            //     .HasOptional(rn => rn.UpdatedBy)
            //     .WithMany()
            //     .HasForeignKey(rn => rn.UpdatedById)
            //     .WillCascadeOnDelete(false);
            //
            // // Configure audit relationships for DeliveryNote
            // modelBuilder.Entity<DeliveryNote>()
            //     .HasOptional(dn => dn.CreatedBy)
            //     .WithMany()
            //     .HasForeignKey(dn => dn.CreatedById)
            //     .WillCascadeOnDelete(false);
            //
            // modelBuilder.Entity<DeliveryNote>()
            //     .HasOptional(dn => dn.UpdatedBy)
            //     .WithMany()
            //     .HasForeignKey(dn => dn.UpdatedById)
            //     .WillCascadeOnDelete(false);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<MedicineCategory> MedicineCategories { get; set; }
        // Add other DbSets as needed
    }
}