using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Services.Command.Admin.UserRecoveryPass
{
    public interface IUserPassRecoveryService
    {
        ResultMessage AddNewCode(RequestAddNewRecoveryCodeDto request);
        ResultMessage AcceptCode(long Id);
        ResultMessage<ResultGetUserRecoveryDto> GetUserRecovery(long Id);
        ResultMessage<ResultCheckCodeDto> CheckCode(RequestAddNewRecoveryCodeDto request);
    }
    public class ResultGetUserRecoveryDto
    {
        public long? Code { set; get; }
        public bool Used { set; get; }
        public System.DateTime? ExpireTime { set; get; }
    }
    public class RequestAddNewRecoveryCodeDto
    {
        public long Id { set; get; }
        public long Code { set; get; }
        public System.DateTime ExpireTime { set; get; }
    }
    public class ResultCheckCodeDto
    {
        public long Id { set; get; }
        public string Email { set; get; }
        public string FullName { set; get; }
        public string Imagee { set; get; }
    }
    public class UserPassRecoveryService : IUserPassRecoveryService
    {
        private readonly IPdfConverterContext _Context;
        public UserPassRecoveryService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUserPassRecoveryService.AddNewCode(RequestAddNewRecoveryCodeDto request)
        {
            var result = _Context.Admins.IgnoreQueryFilters().Where(p => p.Id == request.Id && p.IsRemoved == false).FirstOrDefault();
            if (result != null)
            {
                result.Code = request.Code;
                result.CodeExpiration = request.ExpireTime;
                result.Used = false;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "User Not Found"
            };
        }
        ResultMessage<ResultGetUserRecoveryDto> IUserPassRecoveryService.GetUserRecovery(long Id)
        {
            var result = _Context.Admins.IgnoreQueryFilters().Where(p => p.IsRemoved == false && p.Id == Id).FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResultGetUserRecoveryDto>
                {
                    Success = true,
                    Enything = new ResultGetUserRecoveryDto
                    {
                        Code = result.Code,
                        Used = result.Used,
                        ExpireTime = result.CodeExpiration,
                    }
                };
            }
            return new ResultMessage<ResultGetUserRecoveryDto>
            {
                Success = false,
                Message = "User Not Found"
            };
        }
        ResultMessage<ResultCheckCodeDto> IUserPassRecoveryService.CheckCode(RequestAddNewRecoveryCodeDto request)
        {
            var result = _Context.Admins.IgnoreQueryFilters().Where(p => p.Id == request.Id && p.IsRemoved == false).FirstOrDefault();
            if (result != null)
            {
                if (!result.Used)
                {
                    if (result.Code == request.Code)
                    {
                        if (result.CodeExpiration >= System.DateTime.Now)
                        {

                            return new ResultMessage<ResultCheckCodeDto>
                            {
                                Success = true,
                                Enything = new ResultCheckCodeDto
                                {
                                    Id = result.Id,
                                    Email = result.Email,
                                    FullName = result.FullName,
                                    Imagee = result.AccountImage
                                }
                            };
                        }
                        return new ResultMessage<ResultCheckCodeDto>
                        {
                            Success = false,
                            Message = "Code expired"
                        };
                    }
                    return new ResultMessage<ResultCheckCodeDto>
                    {
                        Success = false,
                        Message = "The code entered is incorrect"
                    };
                }
                return new ResultMessage<ResultCheckCodeDto>
                {
                    Success = false,
                    Message = "You do not have an active submission code"
                };
            }
            return new ResultMessage<ResultCheckCodeDto>
            {
                Success = false,
                Message = "User Not Found"
            };
        }
        ResultMessage IUserPassRecoveryService.AcceptCode(long Id)
        {
            var result = _Context.Admins.IgnoreQueryFilters().Where(p => p.IsRemoved == false && p.Id == Id).FirstOrDefault();
            if (result != null)
            {
                result.Used = true;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "User Not Found"
            };
        }
    }
}
