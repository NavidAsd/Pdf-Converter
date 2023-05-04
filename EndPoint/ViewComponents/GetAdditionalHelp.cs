using Application.Interface.FacadPattern;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.ViewComponents
{
    public class GetAdditionalHelp : ViewComponent
    {
        private readonly IViewContextFacad _ViewFacad;
        public GetAdditionalHelp(IViewContextFacad viewFacad) 
        {
            _ViewFacad = viewFacad;
        }
        public IViewComponentResult Invoke(int Service)
        {
            return View("GetAdditionalHelp", _ViewFacad.ReturnAdditionalHelpService.ReturnWithServiceType(Service));
        }
    }
}
