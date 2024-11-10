using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RESTORANS.Models;

namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuDishController : Controller
    {
        private readonly Datacontext _context;
        public MenuDishController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var m = _context.Posts.Where(m => m.Position == 3).OrderBy(n => n.PostID).ToList();
            return View(m);
        }

        // Thêm mới thực đơn
        public IActionResult Create()
        {
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString()
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----select-----",
                Value = String.Empty

            });
            ViewBag.mnList = mnList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post menu)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(menu);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        // Chính sửa bài viết
        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Posts.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString()
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "--- select -----",
                Value = String.Empty
            });
            ViewBag.mnList = mnList;
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post mn)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _context.Posts
                        .FirstOrDefault(m => (m.PostID == id) && (m.IsActive == true));
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var DeleteMenu = _context.Posts.Find(id);
            if (DeleteMenu == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(DeleteMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
