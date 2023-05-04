using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Services.Command.ChangeUserCommentState
{
    public interface IChangeUserCommentStateService
    {
        ResultMessage ChangeRemoveState(RequestChangeUserCommentStateDto request);
        ResultMessage ChangeAcceptState(RequestChangeUserCommentStateDto request);
        ResultMessage ChangeUserMessageState(RequestChangeUserCommentStateDto request);


    }
    public class RequestChangeUserCommentStateDto
    {
        public long Id { set; get; }
        public bool State { set; get; }
    }
    public class ChangeUserCommentStateService : IChangeUserCommentStateService
    {
        private readonly IPdfConverterContext _Context;
        public ChangeUserCommentStateService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IChangeUserCommentStateService.ChangeRemoveState(RequestChangeUserCommentStateDto request)
        {
            var result = _Context.UserComments.IgnoreQueryFilters().Where(p => p.Id == request.Id).FirstOrDefault();
            if (result != null)
            {
                if (result.IsRemoved == request.State)
                {
                    result.IsRemoved = !request.State;
                    if (!request.State)
                        result.RemoveTime = System.DateTime.Now;
                    _Context.SaveChanges();
                }
                return new ResultMessage { Success = true, Message = "Comment State SuccssFully Changed" };
            }
            return new ResultMessage { Success = false, Message = "Comment Not Found!" };
        }
        ResultMessage IChangeUserCommentStateService.ChangeAcceptState(RequestChangeUserCommentStateDto request)
        {
            var result = _Context.UserComments.IgnoreQueryFilters().Where(p => p.Id == request.Id).FirstOrDefault();
            if (result != null)
            {
                result.Accepted = request.State;
                _Context.SaveChanges();
                return new ResultMessage { Success = true, Message = "Comment State SuccssFully Changed" };
            }
            return new ResultMessage { Success = false, Message = "Comment Not Found!" };
        }
        ResultMessage IChangeUserCommentStateService.ChangeUserMessageState(RequestChangeUserCommentStateDto request)
        {
            var result = _Context.UserMessages.IgnoreQueryFilters().Where(p => p.Id == request.Id).FirstOrDefault();
            if (result != null)
            {
                if (result.IsRemoved == request.State)
                {
                    result.IsRemoved = !request.State;
                    if (!request.State)
                        result.RemoveTime = System.DateTime.Now;
                    _Context.SaveChanges();
                }
                return new ResultMessage { Success = true, Message = " State SuccssFully Changed" };
            }
            return new ResultMessage { Success = false, Message = " Not Found!" };
        }
    }
}
