using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;

namespace RESTORANS.Components
{
    [ViewComponent(Name ="Menu")]
    public class MenuComponent: ViewComponent
    {
        private Datacontext _context;
        public MenuComponent(Datacontext context)
        {
            _context = context;
        }   
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from item in _context.Menus
                              where (item.IsActive == true) && (item.Position == 1) 
                              select item).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));

        }
    }
}
