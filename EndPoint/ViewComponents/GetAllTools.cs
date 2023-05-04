using Microsoft.AspNetCore.Mvc;

namespace EndPoint.ViewComponents
{
    public class GetAllTools : ViewComponent
    {
        public GetAllTools(){}
        public IViewComponentResult Invoke()
        {
            return View("GetAllTools");
        }
    }
}
