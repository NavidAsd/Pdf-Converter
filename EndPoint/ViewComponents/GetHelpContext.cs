using Application.Interface.FacadPattern;
using Application.Services.Query.ReturnFeatureDetails;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EndPoint.ViewComponents
{
    public class GetHelpContext : ViewComponent
    {
        private readonly IViewContextFacad _ViewFacad;
        public GetHelpContext(IViewContextFacad viewFacad) 
        {
            _ViewFacad = viewFacad;
        }
        public async Task<IViewComponentResult> InvokeAsync(Common.ResultMessage<ResultReturnFeatureDetailsDto> Features)
        {
            ViewBag.FetureDetails = Features;
            ViewBag.Images = await _ViewFacad.ReturnServiceImage.ReturnServiceImageAsync(Features.Enything.Service);
            return View("GetHelpContext", await _ViewFacad.ReturnAdditionalHelpService.ReturnWithServiceTypeAsync(Features.Enything.Service));
        }
    }
}
