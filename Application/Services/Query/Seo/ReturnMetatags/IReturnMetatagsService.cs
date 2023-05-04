using Application.Interface;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Query.Seo.ReturnMetatags
{
    public interface IReturnMetatagsService
    {
        ResultMessage<ResultReturnMetatagsDto> ReturnAllTags(RequestReturnMetatagsDto request);
        ResultMessage<Metatags> ReturnTagForAdmin(long Id);
        ResultMessage<Metatags> ReturnTag(long Id);
        ResultMessage<Metatags> ReturnTagWithPageName(string PageName);

    }
    public class ResultReturnMetatagsDto
    {
        public string Filter { set; get; }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
        public int TotalRow { set; get; }
        public List<Metatags> Metatags { set; get; }
    }
    public class RequestReturnMetatagsDto
    {
        public string Filter { set; get; }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
    }
    public class Metatags
    {
        public long Id { set; get; }
        public string PageName { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Author { set; get; }
        public string Other { set; get; }
        public bool IsRemoved { set; get; }
        public DateTime? LastUpdate { set; get; }
    }
    public class ReturnMetatagsService : IReturnMetatagsService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnMetatagsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnMetatagsDto> IReturnMetatagsService.ReturnAllTags(RequestReturnMetatagsDto request)
        {
            int totalrow = 0;
            var Tags = _Context.Metatags.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Filter))
                Tags = Tags.Where(p => p.PageName.Contains(request.Filter) || p.Title.Contains(request.Filter) || p.Author.Contains(request.Filter)).AsQueryable();
            var result = Tags.ToPaged(request.PageIndex, request.PageSize, out totalrow);
            if (result != null)
            {
                return new ResultMessage<ResultReturnMetatagsDto>
                {
                    Success = true,
                    Enything = new ResultReturnMetatagsDto
                    {
                        Filter = request.Filter,
                        PageIndex = request.PageIndex,
                        PageSize = request.PageSize,
                        TotalRow = totalrow,
                        Metatags = result.Select(o => new Metatags
                        {
                            Id = o.Id,
                            PageName = o.PageName,
                            Title = o.Title,
                            Author = o.Author,
                            Description = o.Description,
                            LastUpdate=o.LastUpdate,
                            IsRemoved=o.IsRemoved,
                            Other=o.Other,
                        }).ToList(),
                    }
                };
            }
            return new ResultMessage<ResultReturnMetatagsDto>
            {
                Success = false,
                Message = "No Tags Found"
            };
        }
        ResultMessage<Metatags> IReturnMetatagsService.ReturnTag(long Id)
        {
            var result = _Context.Metatags.Where(p => p.Id == Id && p.IsRemoved == false).FirstOrDefault();
            if(result != null)
            {
                return new ResultMessage<Metatags>
                {
                    Success = true,
                    Enything = new Metatags
                    {
                        Id = result.Id,
                        Description = result.Description,
                        Author = result.Author,
                        Other=result.Other,
                        PageName = result.PageName,
                        Title = result.Title,
                        LastUpdate=result.LastUpdate,
                    }
                };
            }
            return new ResultMessage<Metatags>
            {
                Success = false,
                Message = "Item Not Found"
            };
        }
        ResultMessage<Metatags> IReturnMetatagsService.ReturnTagWithPageName(string PageName)
        {
            var result = _Context.Metatags.Where(p => p.PageName == PageName && p.IsRemoved == false).FirstOrDefault();
            if(result != null)
            {
                return new ResultMessage<Metatags>
                {
                    Success = true,
                    Enything = new Metatags
                    {
                        Id = result.Id,
                        Description = result.Description,
                        Author = result.Author,
                        Other=result.Other,
                        PageName = result.PageName,
                        Title = result.Title,
                        LastUpdate=result.LastUpdate,
                    }
                };
            }
            return new ResultMessage<Metatags>
            {
                Success = false,
                Message = "Item Not Found"
            };
        }
        ResultMessage<Metatags> IReturnMetatagsService.ReturnTagForAdmin(long Id)
        {
            var result = _Context.Metatags.Where(p => p.Id == Id).FirstOrDefault();
            if(result != null)
            {
                return new ResultMessage<Metatags>
                {
                    Success = true,
                    Enything = new Metatags
                    {
                        Id = result.Id,
                        Description = result.Description,
                        Author = result.Author,
                        Other=result.Other,
                        PageName = result.PageName,
                        Title = result.Title,
                        LastUpdate=result.LastUpdate,
                        IsRemoved = result.IsRemoved,
                    }
                };
            }
            return new ResultMessage<Metatags>
            {
                Success = false,
                Message = "Item Not Found"
            };
        }
    }
}
