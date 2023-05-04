using Application.Interface.FacadPattern;
using Application.Service.SendEmailCode;
using Application.Services.Google.Recaptcha;
using Application.Services.QRCode;
using Microsoft.Extensions.Configuration;

namespace Application.Services.FacadPattern
{
    public class AncillaryServicesFacad : IAncillaryServicesFacad
    {
        private readonly IConfiguration _Configuration;
        public AncillaryServicesFacad(IConfiguration configuration)
        { _Configuration = configuration; }

        private IEmailSenderService _emailSender;
        public IEmailSenderService EmailSenderService
        {
            get
            {
                return _emailSender = _emailSender ?? new EmailSenderService();
            }
        }
        private IGoogleRecaptchaService _googleRecaptcha;
        public IGoogleRecaptchaService GoogleRecaptchaService
        {
            get
            {
                return _googleRecaptcha = _googleRecaptcha ?? new GoogleRecaptchaService(_Configuration);
            }
        }
        private IGenerateQrCodeService _qrMakar;
        public IGenerateQrCodeService GenerateQrCodeService
        {
            get
            {
                return _qrMakar = _qrMakar ?? new GenerateQrCodeService();
            }
        }
    }
}
