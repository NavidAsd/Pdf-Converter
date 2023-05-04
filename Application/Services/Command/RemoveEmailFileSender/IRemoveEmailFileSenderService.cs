using Application.Interface;
using Common;

namespace Application.Services.Command.RemoveEmailFileSender
{
    public interface IRemoveEmailFileSenderService
    {
        ResultMessage Execute(long Id);
        ResultMessage PlusTryToSend(long Id);
    }
    public class RemoveEmailFileSenderService : IRemoveEmailFileSenderService
    {
        private readonly IPdfConverterContext _Context;
        public RemoveEmailFileSenderService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IRemoveEmailFileSenderService.Execute(long Id)
        {
            var result = _Context.EmailSenderFiles.Find(Id);
            if (result != null)
            {
                result.IsRemoved = true;
                result.RemoveTime = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                };
            }
            return new ResultMessage
            {
                Success = false,
            };
        }

        ResultMessage IRemoveEmailFileSenderService.PlusTryToSend(long Id)
        {
            var result = _Context.EmailSenderFiles.Find(Id);
            if (result != null)
            {
                result.TryToSend +=1;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                };
            }
            return new ResultMessage
            {
                Success = false,
            };
        }

    }
}
