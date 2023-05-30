using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Common;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Application.Interface.FacadPattern;
using EndPoint.Areas.PdfManagerArea.Models;
using EndPoint.Areas.PdfManagerArea.Models.Validation;
using Application.Services.Query.Admin.LoginAdmin;
using System.Linq;
using Application.Service.SendEmailCode;
using System.Threading.Tasks;

namespace EndPoint.Areas.PdfManagerArea.Controllers
{
    [Area("PdfManagerArea")]
    public class AuthenticationController : Controller
    {
        private readonly string ControllerName = "Authentication";
        private readonly IAdminFacad _adminFacad;
        private readonly IAncillaryServicesFacad _ancillaryFacad;
        public AuthenticationController(IAdminFacad adminFacad, IAncillaryServicesFacad ancillaryFacad)
        {
            _adminFacad = adminFacad;
            _ancillaryFacad = ancillaryFacad;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> Code()
        {
            try
            {
                //var ghgh = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
                var user = await _adminFacad.UserPassRecoveryService.GetUserRecoveryAsync(long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
                if (user.Success)
                {
                    ViewBag.Time = user.Enything.ExpireTime;
                    if (user.Enything.Used == false && user.Enything.ExpireTime > System.DateTime.Now)
                        return View();
                }
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/{ControllerName}/Login");
            }
            catch
            {
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/{ControllerName}/Login");
            }
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginAdminViewModel request)
        {
            #region Validation
            try
            {
                LoginAdminValidation validation = new LoginAdminValidation();
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
            var user = _adminFacad.LoginAdminService.Execute(new RequestLoginAdminDto
            {
                Email = request.Email,
                Password = request.Password
            });

            if (user.Success)
            {
                var lastUserCode = await _adminFacad.UserPassRecoveryService.GetUserRecoveryAsync(user.Enything.Id);
                if (lastUserCode.Success)
                    if (lastUserCode.Enything.Used == false && lastUserCode.Enything.ExpireTime > System.DateTime.Now)
                    {
                        return Json(new ResultMessage { Success = false, Message = $"{lastUserCode.Enything.ExpireTime - System.DateTime.Now} minutes until the expiration of the previous code left for your submission" });
                    }
                // \\
                SetClaimes(user.Enything.Id, request.Email);
                var result = await _ancillaryFacad.EmailSenderService.CodeSenderAsync(new EmailSenderDetails
                {
                    EmailSender = GetPath.GetCompanyEmail(),
                    EmailPass = GetPath.GetCompanyEmailPass(),
                    RecipientEmail = request.Email,
                    Subject = "PdfConverter [Admin-2-Step-Verification]",
                    TextBody = "<h1>You can use this code to Login</h1>"
                      + "<br/>"
  + "This code is disposable and you have 6 minutes to use this code after sending it"
  + "Will not have a credit code after the timeout."
  + "<br/>"
  + $"<a href={GetPath.GetDomainHttps() + "/PdfManagerArea/Authentication/Code"}>Login Page</a>"
  + "<br/>"
  + "Code: "
                });
                if (result.Success)
                {
                    // Add Data
                    await _adminFacad.UserPassRecoveryService.AddNewCodeAsync(new Application.Services.Command.Admin.UserRecoveryPass.RequestAddNewRecoveryCodeDto
                    {
                        Id = user.Enything.Id,
                        Code = result.Enything.Code,
                        ExpireTime = System.DateTime.Now.AddMinutes(6),
                    });
                    return Json(result);
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
                ViewBag.Error = new ResultMessage
                {
                    Success = false,
                    Message = "Something Went Worng Please Try Again"
                };
                return Redirect($"{GetPath.GetDomainHttps()}/PdfManagerArea/{ControllerName}/Code");
            }
            #endregion
            try
            {
                var user = await _adminFacad.UserPassRecoveryService.GetUserRecoveryAsync(long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
                if (user.Success)
                    if (user.Enything.Used == false && user.Enything.ExpireTime > System.DateTime.Now)
                    {
                        var result = await _adminFacad.UserPassRecoveryService.CheckCodeAsync(new Application.Services.Command.Admin.UserRecoveryPass.RequestAddNewRecoveryCodeDto
                        {
                            Code = request.Code,
                            Id = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value)
                        });
                        if (result.Success)
                        {
                            await _adminFacad.UserPassRecoveryService.AcceptCodeAsync(long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
                            var Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,result.Enything.Id.ToString()),
                new Claim(ClaimTypes.Email, result.Enything.Email),
                new Claim(ClaimTypes.Name, result.Enything.FullName),
                new Claim(ClaimTypes.StreetAddress, result.Enything.Imagee), //Account Image
                };
                            var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);
                            var properties = new AuthenticationProperties()
                            {
                                IsPersistent = true,
                                ExpiresUtc = (DateTime.Now.AddHours(6)),
                            };
                            HttpContext.SignInAsync(principal, properties);
                            return Json(result);
                        }
                        return Json(result);
                    }
                return Json(new ResultMessage { Success = false, Message = "The code sent to you has expired. Please use the button below to resend" });
            }
            catch
            {
                return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ResendCode()
        {
            try
            {
                var lastUserCode =await _adminFacad.UserPassRecoveryService.GetUserRecoveryAsync(long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
                if (lastUserCode.Success)
                    if (lastUserCode.Enything.Used == true && lastUserCode.Enything.ExpireTime > System.DateTime.Now)
                    {
                        return Json(new ResultMessage { Success = false, Message = $"{lastUserCode.Enything.ExpireTime - System.DateTime.Now} minutes until the expiration of the previous code left for your submission" });
                    }
                var result = await _ancillaryFacad.EmailSenderService.CodeSenderAsync(new EmailSenderDetails
                {
                    EmailSender = GetPath.GetCompanyEmail(),
                    EmailPass = GetPath.GetCompanyEmailPass(),
                    RecipientEmail = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value,
                    Subject = "PdfConverter [Admin-2-Step-Verification]",
                    TextBody = "<h1>You can use this code to Login</h1>"
                      + "<br/>"
  + "This code is disposable and you have 6 minutes to use this code after sending it"
  + "Will not have a credit code after the timeout."
  + "<br/>"
  + $"<a href={GetPath.GetDomainHttps() + "/PdfManagerArea/Authentication/Code"}>Login Page</a>"
  + "<br/>"
  + "Code: "
                });
                if (result.Success)
                {
                    // Add Recovery Data
                    await _adminFacad.UserPassRecoveryService.AddNewCodeAsync(new Application.Services.Command.Admin.UserRecoveryPass.RequestAddNewRecoveryCodeDto
                    {
                        Id = long.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                        Code = result.Enything.Code,
                        ExpireTime = System.DateTime.Now.AddMinutes(6),
                    });
                    return Json(new ResultMessage { Success = true });
                }
                ViewBag.Error = result;
                return Json(new ResultMessage { Success = false, Message = result.Message });

            }
            catch { return Json(new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" }); }
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
            Console.WriteLine();
        }
    }
}
