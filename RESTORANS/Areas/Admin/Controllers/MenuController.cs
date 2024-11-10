using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RESTORANS.Models;

namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly Datacontext _context;
        public MenuController(Datacontext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            var mnList = _context.Menus.Where(m=>m.Position ==1).OrderBy(m => m.MenuID).ToList();
            return View(mnList);
        }

        //thêm mới menu
        public IActionResult Create()
        {
            var mnList = (from m in _context.Menus.Where(m=>m.Position == 1)
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "---- select-----",
                Value = "0"
            });
            ViewBag.mnList = mnList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Menu mn)
        {
            if (ModelState.IsValid)
            {
                _context.Menus.Add(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
        // Chính sửa menu
        public IActionResult Edit(int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            var mn = _context.Menus.Find(id);
            if(mn == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.Menus.Where(m => m.Position == 1)
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString()
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "--- select -----",
                Value = "0"
            });
            ViewBag.mnList = mnList;
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Menu mn)
        {
            if (ModelState.IsValid)
            {
                _context.Menus.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var menu = _context.Menus
                        .FirstOrDefault(m => (m.MenuID == id) && (m.IsActive == true));
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }
        public IActionResult Delete(int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            var mn = _context.Menus.Find(id);
            if(mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleMenu = _context.Menus.Find(id);
            if(deleMenu == null)
            {
                return NotFound();
            }
            _context.Menus.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
