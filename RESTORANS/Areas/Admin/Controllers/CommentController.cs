using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RESTORANS.Models;

namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly Datacontext _context;
        public CommentController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var com = _context.Posts.Where(m => m.Position == 4).OrderBy(n => n.PostID).ToList();
            return View(com);
        }
        // thêm mới bài viết
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post comment)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(comment);
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
            var comment= _context.Posts
                        .FirstOrDefault(m => (m.PostID == id) && (m.IsActive == true));
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var comment = _context.Posts.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var DeleteComment = _context.Posts.Find(id);
            if (DeleteComment == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(DeleteComment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
