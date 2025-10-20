using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IT59_Pharmacy.Entities {
    
    public enum MedicineForm {
        Tablet,
        Capsule,
        Syrup,
        Injection,
        Ointment,
        Drops,
        Inhaler,
        Patch,
        Powder,
        Other
    }

    public enum MedicineUnit {
        Tablet,
        Bottle,
        Box,
        Strip,
        Vial,
        Ampoule,
        Tube,
        Sachet,
        Pack,
        Other
    }
    
    public class Medicine : Auditable{
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string Strength { get; set; }
        
        [Required]
        public bool IsPrescriptionRequired { get; set; }
        
        [StringLength(200)]
        public string Description { get; set; }
        
        [Required]
        public MedicineForm MedicineForm { get; set; } // Tablet, Capsule, Syrup,
        
        [Required]
        public MedicineUnit Unit { get; set; } // Per tablet, per bottle, etc
        
        public bool isActive { get; set; } = true;
        
        // Navigation properties
        public virtual ICollection<MedicineBatch> Batches { get; set; } = new List<MedicineBatch>();
        
        public virtual ICollection<MedicineCategory> Categories { get; set; } = new List<MedicineCategory>();        
    }
}