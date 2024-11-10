using Microsoft.AspNetCore.Mvc;
using RESTORANS.Areas.Admin.Models;
using RESTORANS.Models;
using RESTORANS.Utilities;
namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly Datacontext _context;
        public RegisterController(Datacontext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if(user == null)
            {
                return NotFound();
            }
            // kiểm tra sự tồn tại của email  trong cơ sở dữ liệu
            var check = _context.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if(check != null)
            {
                // hiển thị thông báo có thể làm cách khác
                
                function._MessagerEmail = "Trùng Email!";
                return RedirectToAction("Index", "Register");

               
            }
            // nếu không có thì thêm vào cơ sở dữ liệu
            function._MessagerEmail = string.Empty;
            user.Password = function.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index","Login");
        }
    }
}
