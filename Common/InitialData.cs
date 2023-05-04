using System.Collections.Generic;
using System.IO;
using Domain.Entities.Features;

namespace Common
{
    public class InitialData
    {
        public string ReturnServiceName(int service)
        {
            switch (service)
            {
                case ConvertFromPdf.PdfToTiff:
                    return nameof(ConvertFromPdf.PdfToTiff);
                case ConvertFromPdf.PdfToPpt:
                    return nameof(ConvertFromPdf.PdfToPpt);
                case ConvertFromPdf.PdfToPng:
                    return nameof(ConvertFromPdf.PdfToPng);
                case ConvertFromPdf.PdfToPdfA:
                    return nameof(ConvertFromPdf.PdfToPdfA);
                case ConvertFromPdf.PdfToDoc:
                    return nameof(ConvertFromPdf.PdfToDoc);
                case ConvertFromPdf.PdfToExcel:
                    return nameof(ConvertFromPdf.PdfToExcel);
                case ConvertFromPdf.PdfToGif:
                    return nameof(ConvertFromPdf.PdfToGif);
                case ConvertFromPdf.PdfToJpg:
                    return nameof(ConvertFromPdf.PdfToJpg);
                case ConvertFromPdf.PdfToBmp:
                    return nameof(ConvertFromPdf.PdfToBmp);

                case ConverterToPdf.ImagesToPdf:
                    return nameof(ConverterToPdf.ImagesToPdf);
                case ConverterToPdf.HtmlToPdf:
                    return nameof(ConverterToPdf.HtmlToPdf);
                case ConverterToPdf.DocToPdf:
                    return nameof(ConverterToPdf.DocToPdf);
                case ConverterToPdf.ExcelToPdf:
                    return nameof(ConverterToPdf.ExcelToPdf);
                case ConverterToPdf.PptToPdf:
                    return nameof(ConverterToPdf.PptToPdf);

                case OtherFeatures.ExtractImagesFromPdf:
                    return nameof(OtherFeatures.ExtractImagesFromPdf);
                case OtherFeatures.PdfReader:
                    return nameof(OtherFeatures.PdfReader);

                case Domain.Entities.Features.Organizers.DeletePdfPages:
                    return nameof(Domain.Entities.Features.Organizers.DeletePdfPages);
                case Domain.Entities.Features.Organizers.RotatePdf:
                    return nameof(Domain.Entities.Features.Organizers.RotatePdf);
                case Domain.Entities.Features.Organizers.MergePdf:
                    return nameof(Domain.Entities.Features.Organizers.MergePdf);

                case Domain.Entities.Features.Security.ProtectPdf:
                    return nameof(Domain.Entities.Features.Security.ProtectPdf);
                case Domain.Entities.Features.Security.UnlockPdf:
                    return nameof(Domain.Entities.Features.Security.UnlockPdf);
                case Domain.Entities.Features.Security.RemvePdfProtection:
                    return nameof(Domain.Entities.Features.Security.RemvePdfProtection);

                case Domain.Entities.Features.Optimizers.CompressPdf:
                    return nameof(Domain.Entities.Features.Optimizers.CompressPdf);

                default: return null;

            }
        }
        public string ReturnServiceNameForBlogContent(int? service)
        {
            switch (service)
            {
                case ConvertFromPdf.PdfToTiff:
                    return "PDF To Images";
                case ConvertFromPdf.PdfToPpt:
                    return "PDF To PowerPoint";
                case ConvertFromPdf.PdfToPng:
                    return "PDF To Images";
                case ConvertFromPdf.PdfToPdfA:
                    return "PDF To PDF/A";
                case ConvertFromPdf.PdfToDoc:
                    return "PDF To Word";
                case ConvertFromPdf.PdfToExcel:
                    return "PDF To Excel";
                case ConvertFromPdf.PdfToGif:
                    return "PDF To Images";
                case ConvertFromPdf.PdfToJpg:
                    return "PDF To Images";
                case ConvertFromPdf.PdfToBmp:
                    return "PDF To Images";

                case ConverterToPdf.ImagesToPdf:
                    return "Imges To PDF";
                case ConverterToPdf.HtmlToPdf:
                    return "Html To PDF";
                case ConverterToPdf.DocToPdf:
                    return "Word To PDF";
                case ConverterToPdf.ExcelToPdf:
                    return "Excel To PDF";
                case ConverterToPdf.PptToPdf:
                    return "Powerpoint To PDF";

                case OtherFeatures.ExtractImagesFromPdf:
                    return "Extract PDF Images";
                case OtherFeatures.PdfReader:
                    return "PDF Reader";

                case Domain.Entities.Features.Organizers.DeletePdfPages:
                    return "Delete PDF Pages";
                case Domain.Entities.Features.Organizers.RotatePdf:
                    return "Rotate PDF";
                case Domain.Entities.Features.Organizers.MergePdf:
                    return "Merge PDF";

                case Domain.Entities.Features.Security.ProtectPdf:
                    return "Protect PDF";
                case Domain.Entities.Features.Security.UnlockPdf:
                    return "Unlock PDF";
                case Domain.Entities.Features.Security.RemvePdfProtection:
                    return "Remove PDF Protection";

                case Domain.Entities.Features.Optimizers.CompressPdf:
                    return "Compress PDF";

                case null:
                    return "PDF documents";

                default: return "PDF documents";

            }
        }
        public List<string> ReturnAllViewPagesName(string EnvironmentHostPath)
        { //Just Worked on Localhost Area
            string BaseFolder = $"{EnvironmentHostPath}\\Views";
            string[] Folders = new string[] { "ConvertFromPdf", "ConvertToPdf", "Downloader", "Error", "Home", "Optimize", "Organize", "Other", "Security" };
            List<string> Names = new List<string>();
            DirectoryInfo F;

            foreach (var item in Folders)
            {
                F = new DirectoryInfo($"{BaseFolder}\\{item}");
                FileInfo[] Files = F.GetFiles("*.cshtml"); //Getting cshtml files

                foreach (FileInfo file in Files)
                {
                    Names.Add(file.Name);
                }

            }
            return Names;
        }
    }
}
