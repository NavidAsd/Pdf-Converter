using Application.Interface;
using Common;
using System;
using System.Linq;

namespace Application.Service.Command.Admin.ChangeAdminPass
{
    public interface IChangeAdminPasswordService
    {
        ResultMessage ChangePassword(RequestChangeAdminPassword request);
        ResultMessage ForgotChangePass(RequestForgotChangeAdminPassDto request);
        ResultMessage<UserResult> RecoveryPassword(RequestRecoveryAdminPassword request);
        ResultMessage SaveCode(RequestRecoveryAdminPassword request);
        ResultMessage<UserResult> CheckExpireCode(long Id);
        ResultMessage<UserResult> CheckEmailExist(string Eamil);
    }
    public class ChangeAdminPasswordService : IChangeAdminPasswordService
    {
        private readonly IPdfConverterContext _Context;
        public ChangeAdminPasswordService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IChangeAdminPasswordService.ChangePassword(RequestChangeAdminPassword request)
        {
            PasswordHasher hasher = new PasswordHasher();
            var result = _Context.Admins.Find(request.Id);
            if (result != null)
            {
                if (request.New_Pass == request.Rep_Pass)
                {
                    if (request.UseOld_pass)
                    {
                        if (hasher.VerifyPassword(result.Password, request.old_Pass))
                        {
                            result.Password = hasher.HashPassword(request.New_Pass);
                            _Context.SaveChanges();
                            return new ResultMessage
                            {
                                Success = true,
                                Message = "Your password was changed successfully"
                            };
                        }
                        else
                        {
                            return new ResultMessage
                            {
                                Success = false,
                                Message = "Your Password Incorrect"
                            };
                        }
                    }
                    else
                    {
                        result.Password = hasher.HashPassword(request.New_Pass);
                        _Context.SaveChanges();
                        return new ResultMessage
                        {
                            Success = true,
                            Message = "Your password was changed successfully"
                        };
                    }
                }
                else
                {
                    return new ResultMessage
                    {
                        Success = false,
                        Message = "Repeating the password is different from the password"
                    };
                }
            }
            else
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "User Not Found"
                };
            }
        }
        ResultMessage IChangeAdminPasswordService.ForgotChangePass(RequestForgotChangeAdminPassDto request)
        {
            if (request.NewPass != request.RepNewPass)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "The password entered is inconsistent with its repetition"
                };
            }

            var result = _Context.Admins.Find(request.Id);
            if (result != null)
            {
                PasswordHasher hasher = new PasswordHasher();
                result.Password = hasher.HashPassword(request.NewPass);
                result.LastUpdate = System.DateTime.Today;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Password SuccessFully Changed"
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Account Not Found"
            };
        }

        ResultMessage IChangeAdminPasswordService.SaveCode(RequestRecoveryAdminPassword request)
        {
            var result = _Context.Admins.Find(request.Id);
            if (result != null)
            {
                result.Code = request.Code;
                result.CodeExpiration = DateTime.Now.AddMinutes(4);
                result.Used = false;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = $"We Send You Some Code to '{ result.Email }' For Autenthication please give us a code",
                };

            }
            else
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "User Not Found!"
                };
            }
        }
        ResultMessage<UserResult> IChangeAdminPasswordService.CheckExpireCode(long Id)
        {
            var result = _Context.Admins.Find(Id);
            if (result != null)
            {
                if (!result.Used && result.CodeExpiration >= DateTime.Now)
                {
                    return new ResultMessage<UserResult>
                    {
                        Success = false,
                        Message = $"After another {result.CodeExpiration - DateTime.Now} minutes, you can request to send the code",
                        Enything = new UserResult
                        {
                            Email = result.Email,
                            Id = result.Id
                        }
                    };
                }
                else
                {
                    return new ResultMessage<UserResult>
                    {
                        Success = true,
                        Message = $"We Send You Some Code to '{ result.Email }' For Autenthication please give us a code",
                        Enything = new UserResult
                        {
                            Email = result.Email,
                            Id = result.Id
                        }
                    };
                }
            }
            else
            {
                return new ResultMessage<UserResult>
                {
                    Success = false,
                    Message = "User Not Found",
                    Enything = null,

                };
            }
        }

        ResultMessage<UserResult> IChangeAdminPasswordService.RecoveryPassword(RequestRecoveryAdminPassword request)
        {
            var result = _Context.Admins.Find(request.Id);
            if (result != null)
            {
                if (!result.Used && result.CodeExpiration >= DateTime.Now)
                {
                    if (result.Code == request.Code)
                    {
                        result.Used = true;
                        _Context.SaveChanges();
                        return new ResultMessage<UserResult>
                        {
                            Success = true,
                            Enything = new UserResult
                            {
                                Email = result.Email,
                                Id = result.Id
                            }
                        };
                    }
                    else
                    {
                        return new ResultMessage<UserResult>
                        {
                            Success = false,
                            Message = "The code entered is incorrect"
                        };
                    }
                }
                else
                {
                    return new ResultMessage<UserResult>
                    {
                        Success = false,
                        Message = "The entered code has expired"
                    };
                }
            }
            else
            {
                return new ResultMessage<UserResult>
                {
                    Success = false,
                    Message = "Email entered in the system is not registered"
                };
            }
        }

        ResultMessage<UserResult> IChangeAdminPasswordService.CheckEmailExist(string Eamil)
        {
            var result = _Context.Admins.Where(p => p.Email == Eamil).FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<UserResult>
                {
                    Success = true,
                    Enything = new UserResult
                    {
                        Id = result.Id,
                        FullName = result.FullName,
                        Email = result.Email,
                        Used = result.Used
                    }
                };
            }
            else
            {
                return new ResultMessage<UserResult>
                {
                    Success = false,
                    Message = "Email entered in the system is not registered"
                };
            }
        }
    }

    public class RequestRecoveryAdminPassword
    {
        public long Id { set; get; }
        public long Code { set; get; }
        public RequestChangeAdminPassword changepass { set; get; }
    }
    public class RequestChangeAdminPassword
    {
        public long Id { set; get; }
        public bool UseOld_pass { set; get; }
        public string old_Pass { set; get; }
        public string New_Pass { set; get; }
        public string Rep_Pass { set; get; }
    }
    public class UserResult
    {
        public long Id { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public bool Used { set; get; }
    }
    public class RequestForgotChangeAdminPassDto
    {
        public long Id { set; get; }
        public string NewPass { set; get; }
        public string RepNewPass { set; get; }
    }
}
