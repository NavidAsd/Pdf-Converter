using Common;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Security.ProtectedPdf
{
    public interface IProtectionPdfService
    {
        Task<ResultMessage<ResultProtectionPdfDto>> ExecuteAsync(RequestProtectionPdfDto request);
    }
    public class ResultProtectionPdfDto
    {
        public string FileName { set; get; }
        public string FilePath { set; get; }
    }
    public class RequestProtectionPdfDto
    {
        public string InputFileName { set; get; }
        public string InputFilePath { set; get; }
        public string Password { set; get; }
        public string OutPutPath { set; get; }
        public string UserIp { set; get; }
    }
    public class ProtectionPdfService : IProtectionPdfService
    {
        async Task<ResultMessage<ResultProtectionPdfDto>> IProtectionPdfService.ExecuteAsync(RequestProtectionPdfDto request)
        {
            try
            {
                string OutFileName = Formating.ReturnFileNameWithoutModified(FilesFormat.pdf, "ProtectedPdf");
                string OutFilePath = $"{request.OutPutPath}\\{request.UserIp}";
                if (!Directory.Exists(OutFilePath))
                    Directory.CreateDirectory(OutFilePath);

                // add other encoding to .net core for save outputfile
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                PdfDocument document = PdfReader.Open($"{request.InputFilePath}\\{request.InputFileName}", "some text");

                PdfSecuritySettings securitySettings = document.SecuritySettings;

                // PdfDocumentSecurityLevel.Encrypted128Bit
                securitySettings.UserPassword = "PdfConverter";
                securitySettings.OwnerPassword = request.Password;

                // Restrict some rights
                securitySettings.PermitAccessibilityExtractContent = false;
                securitySettings.PermitAnnotations = false;
                securitySettings.PermitAssembleDocument = false;
                securitySettings.PermitExtractContent = false;
                securitySettings.PermitFormsFill = true;
                securitySettings.PermitFullQualityPrint = false;
                securitySettings.PermitModifyDocument = true;
                securitySettings.PermitPrint = false;

                document.Save($"{OutFilePath}\\{OutFileName}");
                return new ResultMessage<ResultProtectionPdfDto>
                {
                    Success = true,
                    Enything = new ResultProtectionPdfDto
                    {
                        FileName = OutFileName,
                        FilePath = OutFilePath
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultProtectionPdfDto>
                {
                    Success = false,
                    Message = "Error on Process Make sure the file you upload is not already encrypted",
                    Enything = null
                };
            }
        }
    }
}
