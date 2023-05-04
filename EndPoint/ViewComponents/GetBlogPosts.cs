using Application.Interface.FacadPattern;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.ViewComponents
{
    public class GetBlogPosts : ViewComponent
    {
        private readonly IViewContextFacad _ViewFacad;
        public GetBlogPosts(IViewContextFacad viewFacad)
        {
            _ViewFacad = viewFacad;
        }
        public IViewComponentResult Invoke(int? Category)
        {
            Common.InitialData Data = new Common.InitialData();
            ViewBag.ServiceName = Data.ReturnServiceNameForBlogContent(Category);
            ViewBag.Category = Category;
            return View("GetBlogPosts", _ViewFacad.ReturnBlogPostsService.Execute(Common.GetPath.GetBlogPostCount(), Category,0));
        }
    }
}
