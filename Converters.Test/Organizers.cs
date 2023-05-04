using System;
using Xunit;
using Common;
using iTextSharp.text.pdf;
using System.Linq;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Converters.Test
{
    public class Organizers : IDisposable
    {
        private bool Result;
        private string OutputPath = @"E:\C#\Web\Test\ConvertFromPdf\Output";
        private string InputPath = @"E:\C#\Web\Test\ConvertFromPdf\Input";
        private string pdfinput = "test2.pdf";
        private string pdfinputEnglish = "Test-English.pdf";

        [Fact]
        protected bool DeletePdfPages()
        {
            int[] pages;
            int[] pagedelete = new int[] { 1, 3, 6, 8, 7 };
            string pageskeepd = "";
            string Out = $"{OutputPath}\\{GetMyIp()}\\{Formating.ReturnFileName(FilesFormat.pdf, "Pdf")}";
            try
            {
                using (PdfReader reader = new PdfReader($"{InputPath}\\{pdfinput}"))
                {
                    pages = new int[reader.NumberOfPages];
                    for (int i = 0; i < reader.NumberOfPages; i++)
                    {
                        pages[i] = i + 1;
                    }
                    foreach (var item in pages.Except(pagedelete).ToList())
                    {
                        pageskeepd += $",{item}";
                    }
                    reader.SelectPages(pageskeepd);

                    using (PdfStamper stamper = new PdfStamper(reader, File.Create(Out)))
                    {
                        stamper.Close();
                    }
                }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool RotatePdf()
        {
            string Out = $"{OutputPath}\\{GetMyIp()}\\{Formating.ReturnFileName(FilesFormat.pdf, "Pdf")}";
            try
            {
                PdfReader reader = new PdfReader($"{InputPath}\\{pdfinput}");
                int pagesCount = reader.NumberOfPages;

                for (int n = 1; n <= pagesCount; n++)
                {
                    PdfDictionary page = reader.GetPageN(n);
                    PdfNumber rotate = page.GetAsNumber(PdfName.ROTATE);
                    int rotation =
                           rotate == null ? 90 : (rotate.IntValue + 180) % 360;

                    page.Put(PdfName.ROTATE, new PdfNumber(rotation));

                }
                PdfStamper stamper = new PdfStamper(reader, File.Create(Out));
               
                stamper.Close();
                reader.Close();
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }
       
        [Fact]
        protected bool MergPdfs()
        {
            try
            {
                // add other encoding to .net core for save outputfile
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string Out = $"{OutputPath}\\{GetMyIp()}\\{Formating.ReturnFileName(FilesFormat.pdf, "Pdf")}";
                string[] pdfs = new string[] { InputPath + "\\" + "test2.pdf", InputPath + "\\" + "Test-English.pdf" };
                using (var targetDoc = new PdfSharp.Pdf.PdfDocument())
                {
                    foreach (var pdf in pdfs)
                    {
                        using (var pdfDoc = PdfSharp.Pdf.IO.PdfReader.Open(pdf, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import))
                        {
                            for (var i = 0; i < pdfDoc.PageCount; i++)
                                targetDoc.AddPage(pdfDoc.Pages[i]);
                        }
                    }
                    targetDoc.Save(Out);
                }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;

        }
      
        [Fact]
        protected bool CompressionPdf()
        {
            // add other encoding to .net core for save outputfile
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string Out = $"{OutputPath}\\{GetMyIp()}\\{Formating.ReturnFileName(FilesFormat.pdf, "Pdf")}";
                using (var stream = new MemoryStream(File.ReadAllBytes(InputPath + "\\" + "test2.pdf")) { Position = 0 })
                using (var source = PdfSharp.Pdf.IO.PdfReader.Open(stream, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import))
                using (var document = new PdfSharp.Pdf.PdfDocument())
                {
                    var options = document.Options;
                    options.FlateEncodeMode = PdfSharp.Pdf.PdfFlateEncodeMode.BestCompression;
                    options.UseFlateDecoderForJpegImages = PdfSharp.Pdf.PdfUseFlateDecoderForJpegImages.Automatic;
                    options.CompressContentStreams = true;
                    options.NoCompression = false;
                    foreach (var page in source.Pages)
                    {
                        document.AddPage(page);
                    }

                    document.Save(Out);
                }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }
        private string GetMyIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return null;
        }

        public void Dispose()
        {

        }
    }
}
