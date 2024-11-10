using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTORANS.Models
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        public int CustomersID { get; set; }
        public string? FullName { get; set; }
        public int CustomerOrder { get; set; }
        public int Statust { get; set; }
        public bool? IsActive { get; set; }
        public int Phone { get; set; }
        public string? PassWord { get; set; }
        public string? Address { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Thumb { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? LastLogin { get; set; }

    }
}
