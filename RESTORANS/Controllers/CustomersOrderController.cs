using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RESTORANS.Models;
using RESTORANS.Utilities;

namespace RESTORANS.Controllers
{
    public class CustomersOrderController : Controller
    {
        private readonly Datacontext _context;
        public CustomersOrderController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var od = _context.Orders.Where(m=>m.CustomersID == function._UserID ).OrderBy(n=>n.OrderID).ToList();
            return View(od);
        }

        public IActionResult Create()
        {
            // kiểm tra khách hàng đăng nhập trước khi đặt bàn
            if (!function.IsLogin())
            {
                return RedirectToAction("Index", "CustomersLogin");
            }

            var mnList = (from m in _context.Customerss
                          select new SelectListItem()
                          {
                              Text = m.FullName,
                              Value = m.CustomersID.ToString()
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

        public IActionResult Create(Order order)
        {
           
            if (function._UserName == null)
            { 
                return RedirectToAction("Index", "CustomersLogin");
            }
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;   
                _context.Orders.Add(order);
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
            var mn = _context.Orders.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.Customerss
                          select new SelectListItem()
                          {
                              Text = m.FullName,
                              Value = m.CustomersID.ToString()
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
        public IActionResult Edit(Order mn)
        {
            if (ModelState.IsValid)
            {
                mn.OrderDate = DateTime.Now;
                _context.Orders.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }


        // Xem chi tiết đơn hàng
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _context.Orders
                        .FirstOrDefault(m => (m.OrderID == id) && (m.IsActive == true));
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // hủy đơn hàng
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.Customerss
                          select new SelectListItem()
                          {
                              Text = m.FullName,
                              Value = m.CustomersID.ToString()
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "--- select -----",
                Value = String.Empty
            });
            ViewBag.mnList = mnList;
            return View(order);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var DeleteOrder = _context.Orders.Find(id);
            if (DeleteOrder == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(DeleteOrder);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
