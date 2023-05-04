using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Query.ReturnUserMessages
{
    public interface IReturnUserMessagesService
    {
        Task<ResultMessage<ResultReturnUserMessagesDto>> ReturnAll(RequestReturnUserMessagesDto request);

    }
    public class RequestReturnUserMessagesDto
    {
        public string Filter { set; get; }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
        public bool IsRemoved { set; get; }
    }
    public class ResultReturnUserMessagesDto
    {
        public string Filter { set; get; }
        public int PageIndex { set; get; }
        public int TotalRow { set; get; }
        public int PageSize { set; get; }
        public List<Domain.Entities.Details.UserMessages> UserMessages { get; set; }
    }
    public class ReturnUserMessagesService : IReturnUserMessagesService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnUserMessagesService(IPdfConverterContext context)
        {
            _Context = context;
        }
        async Task<ResultMessage<ResultReturnUserMessagesDto>> IReturnUserMessagesService.ReturnAll(RequestReturnUserMessagesDto request)
        {
            try
            {
                int totalrow = 0;
                var result = _Context.UserMessages.Where(p=>p.Message != null);
                if (!string.IsNullOrWhiteSpace(request.Filter))
                    result = result.Where(p => p.Email.Contains(request.Filter));
                var messages = result.ToPaged(request.PageIndex, request.PageSize, out totalrow);
                return new ResultMessage<ResultReturnUserMessagesDto>
                {
                    Success = true,
                    Enything = new ResultReturnUserMessagesDto
                    {
                        Filter = request.Filter,
                        PageIndex = request.PageIndex,
                        TotalRow = totalrow,
                        PageSize= request.PageSize,
                        UserMessages =  messages.ToList(),
                    },
                };
            }
            catch
            {
                return new ResultMessage<ResultReturnUserMessagesDto>
                {
                    Success = false,
                    Message = "No Item Found"
                };
            }
        }
    }
}
