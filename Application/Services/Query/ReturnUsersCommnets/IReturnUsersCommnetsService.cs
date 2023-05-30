using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Query.ReturnUsersCommnets
{
    public interface IReturnUsersCommnetsService
    {
        ResultMessage<ResultReturnUsersCommnetsDto> ReturnAllAcceptedCommnetsForAdmin(RequestReturnUsersCommentsDto request);
        ResultMessage<ResultReturnUsersCommnetsDto> ReturnAllUnAcceptedCommnetsForAdmin(RequestReturnUsersCommentsDto request);
        ResultMessage<ResultReturnUsersCommnetsDto> ReturnAllDeletedCommnetsForAdmin(RequestReturnUsersCommentsDto request);
        Task<ResultMessage<List<UserComment>>> ReturnAllTopRatingCommnetsAsync(int ReturnCount, int? ServiceType);
        ResultMessage<UserComment> ReturnCommentForAdmin(long Id);
        ResultMessage<ResultReturnUnAcceptedCommentsCountDto> ReturnUnAcceptedCommentsCountForAdmin();
    }
    public class ResultReturnUnAcceptedCommentsCountDto
    {
        public long count { set; get; }
    }
    public class ResultReturnUsersCommnetsDto
    {
        public int TotalRow { set; get; }
        public int PageIndex { set; get; }
        public int Pagesize { set; get; }
        public string Filter { set; get; }
        public long count { set; get; } // for UnAccepted Comments
        public List<UserComment> UserComments { set; get; }
    }
    public class UserComment
    {
        public long Id { set; get; }
        public string UserEmail { set; get; }
        public string UserName { set; get; }
        public string Message { set; get; }
        public int? Rate { set; get; }
        public int Service { set; get; }
        public string ServiceName { set; get; }
        public bool IsRemoved { set; get; }
    }
    public class RequestReturnUsersCommentsDto
    {
        public string Filter { set; get; }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
    }
    public class ReturnUsersCommentsService : IReturnUsersCommnetsService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnUsersCommentsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnUsersCommnetsDto> IReturnUsersCommnetsService.ReturnAllAcceptedCommnetsForAdmin(RequestReturnUsersCommentsDto request)
        {
            int totalrow = 0;
            var Comments = _Context.UserComments.Where(p => p.Accepted == true && p.IsRemoved == false).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Filter))
                Comments = Comments.Where(p => p.UserEmail.Contains(request.Filter) || p.UserName.Contains(request.Filter)).AsQueryable();
            var Services = _Context.FeaturesDetails.IgnoreQueryFilters().ToList();

            var result = Comments.ToPaged(request.PageIndex, request.PageSize, out totalrow);

            if (result != null)
            {
                return new ResultMessage<ResultReturnUsersCommnetsDto>
                {
                    Success = true,
                    Enything = new ResultReturnUsersCommnetsDto
                    {
                        PageIndex = request.PageIndex,
                        Pagesize = request.PageSize,
                        TotalRow = totalrow,
                        Filter = request.Filter,
                        UserComments = result.Select(o => new UserComment
                        {
                            Id = o.Id,
                            UserName = o.UserName,
                            UserEmail = o.UserEmail,
                            Message = o.Message,
                            Service = o.Service,
                            Rate = o.Rate,
                            IsRemoved = o.IsRemoved,
                            ServiceName = AppliedMethodes.FindServiceName(Services, o.Service),
                        }).ToList()
                    }
                };
            }
            return new ResultMessage<ResultReturnUsersCommnetsDto>
            {
                Success = false,
                Enything = null,
                Message = "No Comment Found!"
            };

        }
        ResultMessage<ResultReturnUsersCommnetsDto> IReturnUsersCommnetsService.ReturnAllUnAcceptedCommnetsForAdmin(RequestReturnUsersCommentsDto request)
        {
            int totalrow = 0;
            var Comments = _Context.UserComments.Where(p => p.Accepted == false && p.IsRemoved == false).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Filter))
                Comments = Comments.Where(p => p.UserEmail.Contains(request.Filter) || p.UserName.Contains(request.Filter)).AsQueryable();
            var Services = _Context.FeaturesDetails.IgnoreQueryFilters().ToList();

            var result = Comments.ToPaged(request.PageIndex, request.PageSize, out totalrow);

            if (result != null)
            {
                return new ResultMessage<ResultReturnUsersCommnetsDto>
                {
                    Success = true,
                    Enything = new ResultReturnUsersCommnetsDto
                    {
                        PageIndex = request.PageIndex,
                        Pagesize = request.PageSize,
                        TotalRow = totalrow,
                        Filter = request.Filter,
                        UserComments = result.Select(o => new UserComment
                        {
                            Id = o.Id,
                            UserName = o.UserName,
                            UserEmail = o.UserEmail,
                            Message = o.Message,
                            Service = o.Service,
                            Rate = o.Rate,
                            IsRemoved = o.IsRemoved,
                            ServiceName =AppliedMethodes.FindServiceName(Services, o.Service),
                        }).ToList()
                    }
                };
            }
            return new ResultMessage<ResultReturnUsersCommnetsDto>
            {
                Success = false,
                Enything = null,
                Message = "No Comment Found!"
            };
        }
        ResultMessage<ResultReturnUsersCommnetsDto> IReturnUsersCommnetsService.ReturnAllDeletedCommnetsForAdmin(RequestReturnUsersCommentsDto request)
        {
            int totalrow = 0;
            var Comments = _Context.UserComments.Where(p => p.IsRemoved == true).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Filter))
                Comments = Comments.Where(p => p.UserEmail.Contains(request.Filter) || p.UserName.Contains(request.Filter)).AsQueryable();
            var Services = _Context.FeaturesDetails.IgnoreQueryFilters().ToList();

            var result = Comments.ToPaged(request.PageIndex, request.PageSize, out totalrow);

            if (result != null)
            {
                return new ResultMessage<ResultReturnUsersCommnetsDto>
                {
                    Success = true,
                    Enything = new ResultReturnUsersCommnetsDto
                    {
                        PageIndex = request.PageIndex,
                        Pagesize = request.PageSize,
                        TotalRow = totalrow,
                        Filter = request.Filter,
                        UserComments = result.Select(o => new UserComment
                        {
                            Id = o.Id,
                            UserName = o.UserName,
                            UserEmail = o.UserEmail,
                            Message = o.Message,
                            Service = o.Service,
                            Rate = o.Rate,
                            IsRemoved = o.IsRemoved,
                            ServiceName = AppliedMethodes.FindServiceName(Services, o.Service),
                        }).ToList()
                    }
                };
            }
            return new ResultMessage<ResultReturnUsersCommnetsDto>
            {
                Success = false,
                Enything = null,
                Message = "No Comment Found!"
            };
        }
        async Task<ResultMessage<List<UserComment>>> IReturnUsersCommnetsService.ReturnAllTopRatingCommnetsAsync(int ReturnCount, int? ServiceType)
        {
            var result = _Context.UserComments.Where(p => p.IsRemoved == false && p.Rate >= 3 && p.Accepted == true).Select(o => new UserComment
            {
                UserEmail = o.UserEmail,
                UserName = o.UserName,
                Message = o.Message,
                Service = o.Service,
                Rate = o.Rate
            }).ToList();

            if (ServiceType != null)
                result = result.Where(p => p.Service == ServiceType).ToList();

            if (result.Count > 0)
            {
                List<UserComment> Comments = new List<UserComment>();
                foreach (var item in result)
                {
                    Comments.Add(item);
                    if (Comments.Count >= ReturnCount)
                        break;
                }
                return new ResultMessage<List<UserComment>>
                {
                    Success = true,
                    Enything = Comments
                };
            }
            return new ResultMessage<List<UserComment>>
            {
                Success = false,
                Enything = null,
                Message = "No Comment Found!"
            };
        }
        ResultMessage<UserComment> IReturnUsersCommnetsService.ReturnCommentForAdmin(long Id)
        {
            var result = _Context.UserComments.IgnoreQueryFilters().Where(p => p.Id == Id).FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<UserComment>
                {
                    Success = true,
                    Enything = new UserComment
                    {
                        Message = result.Message,
                        UserName = result.UserName,
                        UserEmail = result.UserEmail,
                        Service = result.Service,
                        Rate = result.Rate
                    }
                };
            }


            return new ResultMessage<UserComment>
            {
                Success = false,
                Enything = null,
                Message = "Comment Not Found!"
            };
        }
        ResultMessage<ResultReturnUnAcceptedCommentsCountDto> IReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin()
        {
            var Count = _Context.UserComments.Where(p => p.Accepted == false && p.IsRemoved == false).Count();
            if (Count > 0)
            {
                return new ResultMessage<ResultReturnUnAcceptedCommentsCountDto>
                {
                    Success = true,
                    Enything = new ResultReturnUnAcceptedCommentsCountDto
                    {
                        count = Count
                    }
                };
            }
            return new ResultMessage<ResultReturnUnAcceptedCommentsCountDto>
            {
                Success = false,
                Enything = new ResultReturnUnAcceptedCommentsCountDto
                {
                    count = 0
                },
                Message = "No New Commnet Found"
            };
        }
    }
}
