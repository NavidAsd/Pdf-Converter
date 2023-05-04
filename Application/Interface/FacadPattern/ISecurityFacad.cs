using Application.Services.Security.ProtectedPdf;
using Application.Services.Security.RemovePdfProtection;
using Application.Services.Security.UnlockPdf;

namespace Application.Interface.FacadPattern
{
    public interface ISecurityFacad
    {
        IUnlockPdfService UnlockPdfService { get; }
        IProtectionPdfService ProtectionPdfService { get; }
        IRemovePdfProtectionService RemovePdfProtectionService { get; }

    }
}
