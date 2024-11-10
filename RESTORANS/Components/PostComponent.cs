using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;

namespace RESTORANS.Components
{
    [ViewComponent(Name ="Post")]
    public class PostComponent: ViewComponent
    {
        private Datacontext _context;
        public PostComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from item in _context.Posts
                              where (item.IsActive == true) && (item.Statust == 1) && (item.Position == 1)
                              orderby item.PostID descending
                              select item).Take(3).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
