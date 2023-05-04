using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Command.Seo.AddNewMetatagKeywords
{
    public interface IAddNewKeywordsService
    {
        ResultMessage Execute(List<RequestAddNewKeywordsDto> request);
        Task<ResultMessage> AddNewMetatagsForAllPages(string Tags);
    }
    public class RequestAddNewKeywordsDto
    {
        public long MetaId { set; get; }
        public string Keyword { set; get; }
    }
    public class AddNewKeywordsService : IAddNewKeywordsService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewKeywordsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IAddNewKeywordsService.Execute(List<RequestAddNewKeywordsDto> request)
        {
            Domain.Entities.Seo.Keywords Key;
            List<Domain.Entities.Seo.Keywords> Keys = new List<Domain.Entities.Seo.Keywords>();
            foreach (var item in request)
            {
                var uniqword = _Context.Keywords.Where(p => p.MetaId == item.MetaId && p.Key == item.Keyword).FirstOrDefault();
                if (uniqword == null)
                {
                    Key = new Domain.Entities.Seo.Keywords();
                    Key.MetaId = item.MetaId;
                    Key.Key = item.Keyword;
                    Key.IsRemoved = false;
                    Keys.Add(Key);
                }
                else if (uniqword.IsRemoved)
                    uniqword.IsRemoved = false;
            }
            try
            {
                _Context.Keywords.AddRange(Keys);
                _Context.SaveChanges();
                return new ResultMessage { Success = true, Message = "New Keywords Successfully Added" };
            }
            catch { return new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" }; }
        }
        async Task<ResultMessage> IAddNewKeywordsService.AddNewMetatagsForAllPages(string Tags)
        {
            try
            {
                var result = _Context.Metatags.Where(p => p.IsRemoved == false && p.PageName == "All").FirstOrDefault();
                if (result != null)
                {
                    result.Other = "\n" + Tags;
                }
                await _Context.SaveChangesAsync();
                return new ResultMessage
                {
                    Success = true,
                    Message = "New items were set for all pages",
                };
            }
            catch
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "Something Worng Please TryAgain",
                };
            }
        }
    }
}
