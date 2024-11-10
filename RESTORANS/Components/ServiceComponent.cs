using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;
using System.Net.WebSockets;

namespace RESTORANS.Components
{
    [ViewComponent(Name ="Service")]
    public class ServiceComponent:ViewComponent
    {
        private readonly Datacontext _context;
        public ServiceComponent(Datacontext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(/*string Searchstring = string.Empty*/)
        {
          /*  var query = _context.Posts
                        .Where((m.IsActive == true) && (m.Statust == 1) && (m.Position == 2))
            if (!string.IsNullOrEmpty(Searchstring))
            {
                query = query.Where(m => m.Title.Contains(Searchstring));
            }
            query = */
            var listofService = (from m in _context.Posts
                                 where (m.IsActive == true) && (m.Statust == 1) && (m.Position == 2)
                                 orderby m.PostID descending
                                 select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofService));
        }
    }
}
