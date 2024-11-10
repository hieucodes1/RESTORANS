using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;
using RESTORANS.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace RESTORANS.Controllers
{
    public class AcountInforController : Controller
    {
        private readonly Datacontext _context;
        public AcountInforController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index ()
        {
            var account = _context.Customerss.Where(m => m.CustomersID == function._UserID).FirstOrDefault();
            if (account == null)
            {
                return NotFound();
            }
           
            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customers mn)
        {
            if (mn == null)
            {
                return NotFound();
            }
            
            // mã hóa mật khẩu trước khi lưu
            function._MessagerEmail = string.Empty;
            mn.PassWord = function.MD5Password(mn.PassWord);

            _context.Update(mn);
            _context.SaveChanges();
            return RedirectToAction("Index", "CustomersLogout");
        }
    }
}
