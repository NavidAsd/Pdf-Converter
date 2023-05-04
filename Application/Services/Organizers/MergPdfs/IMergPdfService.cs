using Common;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services.Organizers.MergPdfs
{
    public interface IMergPdfService
    {
        Task<ResultMessage<ResultMergPdfsDto>> ExecuteAsync(RequestMergPdfsDto request);
    }
    public class ResultMergPdfsDto
    {
        public string OutFileName { set; get; }
        public string OutFilePath { set; get; }
    }
    public class RequestMergPdfsDto
    {
        public string[] InputFileNames { set; get; }
        public string InputFilePath { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class MergPdfService : IMergPdfService
    {
        async Task<ResultMessage<ResultMergPdfsDto>> IMergPdfService.ExecuteAsync(RequestMergPdfsDto request)
        {
            try
            {
                // add other encoding to .net core for save outputfile
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string OutFileName = Formating.ReturnFileNameWithoutModified(FilesFormat.pdf, "MergePdfs");
                string OutFilePath = $"{request.OutputPath}\\{request.UserIp}";
                if (!Directory.Exists(OutFilePath))
                    Directory.CreateDirectory(OutFilePath);

                using (var targetDoc = new PdfSharp.Pdf.PdfDocument())
                {
                    for(int j = 0; j < request.InputFileNames.Length; j++) 
                    {
                        using (var pdfDoc = PdfSharp.Pdf.IO.PdfReader.Open($"{request.InputFilePath}\\{request.InputFileNames[j]}", PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import))
                        {
                            for (var i = 0; i < pdfDoc.PageCount; i++)
                                targetDoc.AddPage(pdfDoc.Pages[i]);
                        }
                    }
                    targetDoc.Save($"{OutFilePath}\\{OutFileName}");
                }
                return new ResultMessage<ResultMergPdfsDto>
                {
                    Success = true,
                    Enything = new ResultMergPdfsDto
                    {
                        OutFileName = OutFileName,
                        OutFilePath = OutFilePath,
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultMergPdfsDto>
                {
                    Success = false,
                    Message = "Error on Process Please Try Again",
                    Enything = null
                };
            }
        }
    }
}
