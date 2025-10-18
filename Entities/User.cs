using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT59_Pharmacy.Entities
{

    public enum UserRole
    {
        Administrator,
        WarehouseManager,
        Cashier
    }

    public class User : Auditable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Username must be between 6 and 20 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Full name must be between 6 and 50 characters")]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Please enter a valid email address!")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string PasswordHash { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        public UserRole Role { get; set; }
    }
}
