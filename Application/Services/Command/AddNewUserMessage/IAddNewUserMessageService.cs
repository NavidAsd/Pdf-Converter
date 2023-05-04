using Application.Interface;
using Common;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Command.AddNewUserMessage
{
    public interface IAddNewUserMessageService
    {
        Task<ResultMessage> Execute(AddNewUserMessageDto request);
    }
    public class AddNewUserMessageDto
    {
        public string Email { set; get; }
        public string Message { set; get; }
    }
    public class AddNewUserMessageService : IAddNewUserMessageService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewUserMessageService(IPdfConverterContext context)
        {
            _Context = context;
        }
        async Task<ResultMessage> IAddNewUserMessageService.Execute(AddNewUserMessageDto request)
        {
            var uniqe = _Context.UserMessages.Where(p => p.Email.Equals(request.Email) && p.Message.Equals(request.Message)).FirstOrDefault();
            if (uniqe != null)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "Your message has already been registered and will be answered by email soon"
                };
            }
            Domain.Entities.Details.UserMessages newMessage = new Domain.Entities.Details.UserMessages
            {
                Email = request.Email,
                Message = request.Message,
            };
            try
            {
                await _Context.UserMessages.AddAsync(newMessage);
                await _Context.SaveChangesAsync();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Your message has been registered and will be answered soon by email. Thank you for choosing us"
                };
            }
            catch
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "Something Worng Please TryAgain"
                };
            }
        }
    }
}
