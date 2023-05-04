using Common;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services.Security.RemovePdfProtection
{
    public interface IRemovePdfProtectionService
    {
        Task<ResultMessage<ResultRemovePdfProtectionDto>> ExecuteAsync(RequestRemovePdfProtectionDto request);
    }
    public class ResultRemovePdfProtectionDto
    {
        public string FileName { set; get; }
        public string FilePath { set; get; }
    }
    public class RequestRemovePdfProtectionDto
    {
        public string InputFileName { set; get; }
        public string InputFilePath { set; get; }
        public string Password { set; get; }
        public string OutPutPath { set; get; }
        public string UserIp { set; get; }
    }
    public class RemovePdfProtectionService : IRemovePdfProtectionService
    {
        async Task<ResultMessage<ResultRemovePdfProtectionDto>> IRemovePdfProtectionService.ExecuteAsync(RequestRemovePdfProtectionDto request)
        {
            try
            {
                string OutFileName = Formating.ReturnFileNameWithoutModified(FilesFormat.pdf, "ReomvePdfProtection");
                string OutFilePath = $"{request.OutPutPath}\\{request.UserIp}";
                if (!Directory.Exists(OutFilePath))
                    Directory.CreateDirectory(OutFilePath);

                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader($"{request.InputFilePath}\\{request.InputFileName}", new System.Text.ASCIIEncoding().GetBytes(request.Password));
                try
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        iTextSharp.text.pdf.PdfStamper stamper = new iTextSharp.text.pdf.PdfStamper(reader, memoryStream);
                        stamper.Close();
                        reader.Close();
                        File.WriteAllBytes($"{OutFilePath}\\{OutFileName}", memoryStream.ToArray());
                    }
                    return new ResultMessage<ResultRemovePdfProtectionDto>
                    {
                        Success = true,
                        Enything = new ResultRemovePdfProtectionDto
                        {
                            FileName = OutFileName,
                            FilePath = OutFilePath
                        }
                    };
                }
                catch
                {
                    return new ResultMessage<ResultRemovePdfProtectionDto>
                    {
                        Success = false,
                        Message = "Error on Process Please Try Again",
                        Enything = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultMessage<ResultRemovePdfProtectionDto>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
