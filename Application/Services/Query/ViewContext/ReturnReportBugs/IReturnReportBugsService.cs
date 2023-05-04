    using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Query.ViewContext.ReturnReportBugs
{
    public interface IReturnReportBugsService
    {
        ResultMessage<ResultReturnReportBugsDto> ReturnAll(RequestReturnReprteBugsDto request);
        ResultMessage<ResultReturnReportBugsDto> ReturnAllRemovedItems(RequestReturnReprteBugsDto request);
    }
    public class RequestReturnReprteBugsDto
    {
        public string Filter { set; get; }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
    }
    public class ResultReturnReportBugsDto
    {
        public int TotalRow { set; get; }
        public int PageIndex { set; get; }
        public int Pagesize { set; get; }
        public string Filter { set; get; }
        public List<ReportedBugs> Reported { set; get; }

    }
    public class ReportedBugs
    {
        public long Id { set; get; }
        public string Url { set; get; }
        public string Email { set; get; }
        public string Description { set; get; }
        public System.DateTime InserTime { set; get; }
    }
    public class ReturnReportBugsService : IReturnReportBugsService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnReportBugsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnReportBugsDto> IReturnReportBugsService.ReturnAll(RequestReturnReprteBugsDto request)
        {
            /*ReportedBugs bugs = new ReportedBugs
            {
                Id = 2,
                Url = "fd",
                Description = "fd",
                InserTime = System.DateTime.Now,
                Email = "fd",
            };
            List<ReportedBugs> ggg = new List<ReportedBugs>();
            ggg.Add(bugs);
            return new ResultMessage<ResultReturnReportBugsDto>
            {
                Success = true,
                Enything = new ResultReturnReportBugsDto {
                        Filter="",
                        PageIndex=4,
                        Pagesize=44,
                        TotalRow=1,
                        Reported = ggg
                    },
            };*/
            int totalrow = 0;
            var Bugs = _Context.ReportBugs.Where(p => p.IsRemoved == false).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Filter))
                Bugs = Bugs.Where(p => p.Url.Contains(request.Filter) || p.Email.Contains(request.Filter)).AsQueryable();
            var result = Bugs.ToPaged(request.PageIndex, request.PageSize, out totalrow);

            if (result != null)
            {
               /* var reported = result.Select(o => new ReportedBugs
                {
                    Id = o.Id,
                    Url = o.Url,
                    Description = o.ProblemStatement,
                    InserTime = o.InsertTime,
                    Email = o.Email,
                }).ToList();*/

                return new ResultMessage<ResultReturnReportBugsDto>
                {
                    Success = true,
                    Enything = new ResultReturnReportBugsDto
                    {
                        Filter = request.Filter,
                        PageIndex = request.PageIndex,
                        Pagesize = request.PageSize,
                        TotalRow = totalrow,
                        Reported = result.Select(o => new ReportedBugs
                        {
                            Id = o.Id,
                            Url = o.Url,
                            Description = o.ProblemStatement,
                            InserTime = o.InsertTime,
                            Email = o.Email,
                        }).ToList(),
                    },
                };
            }
            return new ResultMessage<ResultReturnReportBugsDto>
            {
                Success = false,
                Enything = null,
                Message = "No Bugs Found"
            };
        }
        ResultMessage<ResultReturnReportBugsDto> IReturnReportBugsService.ReturnAllRemovedItems(RequestReturnReprteBugsDto request)
        {
            int totalrow = 0;
            var Bugs = _Context.ReportBugs.Where(p => p.IsRemoved == true).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Filter))
                Bugs = Bugs.Where(p => p.Url.Contains(request.Filter) || p.Email.Contains(request.Filter)).AsQueryable();

            var result = Bugs.ToPaged(request.PageIndex, request.PageSize, out totalrow);

            if (result != null)
            {
                return new ResultMessage<ResultReturnReportBugsDto>
                {
                    Success = true,
                    Enything = new ResultReturnReportBugsDto
                    {
                        Filter=request.Filter,
                        PageIndex= request.PageIndex,
                        Pagesize=request.PageSize,
                        TotalRow=totalrow,
                        Reported= result.Select(o => new ReportedBugs
                        {
                            Id=o.Id,
                            Url=o.Url,
                            Description=o.ProblemStatement,
                            InserTime=o.InsertTime,
                            Email=o.Email,
                        }).ToList(),
                    },
                };
            }
            return new ResultMessage<ResultReturnReportBugsDto>
            {
                Success = false,
                Enything = null,
                Message = "No Bugs Found"
            };
        }
    }
}
