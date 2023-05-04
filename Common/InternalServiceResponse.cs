
namespace Common
{
    public class InternalServiceResponse
    {
        public int StatusCode { set; get; }
        public string ResponseContent { set; get; }

    }
    public class ServiceResponseEntities
    {
        public bool Success { set; get; }
        public string Message { set; get; }
        public string OutFile { set; get; }
        public string OutPath { set; get; }

    }
    public class UnlockPdfServiceResponseEntitires
    {
        public bool Success { set; get; }
        public string Message { set; get; }
        public string OutFile { set; get; }
        public string OutPath { set; get; }
        public string Password { set; get; }
        public string ProcessTime { set; get; }
    }
    public class UrlShorterResponse
    {
        public string Url { set; get; }
        public int StatusCode { set; get; }
    }
}
