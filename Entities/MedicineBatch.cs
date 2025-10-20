using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT59_Pharmacy.Entities {
    
    public enum MedicineBatchStatus
    {
        Active,
        Inactive,
        Expired
    }
    
    public class MedicineBatch : Auditable {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string BatchNumber { get; set; } = string.Empty;
        
        [Required]
        public int MedicineId { get; set; }
        
        [Required]
        public int SupplierId { get; set; }
        
        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public DateTime ManufacturingDate { get; set; }
        
        public string Manufacturer { get; set; } = string.Empty;

        public int Quantity { get; set; }   
        
        [Column(TypeName = "decimal")] 
        public decimal CostPrice { get; set; }
        
        [Column(TypeName = "decimal")] 
        public decimal? SellingPrice { get; set; }
        
        [Required]
        public MedicineBatchStatus Status { get; set; } = MedicineBatchStatus.Active;
        
        // Navigation properties
        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; } = null;
        
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; } = null;
        
    }
}