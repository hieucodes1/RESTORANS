using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;

namespace RESTORANS.Components
{
    [ViewComponent(Name ="CustomerComment")]
    public class CustomerCommentComponent: ViewComponent
    {
        private readonly Datacontext _context;
        public CustomerCommentComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofComment = (from item in _context.Posts
                                 where (item.IsActive == true) && (item.Statust == 1) && (item.Position == 4)
                                 orderby item.PostID descending
                                 select item).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default",listofComment));
        }
    }
}
