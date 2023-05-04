using Application.Interface;
using Common;

namespace Application.Services.Command.ViewContext.UpdateAdditionalHelp
{
    public interface IUpdateAdditionalHelpService
    {
        ResultMessage UpdateBasic(RequestUpdateAdditionalHelpDto request);
        ResultMessage UpdateOnePart(RequestUpdateOnePartAdditionalHelpDto request);
        ResultMessage ChangeState(long Id, bool State);
    }
    public class RequestUpdateOnePartAdditionalHelpDto
    {
        public long Id { set; get; }
        public int Type { set; get; }// 1 =left; 2 =center; 3 =right; 
        public string BlockTitle { set; get; }
        public string Text { set; get; }
    }
    public class RequestUpdateAdditionalHelpDto
    {
        public long Id { set; get; }
        public string Title { set; get; }

        public string ServiceDescription { set; get; }
        public string HelpContext { set; get; }

    }
    public class UpdateAdditionalHelpService : IUpdateAdditionalHelpService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateAdditionalHelpService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateAdditionalHelpService.UpdateBasic(RequestUpdateAdditionalHelpDto request)
        {
            var result = _Context.AdditionalHelps.Find(request.Id);
            if (result != null)
            {
                result.Title = request.Title;
                result.ServiceDescription = request.ServiceDescription;
                result.HelpContext = request.HelpContext;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Changes Saved"
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Item Not Found"
            };
        }
        ResultMessage IUpdateAdditionalHelpService.UpdateOnePart(RequestUpdateOnePartAdditionalHelpDto request)
        {
            var result = _Context.AdditionalHelps.Find(request.Id);
            if (result != null)
            {
                if (request.Type == 1)
                {
                    result.BlockTitleleft = request.BlockTitle;
                    result.Textleft = request.Text;
                }
                else if (request.Type == 2)
                {
                    result.BlockTitlecenter = request.BlockTitle;
                    result.Textcenter = request.Text;
                }
                else if (request.Type == 3)
                {
                    result.BlockTitleright = request.BlockTitle;
                    result.Textright = request.Text;
                }
                else
                {
                    return new ResultMessage
                    {
                        Success = false,
                        Message = "Item Not Found"
                    };
                }
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Changes Saved"
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Item Not Found"
            };
        }
        ResultMessage IUpdateAdditionalHelpService.ChangeState(long Id, bool State)
        {
            var result = _Context.AdditionalHelps.Find(Id);
            if (result != null)
            {
                result.IsRemoved = State;
                if (State)
                    result.RemoveTime = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = ""
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Item Not Found"
            };
        }
    }
}
