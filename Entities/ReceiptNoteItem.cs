using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT59_Pharmacy.Entities {
    public class ReceiptNoteItem {
        [Key]
        public int Id { get; set; }
        
        public int ReceiptNoteId { get; set; }
        
        public int MedicineBatchId { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal UnitCost { get; set; }
        
        // Navigation properties
        [ForeignKey("ReceiptNoteId")]
        public virtual ReceiptNote ReceiptNote { get; set; } = null;
        
        [ForeignKey("MedicineBatchId")]
        public virtual MedicineBatch MedicineBatch { get; set; } = null;
    }
}