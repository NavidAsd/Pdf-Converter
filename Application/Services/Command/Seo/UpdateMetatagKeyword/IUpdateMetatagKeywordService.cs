using Application.Interface;
using Common;

namespace Application.Services.Command.Seo.UpdateMetatagKeyword
{
    public interface IUpdateMetatagKeywordService
    {
        ResultMessage UpdateKey(RequestUpdateKeywordDto request);
        ResultMessage ChangeRemoveState(RequestChangeRemoveStateKeywordDto request);
    }
    public class RequestUpdateKeywordDto
    {
        public long Id { set; get; }
        public string Key { set; get; }
    }
    public class RequestChangeRemoveStateKeywordDto
    {
        public long Id { set; get; }
       // public bool State { set; get; }
    }
    public class UpdateMetatagKeywordService : IUpdateMetatagKeywordService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateMetatagKeywordService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateMetatagKeywordService.UpdateKey(RequestUpdateKeywordDto request)
        {
            var result = _Context.Keywords.Find(request.Id);
            if(result != null)
            {
                result.Key = request.Key;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Item Successfully Updated"
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Item Not Found"
            };

        }
        ResultMessage IUpdateMetatagKeywordService.ChangeRemoveState(RequestChangeRemoveStateKeywordDto request)
        {
            var result = _Context.Keywords.Find(request.Id);
            if(result != null)
            {
                try
                {
                    _Context.Keywords.Remove(result);
                    _Context.SaveChanges();
                    return new ResultMessage
                    {
                        Success = true,
                        Message = "Item Status Changed"
                    };
                }
                catch { }
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Item Not Found"
            };

        }
    }
}
