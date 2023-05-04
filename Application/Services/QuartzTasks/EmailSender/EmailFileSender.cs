using Common;
using Application.Interface.FacadPattern;
using Quartz;
using System.Threading.Tasks;
using Application.Service.SendEmailCode;

namespace Application.Services.QuartzTasks.EmailSender
{
    [DisallowConcurrentExecution]
    public class EmailFileSender : IJob
    {
        private readonly IFeaturesDetailsFacad _Features;
        private readonly IAncillaryServicesFacad _Ancillary;
        public EmailFileSender(IFeaturesDetailsFacad features, IAncillaryServicesFacad ancillary)
        {
            _Features = features;
            _Ancillary = ancillary;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var Files = _Features.ReturnEmailFileSenderService.Execute();
            if (Files.Success)
            {
                foreach (var item in Files.Enything)
                {
                    EmailSenderDetails EmailDetails = new EmailSenderDetails
                    {
                        EmailSender = GetPath.GetCompanyEmail(),
                        EmailPass = GetPath.GetCompanyEmailPass(),
                        RecipientEmail = item.UserEmail,
                        Subject = "PdfConverter [Your-Convered-File]",
                        TextBody = "Your File: "
                    };
                    FileDetails FileDetails = new FileDetails
                    {
                        FileFullPath = $"{GetPath.GetOutputPath()}\\{item.UserIp}\\{item.FileName}",
                        FileName = item.FileName,
                    };
                    var Sender = _Ancillary.EmailSenderService.Sender(new Application.Service.SendEmailCode.RequestEmailSenderDto
                    {
                        EmailDetilas = EmailDetails,
                        FileDetails = FileDetails,
                    });
                    if (Sender.Success || item.TryToSend > 3)
                        _Features.RemoveEmailFileSenderService.Execute(item.Id);
                    else
                        _Features.RemoveEmailFileSenderService.PlusTryToSend(item.Id);
                }
            }
            return Task.CompletedTask;
        }
    }
}
