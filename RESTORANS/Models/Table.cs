using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTORANS.Models
{
    [Table("Table")]
    public class Table
    {
        [Key]
        public long TableID { get; set; }
        public bool IActive { get; set; }
        public int Statust { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Request { get; set; }
        public DateTime? DateTime { get; set; }
        public int TableOrder { get; set; }
        public string? Phone { get; set; }
        public int People { get; set; }
    }
}
