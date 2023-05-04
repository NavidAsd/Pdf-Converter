using Application.Interface.FacadPattern;
using Application.Services.Command.ServicesLog.AddNewSecurityLog;
using Application.Services.Security.ProtectedPdf;
using Application.Services.Security.RemovePdfProtection;
using Application.Services.Security.UnlockPdf;

namespace Application.Services.FacadPattern
{
    public class SecurityFacad : ISecurityFacad
    {
        public SecurityFacad() { }

        private IUnlockPdfService _unlockPdfService;
        public IUnlockPdfService UnlockPdfService
        {
            get
            {
                return _unlockPdfService = _unlockPdfService ?? new UnlockPdfService();
            }
        }
        private IProtectionPdfService _protectPdfService;
        public IProtectionPdfService ProtectionPdfService
        {
            get
            {
                return _protectPdfService = _protectPdfService ?? new ProtectionPdfService();
            }
        }
        private IRemovePdfProtectionService _removePdfProtectionService;
        public IRemovePdfProtectionService RemovePdfProtectionService
        {
            get
            {
                return _removePdfProtectionService = _removePdfProtectionService ?? new RemovePdfProtectionService();
            }
        }
    }
}
