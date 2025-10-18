using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT59_Pharmacy.Entities {
    public class DeliveryNoteItem {
        [Key]
        public int Id { get; set; }
        
        public int DeliveryNoteId { get; set; }
        
        public int MedicineBatchId { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        // Navigation properties
        [ForeignKey("DeliveryNoteId")]
        public virtual DeliveryNote DeliveryNote { get; set; }
        
        [ForeignKey("MedicineBatchId")]
        public virtual MedicineBatch MedicineBatch { get; set; }
    }
}