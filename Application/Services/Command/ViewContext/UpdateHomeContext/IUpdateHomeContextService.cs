using Application.Interface;
using Common;

namespace Application.Services.Command.ViewContext.UpdateHomeContext
{
    public interface IUpdateHomeContextService
    {
        ResultMessage Execute(RequestUpdateHomeContextDto request);
    }
    public class RequestUpdateHomeContextDto
    {
        public long Id { set; get; }
        public string TopTitleText { set; get; }
        public string MainServicesH2Text { set; get; }
        public string MainServicesPText { set; get; }
        public string ServicesInfoH1Text { set; get; }
        public string ServicesInfoPText { set; get; }
    }
    public class UpdateHomeContextService : IUpdateHomeContextService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateHomeContextService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateHomeContextService.Execute(RequestUpdateHomeContextDto request)
        {
            try
            {
                var result = _Context.HomePageContexts.Find(request.Id);
                if (result != null)
                {
                    if (!string.IsNullOrWhiteSpace(request.MainServicesH2Text))
                        result.MainServicesH2Text = request.MainServicesH2Text;
                    if (!string.IsNullOrWhiteSpace(request.MainServicesPText))
                        result.MainServicesPText = request.MainServicesPText;
                    if (!string.IsNullOrWhiteSpace(request.ServicesInfoH1Text))
                        result.ServicesInfoH1Text = request.ServicesInfoH1Text;
                    if (!string.IsNullOrWhiteSpace(request.ServicesInfoPText))
                        result.ServicesInfoPText = request.ServicesInfoPText;
                    if (!string.IsNullOrWhiteSpace(request.TopTitleText))
                        result.TopTitleText = request.TopTitleText;
                    result.LastUpdate = System.DateTime.Now;
                    _Context.SaveChanges();
                    return new ResultMessage
                    {
                        Success = true,
                        Message="Context SuccessFully Updated"
                    };
                }
                Domain.Entities.OtherContext.HomePageContext HomeContext = new Domain.Entities.OtherContext.HomePageContext
                {
                    MainServicesH2Text = request.MainServicesH2Text,
                    MainServicesPText = request.MainServicesPText,
                    ServicesInfoH1Text = request.ServicesInfoH1Text,
                    ServicesInfoPText = request.ServicesInfoPText,
                    TopTitleText = request.TopTitleText,
                };
                _Context.HomePageContexts.Add(HomeContext);
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Context SuccessFully Updated"
                }; 
            }
            catch
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "Something Worng Please Try Again"
                };
            }
        }
    }
}
