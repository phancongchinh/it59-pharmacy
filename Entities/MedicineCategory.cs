using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IT59_Pharmacy.Entities {
    public class MedicineCategory : Auditable {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Description { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
    }
}