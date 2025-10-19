using IT59_Pharmacy.Entities;
using IT59_Pharmacy.Services;

namespace IT59_Pharmacy.Data.Repositories {
    
    public class UnitOfWork {
        
        private readonly AppDbContext _context;
        private readonly CurrentUserService _currentUserService;
        
        public UnitOfWork(AppDbContext context, CurrentUserService currentUserService) {
            _context = context;
            _currentUserService = currentUserService;
        }
        
        // Repository properties
        private Repository<User> _userRepository;
        private Repository<Supplier> _supplierRepository;
        private Repository<MedicineCategory> _medicineCategoryRepository;
        private Repository<MedicineBatch> _medicineBatchRepository;
        private Repository<Medicine> _medicineRepository;
        private Repository<DeliveryNote> _deliveryNoteRepository;
        private Repository<DeliveryNoteItem> _deliveryNoteItemRepository;
        private Repository<ReceiptNote> _receiptNoteRepository;
        private Repository<ReceiptNoteItem> _receiptNoteItemRepository;

        public Repository<User> Users {
            get { return _userRepository ?? (_userRepository = new Repository<User>(_context, _currentUserService)); }
        }
        
        public Repository<Supplier> Suppliers {
            get { return _supplierRepository ?? (_supplierRepository = new Repository<Supplier>(_context, _currentUserService)); }
        }
        
        public Repository<MedicineCategory> MedicineCategories {
            get { return _medicineCategoryRepository ?? (_medicineCategoryRepository = new Repository<MedicineCategory>(_context, _currentUserService)); }
        }
        
        public Repository<Medicine> Medicines {
            get { return _medicineRepository ?? (_medicineRepository = new Repository<Medicine>(_context, _currentUserService)); }
        }
        
        public Repository<MedicineBatch> MedicineBatches {
            get { return _medicineBatchRepository ?? (_medicineBatchRepository = new Repository<MedicineBatch>(_context, _currentUserService)); }
        }
        
        public Repository<DeliveryNote> DeliveryNotes {
            get { return _deliveryNoteRepository ?? (_deliveryNoteRepository = new Repository<DeliveryNote>(_context, _currentUserService)); }
        }
        
        public Repository<DeliveryNoteItem> DeliveryNoteItems {
            get { return _deliveryNoteItemRepository ?? (_deliveryNoteItemRepository = new Repository<DeliveryNoteItem>(_context, _currentUserService)); }
        }
        
        public Repository<ReceiptNote> ReceiptNotes {
            get { return _receiptNoteRepository ?? (_receiptNoteRepository = new Repository<ReceiptNote>(_context, _currentUserService)); }
        }
        
        public Repository<ReceiptNoteItem> ReceiptNoteItems {
            get { return _receiptNoteItemRepository ?? (_receiptNoteItemRepository = new Repository<ReceiptNoteItem>(_context, _currentUserService)); }
        }
        
        public int SaveChanges() {
            return _context.SaveChanges();
        }
    }
}