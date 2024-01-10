
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Domain.Entities.Features
{
    public class AllCategories
    {
        Dictionary<string, int> All = new Dictionary<string, int>
        {
            //ConvertFromPdf
            { nameof(ConvertFromPdf.PdfToJpg),ConvertFromPdf.PdfToJpg},
            { nameof(ConvertFromPdf.PdfToPng),ConvertFromPdf.PdfToPng},
            { nameof(ConvertFromPdf.PdfToBmp),ConvertFromPdf.PdfToBmp},
            { nameof(ConvertFromPdf.PdfToGif),ConvertFromPdf.PdfToGif},
            { nameof(ConvertFromPdf.PdfToTiff),ConvertFromPdf.PdfToTiff},
            { nameof(ConvertFromPdf.PdfToExcel),ConvertFromPdf.PdfToExcel},
            { nameof(ConvertFromPdf.PdfToPpt),ConvertFromPdf.PdfToPpt},
            { nameof(ConvertFromPdf.PdfToDoc),ConvertFromPdf.PdfToDoc},
            { nameof(ConvertFromPdf.PdfToPdfA),ConvertFromPdf.PdfToPdfA},
            //ConverterToPdf
            { nameof(ConverterToPdf.ImagesToPdf),ConverterToPdf.ImagesToPdf},
            { nameof(ConverterToPdf.ExcelToPdf),ConverterToPdf.ExcelToPdf},
            { nameof(ConverterToPdf.PptToPdf),ConverterToPdf.PptToPdf},
            { nameof(ConverterToPdf.DocToPdf),ConverterToPdf.DocToPdf},
            { nameof(ConverterToPdf.HtmlToPdf),ConverterToPdf.HtmlToPdf},
            //OtherFeatures
            { nameof(OtherFeatures.PdfReader),OtherFeatures.PdfReader},
            { nameof(OtherFeatures.ExtractImagesFromPdf),OtherFeatures.ExtractImagesFromPdf},
            //Optimizers
            { nameof(Optimizers.CompressPdf),Optimizers.CompressPdf},
            //Organizers
            { nameof(Organizers.MergePdf),Organizers.MergePdf},
            { nameof(Organizers.RotatePdf),Organizers.RotatePdf},
            { nameof(Organizers.DeletePdfPages),Organizers.DeletePdfPages},
            //Security
            { nameof(Security.ProtectPdf),Security.ProtectPdf},
            { nameof(Security.UnlockPdf),Security.UnlockPdf},
            { nameof(Security.RemvePdfProtection),Security.RemvePdfProtection},
        };
        public Dictionary<string,int> ReturnAll()
        {
            return All;
        }
    }
}
