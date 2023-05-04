using Application.Interface;
using Application.Interface.FacadPattern;
using Application.Services.Command.ServicesLog.AddNewConvertLog;
using Application.Services.Query.ReturnConvertedFileLog;

namespace Application.Services.FacadPattern
{
    public class ConvertLogFacad : IConvertLogFacad
    {
        private readonly IPdfConverterContext _Context;
        public ConvertLogFacad(IPdfConverterContext context)
        {
            _Context = context;
        }
        private IAddNewConvertLogService _addNewConvertLog;
        public IAddNewConvertLogService AddNewConvertLogService
        {
            get
            {
                return _addNewConvertLog = _addNewConvertLog ?? new AddNewConverterLogService(_Context);
            }
        }
        private IReturnConvertedFileLogService _returnConvetedFileLog;
        public IReturnConvertedFileLogService ReturnConvertedFileLogService
        {
            get
            {
                return _returnConvetedFileLog = _returnConvetedFileLog ?? new ReturnConvertedFileLogService(_Context);
            }
        }
    }
}
