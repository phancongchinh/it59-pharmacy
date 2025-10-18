using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT59_Pharmacy.Entities
{
    public class Auditable
    {
        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }


        // Navigation properties
        [ForeignKey("CreatedById")]
        public User CreatedById { get; set; }

        [ForeignKey("UpdatedById")]
        public User UpdatedById { get; set; }
    }
}
