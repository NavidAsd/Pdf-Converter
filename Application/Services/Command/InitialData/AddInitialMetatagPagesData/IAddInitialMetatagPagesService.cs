using Application.Interface;
using Common;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Application.Services.Command.InitialData.AddInitialMetatagPagesData
{
    public interface IAddInitialMetatagPagesService
    {
        ResultMessage Execute();
    }
    public class AddInitialMetatagpagesService : IAddInitialMetatagPagesService
    {
        private readonly IPdfConverterContext _Context;
        public readonly IHostingEnvironment _Hosting;
        public AddInitialMetatagpagesService(IPdfConverterContext context, IHostingEnvironment hosting)
        {
            _Context = context;
            _Hosting = hosting;
        }
        ResultMessage IAddInitialMetatagPagesService.Execute()
        {
            Domain.Entities.Seo.Metatags tag;
            List<Domain.Entities.Seo.Metatags> tags = new List<Domain.Entities.Seo.Metatags>();
            Common.InitialData data = new Common.InitialData();
            foreach (var item in data.ReturnAllViewPagesName(_Hosting.ContentRootPath))
            {
                var result = _Context.Metatags.Where(p => p.PageName == Path.GetFileNameWithoutExtension(item)).FirstOrDefault();
                if (result == null)
                {
                    tag = new Domain.Entities.Seo.Metatags();
                    tag.Title = Path.GetFileNameWithoutExtension(item);
                    tag.PageName = Path.GetFileNameWithoutExtension(item);
                    tag.IsRemoved = false;
                    tags.Add(tag);
                }
                else if (result.IsRemoved)
                    result.IsRemoved = false;
                
            }
            _Context.Metatags.AddRange(tags);
            _Context.SaveChanges();
            return new ResultMessage { Success = true };
        }
    }
}
