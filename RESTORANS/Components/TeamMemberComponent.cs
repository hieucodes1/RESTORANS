using Microsoft.AspNetCore.Mvc;
using RESTORANS.Models;

namespace RESTORANS.Components
{
    [ViewComponent(Name =("TeamMember"))]
    public class TeamMemberComponent: ViewComponent
    {
        private Datacontext _context;
        public TeamMemberComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMember = (from item in _context.Posts
                                where (item.IsActive == true) && (item.Statust == 1) && (item.Position == 5)
                                orderby item.PostID descending
                                select item).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofMember));
        }
    }
}
