using Application.Interface;
using Application.Interface.FacadPattern;
using Application.Services.Command.ServicesLog.AddOtherFeaturesLog;
using Application.Services.Query.ReturnOtherFileLog;

namespace Application.Services.FacadPattern
{
    public class OtherFeaturesLogService : IOtherFeaturesLogService
    {
        private readonly IPdfConverterContext _Context;
        public OtherFeaturesLogService(IPdfConverterContext context)
        {
            _Context = context;
        }

        private IReturnOtherFileLogService _returnOtherFileLog;
        public IReturnOtherFileLogService ReturnOtherFileLogService
        {
            get
            {
                return _returnOtherFileLog = _returnOtherFileLog ?? new ReturnOtherFileLogService(_Context);
            }
        }
        private IAddNewOtherFeaturesLogService _addNewOtherFeaturesLog;
        public IAddNewOtherFeaturesLogService AddNewOtherFeaturesLogService
        {
            get
            {
                return _addNewOtherFeaturesLog = _addNewOtherFeaturesLog ?? new AddNewOtherFeaturesLogService(_Context);
            }
        }
    }
}
