using Application.Services.Command.Seo.AddNewMetatagKeywords;
using Application.Services.Command.Seo.UpdateMetatagKeyword;
using Application.Services.Command.Seo.UpdateMetatags;
using Application.Services.Query.Seo.ReturnMetatagKeywords;
using Application.Services.Query.Seo.ReturnMetatags;

namespace Application.Interface.FacadPattern
{
    public interface ISeoFacad
    {
        IReturnMetatagKeywordsService ReturnMetatagKeywordsService { get; }
        IUpdateMetatagKeywordService UpdateMetatagKeywordService { get; }
        IAddNewKeywordsService AddNewKeywordsService { get; }
        IReturnMetatagsService ReturnMetatagsService { get; }
        IUpdateMetatagService UpdateMetatagService { get; }
    }
}
