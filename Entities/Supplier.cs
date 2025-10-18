using System.ComponentModel.DataAnnotations;

namespace IT59_Pharmacy.Entities
{
    public class Supplier : Auditable
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;
        
        [StringLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [StringLength(100)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Please enter a valid email address!")]    
        public string Email { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string ContactPerson { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
    }
}
