using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;

namespace RESTORANS.Components
{
    [ViewComponent(Name ="MenuDish")]
    public class MenuDishCoponent:ViewComponent
    {
        private Datacontext _context;
        public MenuDishCoponent(Datacontext context)
        {
            _context = context;
        }   
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofDish = (from item in _context.Posts
                              where (item.IsActive == true) && (item.Statust == 1) && (item.Position == 3)
                              orderby item.PostID descending
                              select item).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofDish));
        }
    }
}
