using Application.Interface.FacadPattern;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.ViewComponents
{
    public class GetMetaTags : ViewComponent
    {
        private readonly ISeoFacad _SeoFacad;
        public GetMetaTags(ISeoFacad seoFacad)
        {
            _SeoFacad = seoFacad;
        }
        public IViewComponentResult Invoke(string PageName)
        {
            var Tag = _SeoFacad.ReturnMetatagsService.ReturnTagWithPageName(PageName);
            if (Tag.Success)
                ViewBag.Keywords = _SeoFacad.ReturnMetatagKeywordsService.Execute(Tag.Enything.Id);
            return View("GetMetaTags", Tag);
        }
    }
}
