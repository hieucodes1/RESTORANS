﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTORANS.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        public int MenuOrder { get; set; }
        public int Levels { get; set; }
        public int ParentID { get; set; }
        public int Position { get; set; }
        public string? MenuName { get; set; }
        public string? ControllerName { get; set; }
        public string? Link { get; set; }
        public bool? IsActive { get; set; }
        public string? Icon { get; set; }
    }
}
