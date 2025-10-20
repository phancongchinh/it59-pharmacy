using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IT59_Pharmacy.Entities {
    
    public enum DeliveryFor {
        InternalUse,
        Sales,
        ReturnToSupplier,
        ExpiryManagement,
        DamageManagement
    }

    public enum DeliveryNoteStatus {
        Pending,
        Completed,
        Refunded,
        Canceled,
    }

    public enum PaymentMethod {
        Cash,
        BankTransfer,
        NotRequired
    }
    
    public class DeliveryNote : Auditable {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string DeliveryNoteNumber { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Notes { get; set; }
        
        [Required]
        public DeliveryFor DeliveryFor { get; set; } = DeliveryFor.Sales;
        
        public DeliveryNoteStatus Status { get; set; } = DeliveryNoteStatus.Pending;
        
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
        
        [StringLength(50)]
        public string DeliveryTo { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual ICollection<DeliveryNoteItem> DeliveryNoteItems { get; set; } = new List<DeliveryNoteItem>();
        
    }
}