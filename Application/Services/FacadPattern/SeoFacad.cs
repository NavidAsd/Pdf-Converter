using Application.Interface;
using Application.Interface.FacadPattern;
using Application.Services.Command.Seo.AddNewMetatagKeywords;
using Application.Services.Command.Seo.UpdateMetatagKeyword;
using Application.Services.Command.Seo.UpdateMetatags;
using Application.Services.Query.Seo.ReturnMetatagKeywords;
using Application.Services.Query.Seo.ReturnMetatags;

namespace Application.Services.FacadPattern
{
    public class SeoFacad : ISeoFacad
    {
        private readonly IPdfConverterContext _Context;
        public SeoFacad(IPdfConverterContext context)
        {
            _Context = context;
        }
        private IReturnMetatagKeywordsService _returnMetatagKeywords;
        public IReturnMetatagKeywordsService ReturnMetatagKeywordsService
        {
            get
            {
                return _returnMetatagKeywords = _returnMetatagKeywords ?? new ReturnMetatagKeywordsService(_Context);
            }
        }
        private IUpdateMetatagKeywordService _updateMetatagkeyword;
        public IUpdateMetatagKeywordService UpdateMetatagKeywordService
        {
            get
            {
                return _updateMetatagkeyword = _updateMetatagkeyword ?? new UpdateMetatagKeywordService(_Context);
            }
        }
        private IAddNewKeywordsService _addNewkeywords;
        public IAddNewKeywordsService AddNewKeywordsService
        {
            get
            {
                return _addNewkeywords = _addNewkeywords ?? new AddNewKeywordsService(_Context);
            }
        }
        private IReturnMetatagsService _returnMetatags;
        public IReturnMetatagsService ReturnMetatagsService
        {
            get
            {
                return _returnMetatags = _returnMetatags ?? new ReturnMetatagsService(_Context);
            }
        }
        private IUpdateMetatagService _updateMetatag;
        public IUpdateMetatagService UpdateMetatagService
        {
            get
            {
                return _updateMetatag = _updateMetatag ?? new UpdateMetatagService(_Context);
            }
        }
    }
}
