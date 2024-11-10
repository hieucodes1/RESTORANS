using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;

namespace RESTORANS.Components
{
    [ViewComponent(Name ="MenuFooter")]
    public class MenuFooterComponent:ViewComponent
    {
        private Datacontext _context;
        public MenuFooterComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from item in _context.Menus
                              where (item.IsActive == true)&&(item.Position == 2) 
                              select item).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));
        }
    }
}
