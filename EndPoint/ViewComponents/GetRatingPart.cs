using Microsoft.AspNetCore.Mvc;

namespace EndPoint.ViewComponents
{
    public class GetRatingPart : ViewComponent
    {
        public GetRatingPart(){}
        public IViewComponentResult Invoke()
        {
            return View("GetRatingPart");
        }
    }
}
