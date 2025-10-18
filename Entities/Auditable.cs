using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT59_Pharmacy.Entities
{
    public class Auditable
    {
        public int? CreatedById { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? UpdatedById { get; set; }

        public DateTime? UpdatedDate { get; set; }

        // Navigation properties
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual User UpdatedBy { get; set; }
    }
}
