using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;

namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private Datacontext _context;
        public MemberController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var members = _context.Posts.Where(m=>m.Position == 5).OrderBy(m => m.PostID).ToList();
            return View(members);
        }
        // thêm mới bài viết
        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        public IActionResult Create(Post member)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(member);
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
        public IActionResult Edit(Post member)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Update(member);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var member = _context.Posts.Find(id);

            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var member = _context.Posts.Find(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var DeleteMember = _context.Posts.Find(id);
            if (DeleteMember == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(DeleteMember);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
