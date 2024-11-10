using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;
using RESTORANS.Utilities;
using System.Diagnostics;

namespace RESTORANS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Datacontext _context;

        public HomeController(ILogger<HomeController> logger, Datacontext context)
        {
            _logger = logger;
            _context = context;
        }
        public class Searchdto { public string Searchstring { get; set; } }
        [HttpPost]
        public IActionResult Search(Searchdto searchdto)
        {
            if (searchdto.Searchstring != "")
            {
                var post = _context.Posts.Where(m => (m.Title.Contains(searchdto.Searchstring)) || (m.Contents.Contains(searchdto.Searchstring)) || m.FullName.Contains(searchdto.Searchstring)).ToList();
                return View(post);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
               
        }
        public IActionResult Index()
        {
            
         return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("/Post-{slug}-{id:long}.html", Name = "Details")]
        public IActionResult Details(long? id){
            if(id == null)
            {
                return NotFound();
            }
            var post = _context.Posts
                        .FirstOrDefault(m => (m.PostID == id) && (m.IsActive == true));
            if(post == null)
            {
                return NotFound();
            }
            return View(post);
         }
        [Route("/list-{slug}-{id:int}.html", Name ="list")]
        public IActionResult List(int? id)
        {
            if(id == 1 || id == 3)
            {
                return RedirectToAction("Index" , "Home");
            }
            if(id == null)
            {
                return NotFound();
            }
            var list = _context.ViewPostMenus
                        .Where(m => (m.MenuID == id) && (m.IsActive == true)).ToList();
            if(list == null)
            {
                return NotFound();
            }
            return View(list);
        }
        // dịch vụ
        [Route("/sevice-{slug}-{id:long}.html", Name = "Sevice")]
        public IActionResult Service(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var list = _context.Posts
                        .Where(m => (m.MenuID == id) && (m.IsActive == true)).ToList();
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}