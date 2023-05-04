using Application.Interface.FacadPattern;
using System;
using System.Net;
using System.Net.Sockets;
using Xunit;

namespace Converters.Test
{
    public class ConvertFromPdf : IDisposable
    {
        private readonly IConvertersFromPdfFacad _ConverterFacad;
        public ConvertFromPdf(IConvertersFromPdfFacad convert)
        {
            _ConverterFacad = convert;
        }

        [Fact]
        public void test()
        {
            var result = _ConverterFacad.PdfToJpgService.Execute(new Application.Services.ConvertFormPdf.PdfToJpg.RequestPdfToJpgDto
            {
                PdfPath = @"E:\OS\Documentsresult.pdf",
                ImagePath = @"E:\OS",
                UserIp = GetMyIp()
            });
            Assert.Equal(true,result.Success);
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
