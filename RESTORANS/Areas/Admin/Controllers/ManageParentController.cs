using Microsoft.AspNetCore.Mvc;
using RESTORANS.Areas.Admin.Models;
using RESTORANS.Models;
using System.Net.WebSockets;

namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageParentController : Controller
    {
        private readonly Datacontext _context;
        public ManageParentController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var category = _context.AdminMenus.Where(m=>m.ItemLevel == 1).OrderBy(m => m.AdminMenuID).ToList();
            return View(category);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdminMenu ad)
        {
            if (ModelState.IsValid)
            {
                _context.AdminMenus.Add(ad);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ad);
        }

        // chỉnh sửa danh mục
        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ad = _context.AdminMenus.Find(id);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AdminMenu ad)
        {
            if (ModelState.IsValid)
            {
                _context.AdminMenus.Update(ad);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ad);
        }

        // Xóa danh mục
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.AdminMenus.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var deleMenu = _context.AdminMenus.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _context.AdminMenus.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
