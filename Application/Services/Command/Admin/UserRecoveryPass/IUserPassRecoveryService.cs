using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Command.Admin.UserRecoveryPass
{
    public interface IUserPassRecoveryService
    {
        Task<ResultMessage> AddNewCodeAsync(RequestAddNewRecoveryCodeDto request);
        Task<ResultMessage> AcceptCodeAsync(long Id);
        Task<ResultMessage<ResultGetUserRecoveryDto>> GetUserRecoveryAsync(long Id);
        Task<ResultMessage<ResultCheckCodeDto>> CheckCodeAsync(RequestAddNewRecoveryCodeDto request);
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
        async Task<ResultMessage> IUserPassRecoveryService.AddNewCodeAsync(RequestAddNewRecoveryCodeDto request)
        {
            var result = _Context.Admins.IgnoreQueryFilters().Where(p => p.Id == request.Id && p.IsRemoved == false).FirstOrDefault();
            if (result != null)
            {
                result.Code = request.Code;
                result.CodeExpiration = request.ExpireTime;
                result.Used = false;
                await _Context.SaveChangesAsync();
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
        async Task<ResultMessage<ResultGetUserRecoveryDto>> IUserPassRecoveryService.GetUserRecoveryAsync(long Id)
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
        async Task<ResultMessage<ResultCheckCodeDto>> IUserPassRecoveryService.CheckCodeAsync(RequestAddNewRecoveryCodeDto request)
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
        async Task<ResultMessage> IUserPassRecoveryService.AcceptCodeAsync(long Id)
        {
            var result = _Context.Admins.IgnoreQueryFilters().Where(p => p.IsRemoved == false && p.Id == Id).FirstOrDefault();
            if (result != null)
            {
                result.Used = true;
                await _Context.SaveChangesAsync();
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
