using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RESTORANS.Areas.Admin.Models;
using RESTORANS.Models;

namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageChillController : Controller
    {
        private readonly Datacontext _context;
        public ManageChillController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var managechill = _context.AdminMenus.Where(m => m.ItemLevel == 2).OrderBy(n => n.AdminMenuID).ToList();
            return View(managechill);
        }

        public IActionResult Create()
        {
            var adList = (from m in _context.AdminMenus
                          where m.ItemLevel == 1
                          select new SelectListItem()
                          {
                              Text = m.ItemName,
                              Value = m.AdminMenuID.ToString()
                          }).ToList();
            adList.Insert(0, new SelectListItem()
            {
                Text = "----select-----",
                Value = String.Empty

            });
            ViewBag.adList = adList;

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
            var adList = (from m in _context.AdminMenus
                          where m.ItemLevel == 1
                          select new SelectListItem()
                          {
                              Text = m.ItemName,
                              Value = m.AdminMenuID.ToString()
                          }).ToList();
            adList.Insert(0, new SelectListItem()
            {
                Text = "----select-----",
                Value = String.Empty

            });
            ViewBag.adList = adList;
            
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
