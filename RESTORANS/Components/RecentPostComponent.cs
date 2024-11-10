using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;

namespace RESTORANS.Components
{
    [ViewComponent(Name ="RecentPost")]
    public class RecentPostComponent: ViewComponent
    {
        private Datacontext _context;
        public RecentPostComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofRecentPost = (from m in _context.Posts
                                    where (m.IsActive == true) && (m.Statust == 1) && (m.Position == 1)
                                    orderby m.PostID descending
                                    select m).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofRecentPost));

        }
    }
}
