using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;

namespace RESTORANS.Areas.Admin.Components
{
    [ViewComponent(Name =("AdminMenu"))]
    public class AdminMenuComponent:ViewComponent
    {
        private Datacontext _context;
        public AdminMenuComponent(Datacontext context)
        {
            _context = context;
        }   
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mnList = (from item in _context.AdminMenus
                          where (item.IsActive == true)
                          orderby item.ItemOrder descending
                          select item).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", mnList));    
        }
    }
}
