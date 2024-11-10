using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RESTORANS.Models;
using RESTORANS.Utilities;

namespace RESTORANS.Controllers
{
    public class CustomerCommentController : Controller
    {
        private readonly Datacontext _context;
        public CustomerCommentController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Post comment)
        {
            // kiểm tra đăng nhập trước khi bình luận

            if (!function.IsLogin())
            {
                return RedirectToAction("Index", "CustomersLogin");
            }
            if (ModelState.IsValid)
            {
                comment.CreatedDate = DateTime.Now;
                _context.Posts.Add(comment);
                _context.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
