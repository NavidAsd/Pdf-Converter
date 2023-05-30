using Common;
using Application.Services.Query.ViewContext.ReturnSocialNetworks;
using Application.Interface.FacadPattern;
using Application.Services.Query.ViewContext.ReturnTermsOfUse;

namespace Application.UseServices
{
    public class ReturnViewContext
    {
        public ResultMessage<ResultReturnAllSocialNetworkDto> SocialNetworkAccounts { set; get; }
       // public ResultMessage<ResultReturnTermsOfUseDto> FooterContext { set; get; }
    }
    public static class UseReturnViewContext
    {

        public static ReturnViewContext Use(IViewContextFacad _ViewFacad)
        {
            ReturnViewContext Context = new ReturnViewContext();
            Context.SocialNetworkAccounts = _ViewFacad.ReturnAllSocialNetworks.Execute().Result;
            //Context.FooterContext = _ViewFacad.ReturnFooterContextService.Execute();
            return Context;
        }
    }
}
