using Microsoft.AspNetCore.Mvc;
using RESTORANS.Utilities;

namespace RESTORANS.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            // thêm 2 lệnh sau vào các action của các controller  để kiểm tra trạng thái đăng nhập
            if (!function.IsLogin())
                return RedirectToAction("Index", "Login");


            return View();
        }
        
    }
}
