using System.Linq;
using Application.Interface;
using Common;

namespace Application.Services.Query.Admin.LoginAdmin
{
    public class LoginAdminService : ILoginAdminService
    {
        private readonly IPdfConverterContext _Context;
        public LoginAdminService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultLoginAdminDto> ILoginAdminService.Execute(RequestLoginAdminDto request)
        {
            var result = _Context.Admins.Where(U => U.Email.Equals(request.Email) && U.IsRemoved == false).FirstOrDefault();
            if (result == null)
            {
                return new ResultMessage<ResultLoginAdminDto>
                {
                    Enything = new ResultLoginAdminDto()
                    {
                        FullName = null,
                    },
                    Success = false,
                    Message = "The login email could not be found"

                };
            }
            var PasswordHasher = new PasswordHasher();
            bool VerifyPassword = PasswordHasher.VerifyPassword(result.Password, request.Password);
            if (VerifyPassword && result.IsRemoved == false)
            {
                return new ResultMessage<ResultLoginAdminDto>
                {
                    Enything = new ResultLoginAdminDto()
                    {
                        Email = request.Email,
                        FullName = result.FullName,
                        Id = result.Id,
                        AccountImage = result.AccountImage,
                    },
                    Success = true,
                    Message = "Welcome."
                };
            }
            else if (!VerifyPassword)
            {
                return new ResultMessage<ResultLoginAdminDto>
                {
                    Enything = new ResultLoginAdminDto()
                    {
                        FullName = null,
                    },
                    Success = false,
                    Message = "The password entered is incorrect"

                };
            }
            else
            {
                return new ResultMessage<ResultLoginAdminDto>
                {
                    Enything = new ResultLoginAdminDto()
                    {
                        FullName = null,
                    },
                    Success = false,
                    Message = "Your account has been deactivated Leave a message for support for more information."

                };
            }

        }
        ResultMessage<ResultLoginAdminDto> ILoginAdminService.LoginWithId(RequestLoginAdminWithIdDto request)
        {
            var result = _Context.Admins.Where(U => U.Id == request.Id && U.IsRemoved == false).FirstOrDefault();
            if (result == null)
            {
                return new ResultMessage<ResultLoginAdminDto>
                {
                    Enything = new ResultLoginAdminDto()
                    {
                        FullName = null,
                    },
                    Success = false,
                    Message = "The login email could not be found"

                };
            }
            var PasswordHasher = new PasswordHasher();
            bool VerifyPassword = PasswordHasher.VerifyPassword(result.Password, request.Password);
            if (VerifyPassword && result.IsRemoved == false)
            {
                return new ResultMessage<ResultLoginAdminDto>
                {
                    Enything = new ResultLoginAdminDto()
                    {
                        Email = result.Email,
                        FullName = result.FullName,
                        Id = result.Id,
                        AccountImage = result.AccountImage,
                    },
                    Success = true,
                    Message = "Welcome."
                };
            }
            else if (!VerifyPassword)
            {
                return new ResultMessage<ResultLoginAdminDto>
                {
                    Enything = new ResultLoginAdminDto()
                    {
                        FullName = null,
                    },
                    Success = false,
                    Message = "The password entered is incorrect"

                };
            }
            else
            {
                return new ResultMessage<ResultLoginAdminDto>
                {
                    Enything = new ResultLoginAdminDto()
                    {
                        FullName = null,
                    },
                    Success = false,
                    Message = "Your account has been deactivated Leave a message for support for more information."

                };
            }

        }
    }
}
