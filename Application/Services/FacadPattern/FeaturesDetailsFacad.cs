using Application.Interface;
using Application.Interface.FacadPattern;
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

namespace Application.Services.FacadPattern
{
    public class FeaturesDetailsFacad : IFeaturesDetailsFacad
    {
        private readonly IPdfConverterContext _Context;
        public FeaturesDetailsFacad(IPdfConverterContext context)
        {
            _Context = context;
        }
        private IGetAllFeaturesDetailsService _getAllFeatures;
        public IGetAllFeaturesDetailsService GetAllFeaturesDetailsService
        {
            get
            {
                return _getAllFeatures = _getAllFeatures ?? new GetAllFeaturesDetailsService(_Context);
            }
        }
        private IReturnFeatureDetailsService _returnFeaturesDetails;
        public IReturnFeatureDetailsService ReturnFeatureDetailsService
        {
            get
            {
                return _returnFeaturesDetails = _returnFeaturesDetails ?? new ReturnFeatureDetailsService(_Context);
            }
        }
        private IChangeFeatureStateService _changeFeatureState;
        public IChangeFeatureStateService ChangeFeatureStateService
        {
            get
            {
                return _changeFeatureState = _changeFeatureState ?? new ChangeFeatureStateService(_Context);
            }
        }
        private IEditFeatureDetailsService _editFeatureDetails;
        public IEditFeatureDetailsService EditFeatureDetailsService
        {
            get
            {
                return _editFeatureDetails = _editFeatureDetails ?? new EditFeatureDetailsService(_Context);
            }
        }
        private IAddNewEmailFileSenderService _addNewEmailFileSender;
        public IAddNewEmailFileSenderService AddNewEmailFileSenderService
        {
            get
            {
                return _addNewEmailFileSender = _addNewEmailFileSender ?? new AddNewEmailFileSenderService(_Context);
            }
        }
        private IReturnEmailFileSenderService _returnEmailFileSender;
        public IReturnEmailFileSenderService ReturnEmailFileSenderService
        {
            get
            {
                return _returnEmailFileSender = _returnEmailFileSender ?? new ReturnEmailFileSenderService(_Context);
            }
        }
        private IRemoveEmailFileSenderService _removeEmailFileSender;
        public IRemoveEmailFileSenderService RemoveEmailFileSenderService
        {
            get
            {
                return _removeEmailFileSender = _removeEmailFileSender ?? new RemoveEmailFileSenderService(_Context);
            }
        }
        private IAddNewUserCommentService _addNewUserComments;
        public IAddNewUserCommentService AddNewUserCommentService
        {
            get
            {
                return _addNewUserComments = _addNewUserComments ?? new AddNewUserCommentService(_Context);
            }
        }
        private IUpdateFeatureDetailsService _updateFeatureDetails;
        public IUpdateFeatureDetailsService UpdateFeatureDetailsService
        {
            get
            {
                return _updateFeatureDetails = _updateFeatureDetails ?? new UpdateFeatureDetailsService(_Context);
            }
        }
        private IReturnUsersCommnetsService _returnUsersComments;
        public IReturnUsersCommnetsService ReturnUsersCommnetsService
        {
            get
            {
                return _returnUsersComments = _returnUsersComments ?? new ReturnUsersCommentsService(_Context);
            }
        }
        private IChangeUserCommentStateService _chagneUserCommentState;
        public IChangeUserCommentStateService ChangeUserCommentStateService
        {
            get
            {
                return _chagneUserCommentState = _chagneUserCommentState ?? new ChangeUserCommentStateService(_Context);
            }
        }
        private IAddInputFileService _addInpuFile;
        public IAddInputFileService AddInputFileService
        {
            get
            {
                return _addInpuFile = _addInpuFile ?? new AddInputFileService(_Context);
            }
        }
        private IUpdateInputFileService _updateInputFile;
        public IUpdateInputFileService UpdateInputFileService
        {
            get
            {
                return _updateInputFile = _updateInputFile ?? new UpdateInputFileService(_Context);
            }
        }
        private IReturnInputFileDetailsService _returnInputFileDetails;
        public IReturnInputFileDetailsService ReturnInputFileDetailsService
        {
            get
            {
                return _returnInputFileDetails = _returnInputFileDetails ?? new ReturnInputFileDetailsService(_Context);
            }
        }
        private IRemoveOutFileService _removeOutFile;
        public IRemoveOutFileService RemoveOutFileService
        {
            get
            {
                return _removeOutFile = _removeOutFile ?? new RemoveOutFileService(_Context);
            }
        }
        private IUpdateOptimizeLogShortLinkService _updateOptimizeLogShortLink;
        public IUpdateOptimizeLogShortLinkService UpdateOptimizeLogShortLinkService
        {
            get
            {
                return _updateOptimizeLogShortLink = _updateOptimizeLogShortLink ?? new UpdateOptimizeLogShortLinkService(_Context);
            }
        }
        private IUpdateOrganizeLogShortLinkService _updateOrganizeLogShortLink;
        public IUpdateOrganizeLogShortLinkService UpdateOrganizeLogShortLinkService
        {
            get
            {
                return _updateOrganizeLogShortLink = _updateOrganizeLogShortLink ?? new UpdateOrganizeLogShortLinkService(_Context);
            }
        }
        private IUpdateSecurityLogShortLinkService _updateSecurityLogShortLink;
        public IUpdateSecurityLogShortLinkService UpdateSecurityLogShortLinkService
        {
            get
            {
                return _updateSecurityLogShortLink = _updateSecurityLogShortLink ?? new UpdateSecurityLogShortLinkService(_Context);
            }
        }
        private IUpdateConverterLogShortLinkService _updateConverterLogShortLink;
        public IUpdateConverterLogShortLinkService UpdateConverterLogShortLinkService
        {
            get
            {
                return _updateConverterLogShortLink = _updateConverterLogShortLink ?? new UpdateConverterLogShortLinkService(_Context);
            }
        }
        private IUpdateOtherFeaturesLogShortLinkService _updateOtherFeaturesShortLink;
        public IUpdateOtherFeaturesLogShortLinkService UpdateOtherFeaturesLogShortLinkService
        {
            get
            {
                return _updateOtherFeaturesShortLink = _updateOtherFeaturesShortLink ?? new UpdateOtherFeaturesLogShortLinkService(_Context);
            }
        }
        private IReturnTotalUseAvgService _returnTotalUse;
        public IReturnTotalUseAvgService ReturnTotalUseAvgService
        {
            get
            {
                return _returnTotalUse = _returnTotalUse ?? new ReturnTotalUseAvgService(_Context);
            }
        }
        private IAddNewUserMessageService _addNewUserMessage;
        public IAddNewUserMessageService AddNewUserMessageService
        {
            get
            {
                return _addNewUserMessage = _addNewUserMessage ?? new AddNewUserMessageService(_Context);
            }
        }
        private IReturnUserMessagesService _returnUserMessages;
        public IReturnUserMessagesService ReturnUserMessagesService
        {
            get
            {
                return _returnUserMessages = _returnUserMessages ?? new ReturnUserMessagesService(_Context);
            }
        }

    }
}
