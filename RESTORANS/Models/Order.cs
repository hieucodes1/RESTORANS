using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTORANS.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public long OrderID { get; set; }
        public int? CustomersID { get; set; }
        public int Statust { get; set; }
        public int People { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public bool? Delete { get; set; }
        public bool? Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool? PaymentID { get; set; }
        public string? Description { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? Hour { get; set; }
    }
}
