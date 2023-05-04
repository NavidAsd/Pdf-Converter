using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Services.Command.Admin.UpdateAdmin
{
    public interface IUpdateAdminService
    {
        ResultMessage ChangeAdminState(UpdateAdminDto request);
        ResultMessage ChangeAdminRemovePermition(UpdateAdminDto request);
        ResultMessage ChangeAdminAddPermition(UpdateAdminDto request);
    }
    public class UpdateAdminDto
    {
        public long CurrentAdminId { set; get; }
        public long Id { set; get; }
        public bool State { set; get; }
    }
    public class UpdateAdminService : IUpdateAdminService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateAdminService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateAdminService.ChangeAdminState(UpdateAdminDto request)
        {
            var CurrentAdmin = _Context.Admins.Where(p => p.Id == request.CurrentAdminId && p.RemoveAdmin == true).FirstOrDefault();
            if (CurrentAdmin == null)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "You do not have the necessary access to perform the desired operation"
                };
            }
            var result = _Context.Admins.IgnoreQueryFilters().Where(p => p.Id == request.Id).FirstOrDefault();
            if (result != null && result.Id != CurrentAdmin.Id && result.Id != 1)
            {
                result.IsRemoved = request.State;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Admin State SuccessFully Changed"
                };
            }
            else if(result.Id == CurrentAdmin.Id)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "you cannot change your permissions"
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Admin Not Found"
            };
        }
        ResultMessage IUpdateAdminService.ChangeAdminAddPermition(UpdateAdminDto request)
        {
            var CurrentAdmin = _Context.Admins.Where(p => p.Id == request.CurrentAdminId && p.AddAdmin == true && p.RemoveAdmin == true).FirstOrDefault();
            if (CurrentAdmin == null)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "You do not have the necessary access to perform the desired operation"
                };
            }
            var result = _Context.Admins.IgnoreQueryFilters().Where(p => p.Id == request.Id).FirstOrDefault();
            if (result != null && result.Id != CurrentAdmin.Id && result.Id != 1)
            {
                result.AddAdmin = request.State;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Admin State SuccessFully Changed"
                };
            }
            else if (result.Id == CurrentAdmin.Id)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "you cannot change your permissions"
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Admin Not Found"
            };
        }
        ResultMessage IUpdateAdminService.ChangeAdminRemovePermition(UpdateAdminDto request)
        {
            var CurrentAdmin = _Context.Admins.Where(p => p.Id == request.CurrentAdminId && p.AddAdmin == true && p.RemoveAdmin == true).FirstOrDefault();
            if (CurrentAdmin == null)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "You do not have the necessary access to perform the desired operation"
                };
            }
            var result = _Context.Admins.IgnoreQueryFilters().Where(p => p.Id == request.Id).FirstOrDefault();
            if (result != null && result.Id != CurrentAdmin.Id && result.Id != 1)
            {
                result.RemoveAdmin = request.State;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Admin State SuccessFully Changed"
                };
            }
            else if (result.Id == CurrentAdmin.Id)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "you cannot change your permissions"
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Admin Not Found"
            };
        }
    }
}
