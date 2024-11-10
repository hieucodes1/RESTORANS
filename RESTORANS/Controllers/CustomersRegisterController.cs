using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTORANS.Models;
using RESTORANS.Utilities;

namespace RESTORANS.Controllers
{
    public class CustomersRegisterController : Controller
    {

        private readonly Datacontext _context;
        public CustomersRegisterController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Customers user)
        {
            if (user == null)
            {
                return NotFound();
            }
            // kiểm tra sự tồn tại của email  trong cơ sở dữ liệu
            var check = _context.Customerss.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                // hiển thị thông báo có thể làm cách khác

                function._MessagerEmail = "Trùng Email!";
                return RedirectToAction("Index", "CustomersRegister");


            }
            // nếu không có thì thêm vào cơ sở dữ liệu
            function._MessagerEmail = string.Empty;
            user.PassWord = function.MD5Password(user.PassWord);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "CustomersLogin");
        }
    }
}
