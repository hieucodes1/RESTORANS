using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTORANS.Areas.Admin.Models;

namespace RESTORANS.Models
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ViewPostMenu> ViewPostMenus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Customers> Customerss { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ViewOrderCustomer> ViewOrderCustomers { get; set; }
    }
}
