using Application.Interface.FacadPattern;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EndPoint.ViewComponents
{
    public class GetAdditionalHelp : ViewComponent
    {
        private readonly IViewContextFacad _ViewFacad;
        public GetAdditionalHelp(IViewContextFacad viewFacad) 
        {
            _ViewFacad = viewFacad;
        }
        public async Task<IViewComponentResult> InvokeAsync(int Service)
        {
            return View("GetAdditionalHelp", await _ViewFacad.ReturnAdditionalHelpService.ReturnWithServiceTypeAsync(Service));
        }
    }
}
