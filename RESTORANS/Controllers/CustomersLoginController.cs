using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTORANS.Models;
using RESTORANS.Utilities;

namespace RESTORANS.Controllers
{
    public class CustomersLoginController : Controller
    {
        private readonly Datacontext _context;
        public CustomersLoginController(Datacontext context)
        {
            _context = context;
        }

        

         
        public IActionResult Index()
        {
            // kiểm tra khách hàng đăng nhập trước khi đặt bàn
            if (function.IsLogin())
                return RedirectToAction("Create", "CustomersOrder");

            return View();

        }
        [HttpPost]

        public IActionResult Index(Customers user)
        {
            if (user == null)
            {
                return NotFound();
            }
            // mã hóa mật khẩu trước khi kiểm tra
            string pw = function.MD5Password(user.PassWord);
            // kiểm tra sự tồn tại của email trong cơ sở dữ liệu
            var check = _context.Customerss.Where(m => (m.Email == user.Email) && (m.PassWord == pw)).FirstOrDefault();
            if (check == null)
            {
                // hiển thị thông báo có thể làm cách khác

                function._Messager = "Lỗi Email hoặc Password !";
                return RedirectToAction("Index", "CustomersLogin");
            }
            // vào  nếu đúng use và mật khẩu nó sẽ load lên tài khoản
            function._Messager = string.Empty;
            function._UserID = check.CustomersID;
            function._UserName = string.IsNullOrEmpty(check.FullName) ? string.Empty : check.FullName;
            function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            function._Images = string.IsNullOrEmpty(check.Thumb) ? string.Empty : check.Thumb;

            return RedirectToAction("Index", "Home");
        }
    }
}
