using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Application.Service.SendEmailCode
{
    public interface IEmailSenderService
    {
        Task<ResultMessage> SenderAsync(RequestEmailSenderDto request);
        Task<ResultMessage<ResultSendEmailCodeDto>> CodeSenderAsync(EmailSenderDetails request);

    }
    public class EmailSenderService : IEmailSenderService
    {
        async Task<ResultMessage> IEmailSenderService.SenderAsync(RequestEmailSenderDto request)
        {

            MailMessage message = new MailMessage(request.EmailDetilas.EmailSender, request.EmailDetilas.RecipientEmail);

            message.Subject = request.EmailDetilas.Subject;
            message.Body = request.EmailDetilas.TextBody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            // Attach File To Context
            if (!string.IsNullOrWhiteSpace(request.FileDetails.FileFullPath))
            {
                try
                {
                    FileStream File = new FileStream(request.FileDetails.FileFullPath,
                            FileMode.Open, FileAccess.Read, FileShare.None);
                    message.Attachments.Add(new Attachment(File, request.FileDetails.FileName));

                }
                catch { }
            }
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(request.EmailDetilas.EmailSender, request.EmailDetilas.EmailPass);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                 client.Send(message);
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
            return new ResultMessage
            {
                Success = true,
                Message = "Email successfully sent to destination",
            };
        }
        async Task<ResultMessage<ResultSendEmailCodeDto>> IEmailSenderService.CodeSenderAsync(EmailSenderDetails request)
        {
            Random randint = new Random();
            long Code = randint.Next(GetPath.GetMinCode(), GetPath.GetMaxCode());

            MailMessage message = new MailMessage(request.EmailSender, request.RecipientEmail);

            message.Subject = request.Subject;
            message.Body = request.TextBody + "<u>" + Code + "</u>";
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(request.EmailSender, request.EmailPass);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                return new ResultMessage<ResultSendEmailCodeDto>
                {
                    Success = false,
                    Message = ex.Message,
                    Enything = new ResultSendEmailCodeDto { Code = 0 }
                };
            }

            return new ResultMessage<ResultSendEmailCodeDto>
            {
                Success = true,
                Message = "You have 6 minutes to use the submitted code",
                Enything = new ResultSendEmailCodeDto { Code = Code }
            };
        }
    }
    public class EmailSenderDetails
    {
        public string EmailSender { set; get; }
        public string EmailPass { set; get; }
        public string Subject { set; get; }
        public string TextBody { set; get; }
        public string RecipientEmail { set; get; }
    }

    public class RequestEmailSenderDto
    {
        public EmailSenderDetails EmailDetilas { set; get; }
        public FileDetails FileDetails { set; get; }
    }
    public class FileDetails
    {
        public string? FileFullPath { set; get; }
        public string? FileName { set; get; }
    }
    public class ResultSendEmailCodeDto
    {
        public long Code { set; get; }
    }
}