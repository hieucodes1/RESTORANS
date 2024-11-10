using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RESTORANS.Models;

namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BillController : Controller
    {
        private readonly Datacontext _context;
        public BillController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var order = _context.ViewOrderCustomers.ToList();
            return View(order);
        }

        // Xóa danh mục
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Orders.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.Customerss
                          select new SelectListItem()
                          {
                              Text = m.FullName,
                              Value = m.CustomersID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "---- select-----",
                Value = "0"
            });
            ViewBag.mnList = mnList;
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var delebill = _context.Orders.Find(id);
            if (delebill == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(delebill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
