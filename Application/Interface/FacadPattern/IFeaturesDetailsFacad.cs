using Application.Services.Command.AddInpuFile;
using Application.Services.Command.AddNewEmailFileSender;
using Application.Services.Command.AddNewUserComment;
using Application.Services.Command.AddNewUserMessage;
using Application.Services.Command.ChangeServiceState;
using Application.Services.Command.ChangeUserCommentState;
using Application.Services.Command.EditServiceDetails;
using Application.Services.Command.RemoveEmailFileSender;
using Application.Services.Command.RemoveOutFile;
using Application.Services.Command.UpdateFeatureDetails;
using Application.Services.Command.UpdateInputFileDetail;
using Application.Services.Command.UpdateShortLink.UpdateConverterLogShortLink;
using Application.Services.Command.UpdateShortLink.UpdateOptimizeLogShortLink;
using Application.Services.Command.UpdateShortLink.UpdateOrganizeLogShortLink;
using Application.Services.Command.UpdateShortLink.UpdateOtherFeaturesShortLink;
using Application.Services.Command.UpdateShortLink.UpdateSecurityLogShortLink;
using Application.Services.Query.GetAllFeaturesDetails;
using Application.Services.Query.ReturnEmailFileSender;
using Application.Services.Query.ReturnFeatureDetails;
using Application.Services.Query.ReturnInputFileDetails;
using Application.Services.Query.ReturnUserMessages;
using Application.Services.Query.ReturnUsersCommnets;
using Application.Services.Query.ViewContext.ReturnTotalUseAvg;

namespace Application.Interface.FacadPattern
{
    public interface IFeaturesDetailsFacad
    {
        IGetAllFeaturesDetailsService GetAllFeaturesDetailsService { get; }
        IReturnFeatureDetailsService ReturnFeatureDetailsService { get; }
        IChangeFeatureStateService ChangeFeatureStateService { get; }
        IEditFeatureDetailsService EditFeatureDetailsService { get; }
        IAddNewEmailFileSenderService AddNewEmailFileSenderService { get; }
        IReturnEmailFileSenderService ReturnEmailFileSenderService { get; }
        IRemoveEmailFileSenderService RemoveEmailFileSenderService { get; }
        IAddNewUserCommentService AddNewUserCommentService { get; }
        IUpdateFeatureDetailsService UpdateFeatureDetailsService { get; }
        IReturnUsersCommnetsService ReturnUsersCommnetsService { get; }
        IChangeUserCommentStateService ChangeUserCommentStateService { get; }
        IAddInputFileService AddInputFileService { get; }
        IUpdateInputFileService UpdateInputFileService { get; }
        IReturnInputFileDetailsService ReturnInputFileDetailsService { get; }
        IRemoveOutFileService RemoveOutFileService { get; }
        IUpdateOtherFeaturesLogShortLinkService UpdateOtherFeaturesLogShortLinkService { get; }
        IUpdateConverterLogShortLinkService UpdateConverterLogShortLinkService { get; }
        IUpdateSecurityLogShortLinkService UpdateSecurityLogShortLinkService { get; }
        IUpdateOrganizeLogShortLinkService UpdateOrganizeLogShortLinkService { get; }
        IUpdateOptimizeLogShortLinkService UpdateOptimizeLogShortLinkService { get; }
        IReturnTotalUseAvgService ReturnTotalUseAvgService { get; }
        IAddNewUserMessageService AddNewUserMessageService { get; }
        IReturnUserMessagesService ReturnUserMessagesService { get; } 

    }
}
