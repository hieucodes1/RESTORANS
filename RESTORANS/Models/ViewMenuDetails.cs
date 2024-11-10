using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTORANS.Models
{
    [Table("View_Menu_Details")]
    public class ViewMenuDetails
    {
        [Key]
        public long DetailsID { get; set; }
        public int IActive { get; set; }
        public int Statust { get; set; }
        public int DetailsOrder { get; set; }
        public long PostID { get; set; }
        public string? Contents { get; set; }
        public string? Title { get; set; }
        public string? Images { get; set; }
        public string? Position { get; set; }
        public int MenuID { get; set; }
    }
}
