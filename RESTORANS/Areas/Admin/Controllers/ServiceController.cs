using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RESTORANS.Models;

namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly Datacontext _context;
        public ServiceController(Datacontext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            var sr = _context.Posts.Where(m=>m.Position == 2).OrderBy(m => m.PostID).ToList();
            return View(sr);
        }

        // thêm mới sevice
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
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        // Chính sửa service
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
                Text = "----select-----",
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
        // xem chi tiet service
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
        // xoa service
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
        // xoa service
        public IActionResult Delete(long id)
        {
            var DeletePost = _context.Posts.Find(id);
            if (DeletePost == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(DeletePost);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
