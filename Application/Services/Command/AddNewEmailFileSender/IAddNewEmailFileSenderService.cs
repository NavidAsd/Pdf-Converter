using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Command.AddNewEmailFileSender
{
    public interface IAddNewEmailFileSenderService
    {
        Task<ResultMessage> ExecuteAsync(RequestAddNewEmailFileSenderDto request);
    }
    public class RequestAddNewEmailFileSenderDto
    {
        public string UserEmail { set; get; }
        public string FileName { set; get; }
        public string UserIp { set; get; }
    }
    public class AddNewEmailFileSenderService : IAddNewEmailFileSenderService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewEmailFileSenderService(IPdfConverterContext context)
        {
            _Context = context;
        }
        async Task<ResultMessage> IAddNewEmailFileSenderService.ExecuteAsync(RequestAddNewEmailFileSenderDto request)
        {
            var check = _Context.EmailSenderFiles.IgnoreQueryFilters().Where(p => p.FileName == request.FileName && p.UserEmail == request.UserEmail).FirstOrDefault();
            if (check != null)
            {
                if (check.IsRemoved)
                {
                    check.IsRemoved = false;
                    check.TryToSend = 1;
                    _Context.SaveChanges();
                }
                return new ResultMessage { Success = true, Message = "Your email has been successfully registered and the file will be sent to you in the next few minutes" };
            }
            Domain.Entities.Files.EmailSenderFiles senderFiles = new Domain.Entities.Files.EmailSenderFiles
            {
                FileName = request.FileName,
                UserEmail = request.UserEmail,
                UserIp = request.UserIp,
                IsRemoved = false,
                InsertTime = System.DateTime.Now,
                TryToSend = 1,
            };
            try
            {
                await _Context.EmailSenderFiles.AddAsync(senderFiles);
                _Context.SaveChanges();
                return new ResultMessage { Success = true, Message = "Your email has been successfully registered and the file will be sent to you in the next few minutes" };

            }
            catch
            {
                return new ResultMessage { Success = false, Message = "Something Wrong Pleas Try Again" };

            }
        }
    }
}
