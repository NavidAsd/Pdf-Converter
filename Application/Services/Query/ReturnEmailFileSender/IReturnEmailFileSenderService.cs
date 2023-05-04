using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Query.ReturnEmailFileSender
{
    public interface IReturnEmailFileSenderService
    {
        ResultMessage<List<ResultReturnEmailFileSenderDto>> Execute();
    }
    public class ResultReturnEmailFileSenderDto
    {
        public string FileName { set; get; }
        public string UserIp { set; get; }
        public string UserEmail { set; get; }
        public long Id { set; get; }
        public int TryToSend { set; get; }
    }
    public class ReturnEmailFileSenderService : IReturnEmailFileSenderService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnEmailFileSenderService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<List<ResultReturnEmailFileSenderDto>> IReturnEmailFileSenderService.Execute()
        {
            var result = _Context.EmailSenderFiles.Where(p => p.IsRemoved == false).Select(o => new ResultReturnEmailFileSenderDto
            {
                FileName=o.FileName,
                UserEmail=o.UserEmail,
                UserIp=o.UserIp,
                Id=o.Id,
                TryToSend=o.TryToSend,
            }).ToList();
            if(result.Count > 0)
            {
                return new ResultMessage<List<ResultReturnEmailFileSenderDto>>
                {
                    Success = true,
                    Enything = result
                };
            }
            return new ResultMessage<List<ResultReturnEmailFileSenderDto>>
            {
                Success = false,
                Enything = null
            };
        }
    }
}
