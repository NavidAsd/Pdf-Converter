using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Query.Admin.ReturnAdminDetails
{
    public interface IReturnAdminDetailsService
    {
        ResultMessage<ResultReturnAdminDetailsDto> Execute(long Id);
        ResultMessage<ResultReturnAdminDetailsDto> GetDetailsWithEmail(string Email);
        ResultMessage<ResultReturnAllAdminDetailsDto> ReturnAll(RequestReturnAllAdminDetailsDto request);
        ResultMessage<ResultReturnAllAdminDetailsDto> ReturnAllRemoved(RequestReturnAllAdminDetailsDto request);
    }
    public class ResultReturnAdminDetailsDto
    {
        public long Id { set; get; }
        public string FullName { set; get; }
        public string AccountImage { set; get; }
        public string Email { set; get; }
        public bool AddAdmin { set; get; }
        public bool RemoveAdmin { set; get; }
    }
    public class ResultReturnAllAdminDetailsDto
    {
        public int TotalRow { set; get; }
        public int PageIndex { set; get; }
        public int Pagesize { set; get; }
        public string Filter { set; get; }
        public List<ResultReturnAdminDetailsDto> Details { set; get; }
    }
    public class RequestReturnAllAdminDetailsDto
    {
        public string Filter { set; get; }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
        public long CurrentAdminId { set; get; }
    }

    public class ReturnAdminDetailsService : IReturnAdminDetailsService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnAdminDetailsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnAdminDetailsDto> IReturnAdminDetailsService.Execute(long Id)
        {
            var result = _Context.Admins.Find(Id);
            if (result != null)
            {
                return new ResultMessage<ResultReturnAdminDetailsDto>
                {
                    Success = true,
                    Enything = new ResultReturnAdminDetailsDto
                    {
                        Id = result.Id,
                        FullName = result.FullName,
                        Email = result.Email,
                        AccountImage = result.AccountImage,
                        AddAdmin = result.AddAdmin,
                        RemoveAdmin=result.RemoveAdmin,
                    }
                };
            }
            return new ResultMessage<ResultReturnAdminDetailsDto>
            {
                Success = false,
                Message = "Account Not Found!"
            };
        }
        ResultMessage<ResultReturnAdminDetailsDto> IReturnAdminDetailsService.GetDetailsWithEmail(string Email)
        {
            var result = _Context.Admins.Where(p => p.Email == Email && p.IsRemoved == false).FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResultReturnAdminDetailsDto>
                {
                    Success = true,
                    Enything = new ResultReturnAdminDetailsDto
                    {
                        Id = result.Id,
                        FullName = result.FullName,
                        Email = result.Email,
                        AccountImage = result.AccountImage,
                        AddAdmin = result.AddAdmin,
                        RemoveAdmin=result.RemoveAdmin,
                    }
                };
            }
            return new ResultMessage<ResultReturnAdminDetailsDto>
            {
                Success = false,
                Message = "Account Not Found!"
            };
        }
        ResultMessage<ResultReturnAllAdminDetailsDto> IReturnAdminDetailsService.ReturnAll(RequestReturnAllAdminDetailsDto request)
        {
            var curretnAdmin = _Context.Admins.Where(p => p.Id == request.CurrentAdminId && p.RemoveAdmin == true).FirstOrDefault();
            if (curretnAdmin == null)
            {
                return new ResultMessage<ResultReturnAllAdminDetailsDto>
                {
                    Success = false,
                    Message = "You do not have the necessary access to perform the desired operation"
                };
            }
            int totalrow = 0;
            var adminlist = _Context.Admins.Where(p => p.IsRemoved == false).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Filter))
                adminlist = adminlist.Where(p => p.Email.Contains(request.Filter) || p.FullName.Contains(request.Filter)).AsQueryable();

            var result = adminlist.ToPaged(request.PageIndex, request.PageSize, out totalrow);

            if (result != null)
            {
                return new ResultMessage<ResultReturnAllAdminDetailsDto>
                {
                    Success = true,
                    Enything = new ResultReturnAllAdminDetailsDto
                    {

                        Filter = request.Filter,
                        PageIndex = request.PageIndex,
                        Pagesize = request.PageSize,
                        TotalRow = totalrow,
                        Details = result.Select(o => new ResultReturnAdminDetailsDto
                        {
                            AccountImage = o.AccountImage,
                            RemoveAdmin = o.RemoveAdmin,
                            FullName = o.FullName,
                            AddAdmin = o.AddAdmin,
                            Email = o.Email,
                            Id = o.Id,
                        }).ToList()
                    }
                };
            }
            return new ResultMessage<ResultReturnAllAdminDetailsDto>
            {
                Success = false,
                Message = "No Admin Founds"
            };
        }
        ResultMessage<ResultReturnAllAdminDetailsDto> IReturnAdminDetailsService.ReturnAllRemoved(RequestReturnAllAdminDetailsDto request)
        {
            var curretnAdmin = _Context.Admins.Where(p => p.Id == request.CurrentAdminId && p.RemoveAdmin == true).FirstOrDefault();
            if (curretnAdmin == null)
            {
                return new ResultMessage<ResultReturnAllAdminDetailsDto>
                {
                    Success = false,
                    Message = "You do not have the necessary access to perform the desired operation"
                };
            }
            int totalrow = 0;
            var adminlist = _Context.Admins.IgnoreQueryFilters().Where(p => p.IsRemoved == true).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Filter))
                adminlist = adminlist.Where(p => p.Email.Contains(request.Filter) || p.FullName.Contains(request.Filter)).AsQueryable();

            var result = adminlist.ToPaged(request.PageIndex, request.PageSize, out totalrow);

            if (result != null)
            {
                return new ResultMessage<ResultReturnAllAdminDetailsDto>
                {
                    Success = true,
                    Enything = new ResultReturnAllAdminDetailsDto
                    {

                        Filter = request.Filter,
                        PageIndex = request.PageIndex,
                        Pagesize = request.PageSize,
                        TotalRow = totalrow,
                        Details = result.Select(o => new ResultReturnAdminDetailsDto
                        {
                            AccountImage = o.AccountImage,
                            RemoveAdmin=o.RemoveAdmin,
                            FullName = o.FullName,
                            AddAdmin = o.AddAdmin,
                            Email = o.Email,
                            Id = o.Id,
                        }).ToList()
                    }
                };
            }
            return new ResultMessage<ResultReturnAllAdminDetailsDto>
            {
                Success = false,
                Message = "No Admin Founds"
            };
        }
    }
}
