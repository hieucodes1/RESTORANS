using Microsoft.AspNetCore.Mvc;
using RESTORANS.Utilities;

namespace RESTORANS.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            function._UserID = 0;
            function._UserName = String.Empty;
            function._Email = String.Empty;
            function._Messager = String.Empty;
            function._MessagerEmail = String.Empty;
            function._Images = String.Empty;

            return RedirectToAction("Index", "Home");
        }
    }
}
