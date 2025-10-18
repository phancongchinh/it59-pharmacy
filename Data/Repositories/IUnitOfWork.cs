// using System;
// using System.Threading.Tasks;
// using IT59_Pharmacy.Entities;
//
// namespace IT59_Pharmacy.Data.    public class IUnitOfWork: IDisposable {
//         // Repository properties for all entities
//         IRepository<User> Users { get; }
//         IRepository<Supplier> Suppliers { get; }
//         IRepository<MedicineCategory> MedicineCategories { get; }
//         IRepository<Medicine> Medicines { get; }
//         IRepository<MedicineBatch> MedicineBatches { get; }
//         IRepository<DeliveryNote> DeliveryNotes { get; }
//         IRepository<DeliveryNoteItem> DeliveryNoteItems { get; }
//         IRepository<ReceiptNote> ReceiptNotes { get; }
//         IRepository<ReceiptNoteItem> ReceiptNoteItems { get; }
//
//         // Transaction methods
//         Task<int> SaveChangesAsync();
//         int SaveChanges();
//         Task BeginTransactionAsync();
//         void BeginTransaction();
//         Task CommitTransactionAsync();
//         void CommitTransaction();
//         Task RollbackTransactionAsync();
//         void RollbackTransaction();: IDisposable {
//         
//     }
// }