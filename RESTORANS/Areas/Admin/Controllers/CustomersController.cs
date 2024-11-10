using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RESTORANS.Models;

namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomersController : Controller
    {
        private readonly Datacontext _context;
        public CustomersController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var customer = _context.Customerss.OrderBy(m => m.CustomersID).ToList();
            return View(customer);
        }

        // xem chi tiết tài khoản
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Customer = _context.Customerss
                        .FirstOrDefault(m => (m.CustomersID == id) && (m.IsActive == true));
            if (Customer == null)
            {
                return NotFound();
            }
            return View(Customer);
        }

        // Xóa tài khoản khách hàng
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var customer = _context.Customerss.Find(id);
            if(customer == null)
            {
                return NotFound();
            }

            return View(customer);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            

            var customer = _context.Customerss.Find(id);
            if(customer == null)
            {
                return NotFound();
            }
            _context.Customerss.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
