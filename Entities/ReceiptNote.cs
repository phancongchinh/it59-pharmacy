using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT59_Pharmacy.Entities {
    public enum ReceiptNoteStatus
    {
        Completed,
        Cancelled
    }
    
    public class ReceiptNote : Auditable{
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string ReceiptNoteNumber { get; set; } = string.Empty;
        
        [Required]
        public int SupplierId { get; set; }
        
        public ReceiptNoteStatus Status { get; set; } = ReceiptNoteStatus.Completed;
        
        [StringLength(200)]
        public string Notes { get; set; }
        
        // Navigation properties
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; } = null;
        
        public virtual ICollection<ReceiptNoteItem> ReceiptNoteItems { get; set; } = new List<ReceiptNoteItem>(); 
    }
}