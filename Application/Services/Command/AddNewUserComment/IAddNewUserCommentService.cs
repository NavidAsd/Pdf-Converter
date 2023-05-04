using Application.Interface;
using Common;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Command.AddNewUserComment
{
    public interface IAddNewUserCommentService
    {
        Task<ResultMessage<ResultAddNewUserCommentDto>> ExecuteAsync(RequestAddNewUserCommentDto request);
    }
    public class ResultAddNewUserCommentDto
    {
        public double AvgRate { set; get; }
        public int Service { set; get; }
    }
    public class RequestAddNewUserCommentDto
    {
        public string UserEmail { set; get; }
        public string UserName { set; get; }
        public string Message { set; get; }
        public int? Rate { set; get; }
        public int Service { set; get; }
    }
    public class AddNewUserCommentService : IAddNewUserCommentService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewUserCommentService(IPdfConverterContext context)
        {
            _Context = context;
        }
        async Task<ResultMessage<ResultAddNewUserCommentDto>> IAddNewUserCommentService.ExecuteAsync(RequestAddNewUserCommentDto request)
        {
            try
            {
                var uniqe = _Context.UserComments.Where(p => p.IsRemoved == false && p.UserEmail == request.UserEmail && p.Service == request.Service).FirstOrDefault();
                if (uniqe != null)
                {
                    uniqe.UserName = request.UserName;
                    uniqe.Message = request.Message;
                    uniqe.Rate = request.Rate;
                    uniqe.LastUpdate = System.DateTime.Now;
                    _Context.SaveChanges();
                }
                else
                {
                    Domain.Entities.Details.UserComments comments = new Domain.Entities.Details.UserComments
                    {
                        UserName = request.UserName,
                        Message = request.Message,
                        Rate = request.Rate,
                        Service = request.Service,
                        UserEmail = request.UserEmail,
                        IsRemoved = false,
                        InsertTime = System.DateTime.Now
                    };
                    await _Context.UserComments.AddAsync(comments);
                    _Context.SaveChanges();
                }
                var result = _Context.UserComments.Where(p => p.IsRemoved == false && p.Rate != null && p.Service == request.Service).ToList();
                return new ResultMessage<ResultAddNewUserCommentDto>
                {
                    Success = true,
                    Message = "Your comment was successfully submitted. Thank you for your attention",
                    Enything = new ResultAddNewUserCommentDto
                    {
                        Service = request.Service,
                        AvgRate = result.Count > 0 ? System.Convert.ToDouble((result.Sum(s => s.Rate)) / result.Count) : 4.5
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewUserCommentDto>
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again"
                };
            }
        }
    }
}