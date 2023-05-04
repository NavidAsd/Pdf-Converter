using Microsoft.AspNetCore.Mvc;

namespace EndPoint.ViewComponents
{
    public class GetCookie : ViewComponent
    {
        public GetCookie() { }
        public IViewComponentResult Invoke()
        {
            if (Request.Cookies[Common.GetPath.GetCookieKey()] == null)
                ViewBag.State = false;
            else
                ViewBag.State = true;
            return View("GetCookie");
        }
    }
}
