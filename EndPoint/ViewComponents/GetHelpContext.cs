using Application.Interface.FacadPattern;
using Application.Services.Query.ReturnFeatureDetails;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.ViewComponents
{
    public class GetHelpContext : ViewComponent
    {
        private readonly IViewContextFacad _ViewFacad;
        public GetHelpContext(IViewContextFacad viewFacad) 
        {
            _ViewFacad = viewFacad;
        }
        public IViewComponentResult Invoke(Common.ResultMessage<ResultReturnFeatureDetailsDto> Features)
        {
            ViewBag.FetureDetails = Features;
            ViewBag.Images = _ViewFacad.ReturnServiceImage.ReturnServiceImage(Features.Enything.Service);
            return View("GetHelpContext", _ViewFacad.ReturnAdditionalHelpService.ReturnWithServiceType(Features.Enything.Service));
        }
    }
}
