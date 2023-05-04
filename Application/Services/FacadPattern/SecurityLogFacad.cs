using Application.Interface;
using Application.Interface.FacadPattern;
using Application.Services.Command.ServicesLog.AddNewSecurityLog;
using Application.Services.Query.ReturnSecurityFileLog;

namespace Application.Services.FacadPattern
{
    public class SecurityLogFacad : ISecurityLogFacad
    {
        private readonly IPdfConverterContext _Context;
        public SecurityLogFacad(IPdfConverterContext context)
        {
            _Context = context;
        }


        private IReturnSecurityFileLogService _returnSecurityLog;
        public IReturnSecurityFileLogService ReturnSecurityFileLogService
        {
            get
            {
                return _returnSecurityLog = _returnSecurityLog ?? new ReturnSecurityFileLogService(_Context);
            }
        }
        private IAddNewSecurityLogService _addNewSecurityLog;
        public IAddNewSecurityLogService AddNewSecurityLogService
        {
            get
            {
                return _addNewSecurityLog = _addNewSecurityLog ?? new AddNewSecurityLogService(_Context);
            }
        }


    }
}
