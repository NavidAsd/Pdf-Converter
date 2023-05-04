using Common;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Xunit;
using System.Net;
using System.Net.Sockets;

namespace Converters.Test
{
    public class Security : IDisposable
    {
        private bool Result;
        private string OutputPath = @"E:\C#\Web\Test\ConvertFromPdf\Output";
        private string InputPath = @"E:\C#\Web\Test\ConvertFromPdf\Input";
        private string Lockedpdfinput = "ggtest2.pdf";
        private string pdfinput = "test2.pdf";
        private string InputPathForApi = @"E:\C\Input";
        private string InputPdw = "top-pdw.txt";
        private string OutputPathForApi = @"E:\C\Output";

        [Fact]
        protected bool ProtectPdf()
        {
            try
            {
                // add other encoding to .net core for save outputfile
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // Open an existing document. Providing an unrequired password is ignored.
                PdfDocument document = PdfReader.Open($"{InputPath}\\{pdfinput}", "some text");

                PdfSecuritySettings securitySettings = document.SecuritySettings;

                // Setting one of the passwords automatically sets the security level to 
                // PdfDocumentSecurityLevel.Encrypted128Bit.
                securitySettings.UserPassword = "user";
                securitySettings.OwnerPassword = "owner";

                // Don't use 40 bit encryption unless needed for compatibility reasons
                //securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;

                // Restrict some rights.
                securitySettings.PermitAccessibilityExtractContent = false;
                securitySettings.PermitAnnotations = false;
                securitySettings.PermitAssembleDocument = false;
                securitySettings.PermitExtractContent = false;
                securitySettings.PermitFormsFill = true;
                securitySettings.PermitFullQualityPrint = false;
                securitySettings.PermitModifyDocument = true;
                securitySettings.PermitPrint = false;

                // Save doc
                document.Save($"{OutputPath}\\{Formating.ReturnFileNameWithoutModified(FilesFormat.pdf, "Protected-Pdf")}");
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;

        }

        [Fact]
        protected bool RemovePdfProtection()
        {
            try
            {
                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader($"{InputPath}\\{pdfinput}", new System.Text.ASCIIEncoding().GetBytes("owner"));

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    iTextSharp.text.pdf.PdfStamper stamper = new iTextSharp.text.pdf.PdfStamper(reader, memoryStream);
                    stamper.Close();
                    reader.Close();
                    File.WriteAllBytes(OutputPath + "\\RemoveProtectiontest.pdf", memoryStream.ToArray());
                }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool UnlockPdf()
        {
            try
            {
                var Sender = AppliedMethodes.RequestSender(AppliedMethodes.UrlMakerForUnlock("http://127.0.0.1:5000", ApiServices.UnlockPdf, InputPathForApi, InputPdw, InputPathForApi, Lockedpdfinput, OutputPathForApi, GetMyIp()), false);
                var Response = JsonConvert.DeserializeObject<ResultMessage<UnlockPdfServiceResponseEntitires>>(Sender.Result.ResponseContent);
                if (Sender.Result.StatusCode == 200)
                    if (Response.Success)
                        Result = true;
                    else
                        Result = false;
                else
                    Result = false;
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
