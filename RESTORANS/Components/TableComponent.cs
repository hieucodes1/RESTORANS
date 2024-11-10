using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;

namespace RESTORANS.Components
{
    [ViewComponent(Name ="Table")]
    public class TableComponent:ViewComponent
    {
        private Datacontext _context;
        public TableComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofTable = (from item in _context.Tables
                                 where (item.IActive == true) && (item.Statust == 1)
                                 orderby item.TableOrder descending
                                 select item).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofTable));
        }
    }
}
