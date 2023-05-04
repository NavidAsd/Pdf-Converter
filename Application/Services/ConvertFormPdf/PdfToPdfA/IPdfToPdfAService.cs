using Common;
using System.IO;
using SautinSoft.Document;

namespace Application.Services.ConvertFormPdf.PdfToPdfA
{
    public interface IPdfToPdfAService
    {
        ResultMessage<ResultPdfToPdfADto> Execute(RequestPdfToPdfADto request);
    }
    public class ResultPdfToPdfADto
    {

        public string DocName { set; get; }
        public string DocPath { set; get; }
    }
    public class RequestPdfToPdfADto
    {
        public string InputFileName { set; get; }
        public string InputFilePath { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
        public int PdfAType { set; get; }
    }
    public class PdfToPdfAService : IPdfToPdfAService
    {
        ResultMessage<ResultPdfToPdfADto> IPdfToPdfAService.Execute(RequestPdfToPdfADto request)
        {
            try
            {
                var PdfEncrypted = AppliedMethodes.CheckPdfEncrypted($"{request.InputFilePath}\\{request.InputFileName}");
                if (PdfEncrypted.Result.Success)
                {
                    return new ResultMessage<ResultPdfToPdfADto> { Success = false, Message = PdfEncrypted.Result.Message };
                }

                string PdfAName = Formating.ReturnFileName(FilesFormat.pdf, "PdfA");
                string PdfAPath = $"{request.OutputPath}\\{request.UserIp}";
                if (!Directory.Exists(PdfAPath))
                    Directory.CreateDirectory(PdfAPath);

                SautinSoft.Document.PdfLoadOptions pdfLO = new SautinSoft.Document.PdfLoadOptions()
                {
                    // 'false' - means to load vector graphics as is. Don't transform it to raster images.
                    RasterizeVectorGraphics = false,
                    // The PDF format doesn't have real tables, in fact it's a set of orthogonal graphic lines.
                    // In case of 'true' the component will detect and recreate tables from graphic lines.
                    DetectTables = true,
                    ShowInvisibleText = true,
                    OptimizeImages = true,

                    // 'Auto' - Load only embedded fonts missing in the system. In other case, use the system fonts.
                    PreserveEmbeddedFonts = SautinSoft.Document.PropertyState.Auto
                };

                SautinSoft.Document.DocumentCore dc = DocumentCore.Load($"{request.InputFilePath}\\{request.InputFileName}", pdfLO);

                SautinSoft.Document.PdfSaveOptions pdfSO = new PdfSaveOptions()
                {
                    Compliance = ChoosePdfType(request.PdfAType)
                };

                dc.Save($"{PdfAPath}\\{PdfAName}", pdfSO);

                return new ResultMessage<ResultPdfToPdfADto>
                {
                    Success = true,
                    Enything = new ResultPdfToPdfADto
                    {
                        DocName = PdfAName,
                        DocPath = PdfAPath
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultPdfToPdfADto>
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again",
                    Enything = null
                };
            }
        }
        private PdfCompliance ChoosePdfType(int Type)
        {
            switch (Type)
            {
                case Domain.Entities.Features.AllPdfA.PdfA_1A:
                    return PdfCompliance.PDF_A1a;
                case Domain.Entities.Features.AllPdfA.PdfA_1B:
                    return PdfCompliance.PDF_A1b;
                case Domain.Entities.Features.AllPdfA.PdfA_2A:
                    return PdfCompliance.PDF_A2a;
                case Domain.Entities.Features.AllPdfA.PdfA_2B:
                    return PdfCompliance.PDF_A2b;
                case Domain.Entities.Features.AllPdfA.PdfA_2U:
                    return PdfCompliance.PDF_A2u;
                case Domain.Entities.Features.AllPdfA.PdfA_3A:
                    return PdfCompliance.PDF_A3a;
                case Domain.Entities.Features.AllPdfA.PdfA_3B:
                    return PdfCompliance.PDF_A3b;
                case Domain.Entities.Features.AllPdfA.PdfA_3U:
                    return PdfCompliance.PDF_A3u;
                default:
                    return PdfCompliance.PDF_A1a;
            }
        }

    }

}
