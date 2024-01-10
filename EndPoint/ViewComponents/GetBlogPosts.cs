using Application.Interface.FacadPattern;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EndPoint.ViewComponents
{
    public class GetBlogPosts : ViewComponent
    {
        private readonly IViewContextFacad _ViewFacad;
        public GetBlogPosts(IViewContextFacad viewFacad)
        {
            _ViewFacad = viewFacad;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? Category)
        {
            Common.InitialData Data = new Common.InitialData();
            ViewBag.ServiceName = Data.ReturnServiceNameForBlogContent(Category);
            ViewBag.Category = Category;
            return View("GetBlogPosts", await _ViewFacad.ReturnBlogPostsFromDbService.GetPostsAsync(Common.GetPath.GetBlogPostCount(), Category, true));
        }
    }
}
