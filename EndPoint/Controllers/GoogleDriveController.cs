using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EndPoint.Controllers
{

    //pdftocoverter@gmail.com aouth client id
    // 661167988884-k6caai5feqcqone9h5637t8h0oih9jq7.apps.googleusercontent.com
    //client secret 
    // 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

    public class GoogleDriveController : Controller
    {
        [HttpGet]
        public IActionResult auth()
        {
            var properties = new AuthenticationProperties { };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme); 
        }
        public async Task<IActionResult> GoogleResponse()
        {
            /*string[] Scopes = new string[] { "https://www.googleapis.com/auth/drive",
                                 "https://www.googleapis.com/auth/drive.readonly"};
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Type,
                claim.Value,
            });
            var claiims = result.Principal.Identities
            .FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            var Email = claims.Where(p => p.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault().Value;

            return null;*/

            //Scopes for use with the Google Drive API
            string[] scopes = new string[] { DriveService.Scope.Drive,
                                 DriveService.Scope.DriveFile};
            var clientId = "942725702587-a7qjeq8jo66fvhmlh4aa2u8s49o50bn0.apps.googleusercontent.com";      // From https://console.developers.google.com
            var clientSecret = "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";          // From https://console.developers.google.com
                                                                               // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            },
                                                                        scopes,
                                                                        Environment.UserName,
                                                                        CancellationToken.None,
                                                                        new FileDataStore("Daimto.GoogleDrive.Auth.Store")).Result;
            return Challenge(GoogleDefaults.AuthenticationScheme);

        }

        // 70 MB in bytes
        /* [RequestSizeLimit(73400320)]
         [RequestFormLimits(MultipartBodyLengthLimit = 73400320)]
         public IActionResult SelectFile(string Id)
         {
             var userip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
             string OutPath = $"{Common.GetPath.GetInputPath()}\\{userip}";
             var Result = GoogleDriveRepsitory.testt(Id,OutPath);
             if (Result.Success)
                 RedirectToAction("ConverterController", "PdfToPptFromDisk", new { });
             return Json(Result);

             /*Response.ContentType = "application/zip";
             Response.AddHeader("Content-Disposition", "attachment; filename=" + Result.Enything.OutFileName);
             Response.WriteFile(HttpContext.Current.Server.MapPath("~/GoogleDriveFiles/" + Result.Enything.OutFilePath));
             Response.End();
             Response.Flush();
         }*/
    }
}
