using Application.Interface.FacadPattern;
using Common;
using EndPoint.Areas.PdfManagerArea.Models;
using EndPoint.Areas.PdfManagerArea.Models.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Areas.PdfManagerArea.Controllers
{
    [Area("PdfManagerArea")]
    public class AccountController : Controller
    {
        private readonly string ControllerName = "Account";
        private readonly IAdminFacad _adminFacad;
        private readonly IFeaturesDetailsFacad _FeaturesDetails;
        private readonly IAncillaryServicesFacad _AncillaryFacad;
        public AccountController(IAdminFacad adminFacad, IFeaturesDetailsFacad featuresDetails, IAncillaryServicesFacad ancillaryFacad)
        {
            _adminFacad = adminFacad;
            _FeaturesDetails = featuresDetails;
            _AncillaryFacad = ancillaryFacad;
        }
        public async Task<IActionResult> Profile()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = _adminFacad.ReturnAdminDetailsService.Execute(long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
                if (user.Success)
                {
                    ViewBag.Data = LayoutData();
                    ViewBag.CommentCount = _FeaturesDetails.ReturnUsersCommnetsService.ReturnUnAcceptedCommentsCountForAdmin();
                    return View(user);
                }
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");
            }
            else
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Authentication/Login");

        }
        public async Task<IActionResult> Recovery()
        {
            return View();
        }
        public async Task<IActionResult> Code()
        {
            try
            {
                var user = await _adminFacad.UserPassRecoveryService.GetUserRecoveryAsync(long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
                if (user.Success)
                {
                    ViewBag.Time = user.Enything.ExpireTime;
                    if (user.Enything.Used == false && user.Enything.ExpireTime > System.DateTime.Now)
                        return View();
                }
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/{ControllerName}/Recovery");
            }
            catch
            {
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/{ControllerName}/Recovery");
            }
        }
        public async Task<IActionResult> ChangePass()
        {
            try
            {
                // can change password just 4 min after use code
                var user = await _adminFacad.UserPassRecoveryService.GetUserRecoveryAsync(long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
                if (user.Success)
                {
                    if (user.Enything.Used == true && System.DateTime.Now <= System.Convert.ToDateTime(user.Enything.ExpireTime).AddMinutes(4))
                        return View();
                }
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/{ControllerName}/Code");
            }
            catch { return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/{ControllerName}/Code"); }
        }


        [HttpPost]
        public async Task<IActionResult> EditUserDetails(RequestEditAdminDetailsViewModel request)
        {
            #region Validation
            try
            {
                EditAdminDetailsValidation validation = new EditAdminDetailsValidation();
                ValidationResult Result = validation.Validate(request);
                if (!Result.IsValid)
                {
                    foreach (ValidationFailure failure in Result.Errors)
                    {
                        return Json(new ResultMessage
                        {
                            Success = false,
                            Message = failure.ErrorMessage,
                        });
                    }
                }
            }
            catch
            {
                return Json(new ResultMessage
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again",
                });
            }
            #endregion
            try
            {
                var authentication = _adminFacad.LoginAdminService.LoginWithId(new Application.Services.Query.Admin.LoginAdmin.RequestLoginAdminWithIdDto
                {
                    Id = Convert.ToInt64(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Password = request.Password
                });

                if (authentication.Success)
                {
                    return Json(_adminFacad.editAdminDataService.Execute(new Application.Service.Command.Admin.EditAdmin.RequestEditAdminDataDto
                    {
                        Id = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                        FullName = request.FullName,
                        Email = request.Email
                    }));
                }
                return Json(authentication);
            }
            catch
            {
                return Json(new ResultMessage
                {
                    Success = false,
                    Message = "Something Wrong Please Login and try again"
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUserImage(IFormFile File)
        {
            long Id = 0;
            try
            {
                Id = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }
            catch
            { }
            if (Id > 0 && File != null && File.Length > 0)
            {
                if (_adminFacad.ReturnAdminDetailsService.Execute(Id).Success)
                {
                    string ImagePath = $"wwwroot\\{GetPath.GetAdminImagePath()}\\{Id}";
                    string filename = Formating.FixFileNameFormat(File.FileName);
                    if (!Directory.Exists(ImagePath))
                        Directory.CreateDirectory(ImagePath);
                    AppliedMethodes.DeleteAllFiles(ImagePath);
                    try
                    {
                        using (FileStream output = System.IO.File.Create(ImagePath + "\\" + filename))
                            await File.CopyToAsync(output);

                        var result = _adminFacad.editAdminDataService.EditImage(new Application.Service.Command.Admin.EditAdmin.RequestEditAdminImageDto
                        {
                            Id = Id,
                            ImageName = filename,
                            ImagePath = ImagePath
                        });
                        return Json(result);
                    }
                    catch
                    {
                        return Json(new ResultMessage
                        {
                            Success = false,
                            Message = "Something Wrong Please Try Again"
                        });
                    }
                }
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/Home/Logout");
            }
            return Json(new ResultMessage
            {
                Success = false,
                Message = "Something Wrong Please Try Again"
            });
        }

        [HttpPost]
        public async Task<IActionResult> CheckEmail(RecoveryUserPassViewModel request)
        {
            #region Validation
            try
            {
                RecoveryUserPassValidation validation = new RecoveryUserPassValidation();
                ValidationResult validationresult = validation.Validate(request);
                if (!validationresult.IsValid)
                {
                    foreach (ValidationFailure failure in validationresult.Errors)
                    {
                        return Json(new ResultMessage
                        {
                            Success = false,
                            Message = failure.ErrorMessage
                        });
                    }
                }
            }
            catch { return Json(new ResultMessage { Success = true, Message = "Something Went Worng Please Try Again" }); }
            #endregion
            var user = _adminFacad.ReturnAdminDetailsService.GetDetailsWithEmail(request.Email);
            if (user.Success)
            {
                //Prevent unsolicited code sending
                var lastUserCode = await _adminFacad.UserPassRecoveryService.GetUserRecoveryAsync(user.Enything.Id);
                if (lastUserCode.Success)
                    if (lastUserCode.Enything.Used == false && lastUserCode.Enything.ExpireTime > System.DateTime.Now)
                    {
                        return Json(new ResultMessage
                        {
                            Success = false,
                            Message = $"{lastUserCode.Enything.ExpireTime - System.DateTime.Now} minutes until the expiration of the previous code left for your submission"
                        });
                    }

                // \\
                SetClaimes(user.Enything.Id, request.Email);
                var result =await _AncillaryFacad.EmailSenderService.CodeSenderAsync(new Application.Service.SendEmailCode.EmailSenderDetails
                {
                    EmailSender = GetPath.GetCompanyEmail(),
                    EmailPass = GetPath.GetCompanyEmailPass(),
                    RecipientEmail = request.Email,
                    Subject = "PdfConverter [Admin-Reset-Your-Password]",
                    TextBody = "<h1>You can use this code to reset your password</h1>"
                      + "<br/>"
  + "This code is disposable and you have 4 minutes to use this code after sending it"
  + "Will not have a credit code after the timeout."
  + "<br/>"
  + $"<a href={GetPath.GetDomainHttps() + "/PdfManagerArea/Account/Code"}>Reset Page</a>"
  + "<br/>"
  + "Code: "
                });
                if (result.Success)
                {
                    // Add Recovery Data
                    await _adminFacad.UserPassRecoveryService.AddNewCodeAsync(new Application.Services.Command.Admin.UserRecoveryPass.RequestAddNewRecoveryCodeDto
                    {
                        Id = user.Enything.Id,
                        Code = result.Enything.Code,
                        ExpireTime = System.DateTime.Now.AddMinutes(4),
                    });
                    return Json(new ResultMessage
                    {
                        Success = true
                    });
                }
                return Json(result);
            }
            return Json(user);

        }

        [HttpPost]
        public async Task<IActionResult> VerifyCode(UserPassRecoveryCodeViewModel request)
        {
            #region Validation
            try
            {
                UserPassRecoveryCodeValidation validation = new UserPassRecoveryCodeValidation();
                ValidationResult validationresult = validation.Validate(request);
                if (!validationresult.IsValid)
                {
                    foreach (ValidationFailure failure in validationresult.Errors)
                    {
                        return Json(new ResultMessage
                        {
                            Success = false,
                            Message = failure.ErrorMessage
                        });

                    }
                }
            }
            catch
            {
                return Json(new ResultMessage
                {
                    Success = false,
                    Message = "Something Went Worng Please Try Again"
                });
            }
            #endregion
            try
            {
                var user =await _adminFacad.UserPassRecoveryService.GetUserRecoveryAsync(long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
                if (user.Success)
                    if (user.Enything.Used == false && user.Enything.ExpireTime > System.DateTime.Now)
                    {
                        var result =await _adminFacad.UserPassRecoveryService.CheckCodeAsync(new Application.Services.Command.Admin.UserRecoveryPass.RequestAddNewRecoveryCodeDto
                        {
                            Code = request.Code,
                            Id = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value)
                        });
                        if (result.Success)
                        {
                            await _adminFacad.UserPassRecoveryService.AcceptCodeAsync(long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
                        }
                        return Json(result);
                    }
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/{ControllerName}/Recovery");
            }
            catch
            {
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/{ControllerName}/Recovery");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RecoveryPass(UserChangePassViewModel request)
        {
            #region Validation 
            try
            {
                UserChangePassValidation validation = new UserChangePassValidation();
                ValidationResult validationresult = validation.Validate(request);
                if (!validationresult.IsValid)
                {
                    foreach (ValidationFailure failure in validationresult.Errors)
                    {
                        return Json(new ResultMessage
                        {
                            Success = false,
                            Message = failure.ErrorMessage
                        });

                    }
                }
            }
            catch
            { return Json(new ResultMessage { Success = false, Message = "Something Went Worng Please Try Again" }); }
            #endregion
            var user = await _adminFacad.UserPassRecoveryService.GetUserRecoveryAsync(long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
            if (user.Success)
                if (user.Enything.Used == true && System.DateTime.Now <= System.Convert.ToDateTime(user.Enything.ExpireTime).AddMinutes(4))
                {
                    var result = _adminFacad.changeAdminPassService.ForgotChangePass(new Application.Service.Command.Admin.ChangeAdminPass.RequestForgotChangeAdminPassDto
                    {
                        Id = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                        NewPass = request.NewPass,
                        RepNewPass = request.RepPass,
                    });
                    if (result.Success)
                    {
                        HttpContext.SignOutAsync();
                    }
                    return Json(result);
                }
                else
                {
                    return Json(new ResultMessage
                    {
                        Success = false,
                        Message = "Your time to change the password is over"
                    });
                }
            return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/{ControllerName}/Recovery");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeYourPass(UserChangeOldPassViewModel request)
        {
            #region Validation 
            try
            {
                UserChangeOldPassValidation validation = new UserChangeOldPassValidation();
                ValidationResult validationresult = validation.Validate(request);
                if (!validationresult.IsValid)
                {
                    foreach (ValidationFailure failure in validationresult.Errors)
                    {
                        return Json(new ResultMessage
                        {
                            Success = false,
                            Message = failure.ErrorMessage
                        });

                    }
                }
                if (request.NewPassword != request.RepPassword)
                {
                    return Json(new ResultMessage
                    {
                        Success = false,
                        Message = "The password is inconsistent with its repetition"
                    });
                }
            }
            catch
            { return Json(new ResultMessage { Success = false, Message = "Something Went Worng Please Try Again" }); }
            #endregion
            return Json(_adminFacad.changeAdminPassService.ChangePassword(new Application.Service.Command.Admin.ChangeAdminPass.RequestChangeAdminPassword
            {
                Id = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                old_Pass = request.OldPassword,
                New_Pass = request.NewPassword,
                Rep_Pass = request.RepPassword,
                UseOld_pass = true
            }));
        }

        private Models.Admin LayoutData()
        {
            Models.Admin data = new Models.Admin()
            {
                Email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value,
                FullName = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Name).Value,
                Id = Convert.ToInt64(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                AccountImage = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.StreetAddress).Value,
                ImagePath = GetPath.GetAdminImagePath(),

            };
            return data;
        }
        private void SetClaimes(long Id, string Email)
        {
            var Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,Id.ToString()),
                    new Claim(ClaimTypes.Email,Email),
                };
            var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true,
            };
            HttpContext.SignInAsync(principal, properties);
        }
    }
}
