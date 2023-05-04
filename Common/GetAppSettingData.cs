using Microsoft.Extensions.Configuration;

namespace Common
{
    public class GetAppSettingData
    {
        private readonly IConfiguration Configuration;
        public GetAppSettingData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private string Default(string Json)
        {
            var result = Configuration.GetSection(Json);
            return result.Value.ToString();
        }
        public string GetConnection()
        {
            return Default("ConnectionString:Connection");
        }
        public string GetDbName()
        {
            return Default("ConnectionString:DataBaseName");
        }
        public string GetCaptchaSiteKey()
        {
            return Default("GoogleRecaptcha:Google_SiteKey");
        }
        public string GetCaptchaSecretKey()
        {
            return Default("GoogleRecaptcha:Google_SecretKey");
        }
        public string GetDropBoxApiKey()
        {
            return Default("DropBox:ApiKey");
        }
        public string GetDropBoxApiSecret()
        {
            return Default("DropBox:ApiSecret");
        }
        public string GetGoogleOAuthClientId()
        {
            return Default("GoogleOAuth:ClientId");
        }
        public string GetGoogleOAuthClientSecret()
        {
            return Default("GoogleOAuth:ClientSecret");
        }
    }
}
