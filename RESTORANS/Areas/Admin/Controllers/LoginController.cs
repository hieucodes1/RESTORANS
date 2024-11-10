using Microsoft.AspNetCore.Mvc;
using RESTORANS.Areas.Admin.Models;
using RESTORANS.Models;
using RESTORANS.Utilities;

namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly Datacontext _context;
        public LoginController(Datacontext context)
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
            // mã hóa mật khẩu trước khi kiểm tra
            string pw = function.MD5Password(user.Password);
            // kiểm tra sự tồn tại của email trong cơ sở dữ liệu
            var check = _context.AdminUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                // hiển thị thông báo có thể làm cách khác

                function._Messager = "Lỗi Email hoặc Password !";
                return RedirectToAction("Index", "Login");
            }
            // vào trang admin nếu đúng use và mật khẩu 
            function._Messager = string.Empty;
            function._UserID = check.UserID;
            function._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;

            return RedirectToAction("Index", "Home");
        }
    }
}
