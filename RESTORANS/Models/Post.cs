﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTORANS.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public long PostID { get; set; }
        public int MenuID { get; set; }
        public int PostOrder { get; set; }
        public int Category { get; set; }
        public int Statust { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Contents { get; set; }
        public string? Images { get; set; }
        public string? Link { get; set; }
        public string? Author { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public string? Icon { get; set; }
        public int Position { get; set; }
        public string? Price { get; set; }
        public int MenuTag { get; set; }
        public string? FullName { get; set; }
    }
}
