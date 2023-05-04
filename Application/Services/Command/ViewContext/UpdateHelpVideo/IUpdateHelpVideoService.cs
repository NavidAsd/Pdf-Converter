using Application.Interface;
using Common;

namespace Application.Services.Command.ViewContext.UpdateHelpVideo
{
    public interface IUpdateHelpVideoService
    {
        ResultMessage Execute(RequestUpdateHelpVideoDto request);
    }
    public class RequestUpdateHelpVideoDto
    {
        public long Id { set; get; }
        public string VideoName { set; get; }
    }
    public class UpdateHelpVideoService:IUpdateHelpVideoService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateHelpVideoService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateHelpVideoService.Execute(RequestUpdateHelpVideoDto request)
        {
            var result = _Context.TreeHelpSteps.Find(request.Id);
            if(result != null)
            {
                result.VideoName = request.VideoName;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage { Success = true, Message = "New Video Successfully Saved" };
            }
            return new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" };
        }
    }
}
