using Application.Interface.FacadPattern;
using Application.UseServices;
using EndPoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.ViewComponents
{
    public class GetViewContext : ViewComponent
    {
        private readonly IViewContextFacad _ViewFacad;
        private readonly IFeaturesDetailsFacad _FeaturesFacad;
        public GetViewContext(IViewContextFacad viewFacad, IFeaturesDetailsFacad featuresFacad)
        {
            _ViewFacad = viewFacad;
            _FeaturesFacad = featuresFacad;
        }
        public IViewComponentResult Invoke()
        {
            GetViewContextViewModel context = new GetViewContextViewModel
            {
                Context= UseReturnViewContext.Use(_ViewFacad),
                TotalConvert= _FeaturesFacad.ReturnTotalUseAvgService.Execute()
            };
            return View("GetViewContext", context);
        }
    }
}
