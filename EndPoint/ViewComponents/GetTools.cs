using Microsoft.AspNetCore.Mvc;

namespace EndPoint.ViewComponents
{
    public class GetTools : ViewComponent
    {
        public GetTools(){}
        public IViewComponentResult Invoke()
        {
            return View("GetTools");
        }
    }
}
