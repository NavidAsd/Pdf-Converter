using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Application.Services.Query.Seo.ReturnMetatagKeywords
{
    public interface IReturnMetatagKeywordsService
    {
        ResultMessage<List<Keyword>> Execute(long MetaId);
        ResultMessage<ResultReturnMetatagKeywordsDto> ReturnForAdmin(RequestReturnMetatagKeywordsDto request);
    }
    public class ResultReturnMetatagKeywordsDto
    {
        public string Filter { set; get; }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
        public int TotalRow { set; get; }
        public List<Keyword> Keywords { set; get; }
    }
    public class Keyword
    {
        public long Id { set; get; }
        public long MetaId { set; get; }
        public string Key { set; get; }
        public DateTime InsertTime { set; get; }
        public DateTime? LastUpdate { set; get; }
    }
    public class RequestReturnMetatagKeywordsDto
    {
        public string Filter { set; get; }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
        public long MetaId { set; get; }
    }
    public class ReturnMetatagKeywordsService : IReturnMetatagKeywordsService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnMetatagKeywordsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<List<Keyword>> IReturnMetatagKeywordsService.Execute(long MetaId)
        {
            var result = _Context.Keywords.Where(p => p.MetaId == MetaId && p.IsRemoved == false).Select(o => new Keyword
            {
                Id = o.Id,
                MetaId = o.MetaId,
                Key = o.Key,
            }).ToList();
            if (result.Count > 0)
            {
                return new ResultMessage<List<Keyword>>
                {
                    Success = true,
                    Enything = result,
                };
            }
            return new ResultMessage<List<Keyword>>
            {
                Success = false,
                Message = "No Item Found"
            };

        }
        ResultMessage<ResultReturnMetatagKeywordsDto> IReturnMetatagKeywordsService.ReturnForAdmin(RequestReturnMetatagKeywordsDto request)
        {
            int totalrow = 0;
            var Keywords = _Context.Keywords.Where(p => p.MetaId == request.MetaId && p.IsRemoved == false).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Filter))
                Keywords = Keywords.Where(p => p.Key.Contains(request.Filter)).AsQueryable();
            var result = Keywords.ToPaged(request.PageIndex, request.PageSize, out totalrow);
            if (result != null)
            {
                return new ResultMessage<ResultReturnMetatagKeywordsDto>
                {
                    Success = true,
                    Enything = new ResultReturnMetatagKeywordsDto
                    {
                        Filter = request.Filter,
                        PageIndex = request.PageIndex,
                        PageSize = request.PageSize,
                        TotalRow = totalrow,
                        Keywords = result.Select(o => new Keyword
                        {
                            Id = o.Id,
                            MetaId = o.MetaId,
                            Key = o.Key,
                            InsertTime=o.InsertTime,
                            LastUpdate=o.LastUpdate,
                        }).ToList(),
                    }
                };
            }
            return new ResultMessage<ResultReturnMetatagKeywordsDto>
            {
                Success = false,
                Message = "No Item Found",
                Enything = null
            };
        }
    }
}
