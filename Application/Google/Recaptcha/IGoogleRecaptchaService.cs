using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Common;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Application.Services.Google.Recaptcha
{
    public interface IGoogleRecaptchaService
    {
        Task<ResultMessage> Responsewithstring(string Response);
        Task<ResultMessage> Responsewithform(IFormCollection form);
        ResultSiteKey ReturnSiteKey();
    }
    public class ResultSiteKey
    {
        public string SiteKey { set; get; }
    }
    public class ResultGoogleRecaptchaDto
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public string ValidatedDateTime { get; set; }

        [JsonProperty("hostname")]
        public string HostName { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
    public class GoogleRecaptchaService : IGoogleRecaptchaService
    {
        private readonly IConfiguration _Configuration;
        public GoogleRecaptchaService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        async Task<ResultMessage> IGoogleRecaptchaService.Responsewithstring(string Response)
        {
            GetAppSettingData data = new GetAppSettingData(_Configuration);
            string urlToPost = "https://www.google.com/recaptcha/api/siteverify";
            string secretKey = data.GetCaptchaSecretKey();
            string gRecaptchaResponse = Response;

            var postData = "secret=" + secretKey + "&response=" + gRecaptchaResponse;

            // send post data
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToPost);
            request.Method = "POST";
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
               await streamWriter.WriteAsync(postData);
            }

            // receive the response now
            string result = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = await reader.ReadToEndAsync();
                }
            }

            // validate the response from Google reCaptcha
            var captChaesponse = JsonConvert.DeserializeObject<ResultGoogleRecaptchaDto>(result);
            if (!captChaesponse.Success)
            {
                return new ResultMessage()
                {
                    Success = false,
                    Message = "Sorry, Invalid reCAPTCHA Please Try Again",
                };
            }
            else
            {
                return new ResultMessage()
                {
                    Success = true,
                    Message = "Success",

                };
            }
        }
        async Task<ResultMessage> IGoogleRecaptchaService.Responsewithform(IFormCollection form)
        {
            GetAppSettingData data = new GetAppSettingData(_Configuration);
            string urlToPost = "https://www.google.com/recaptcha/api/siteverify";
            string secretKey = data.GetCaptchaSecretKey();
            string gRecaptchaResponse = form["g-recaptcha-response"];

            var postData = "secret=" + secretKey + "&response=" + gRecaptchaResponse;

            // send post data
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToPost);
            request.Method = "POST";
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                await streamWriter.WriteAsync(postData);
            }

            // receive the response now
            string result = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = await reader.ReadToEndAsync();
                }
            }

            // validate the response from Google reCaptcha
            var captChaesponse = JsonConvert.DeserializeObject<ResultGoogleRecaptchaDto>(result);
            if (!captChaesponse.Success)
            {
                return new ResultMessage()
                {
                    Success = false,
                    Message = "Sorry, please validate the reCAPTCHA",

                };
            }
            else
            {
                return new ResultMessage()
                {
                    Success = true,
                    Message = "Success",

                };
            }
        }
        ResultSiteKey IGoogleRecaptchaService.ReturnSiteKey()
        {
            GetAppSettingData data = new GetAppSettingData(_Configuration);
            return new ResultSiteKey { SiteKey = data.GetCaptchaSiteKey() };
        }
    }
}
