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
        
        public int SaveChanges() {
            return _context.SaveChanges();
        }
    }
}