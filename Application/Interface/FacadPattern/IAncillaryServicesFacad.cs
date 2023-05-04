using Application.Service.SendEmailCode;
using Application.Services.Google.Recaptcha;
using Application.Services.QRCode;

namespace Application.Interface.FacadPattern
{
    public interface IAncillaryServicesFacad
    {
        IEmailSenderService EmailSenderService { get; }
        IGoogleRecaptchaService GoogleRecaptchaService { get; }
        IGenerateQrCodeService GenerateQrCodeService { get; }

    }
}

