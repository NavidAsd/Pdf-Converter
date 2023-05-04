using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Common;

namespace Application.Services.Command.InitialData.AddInitialAdditionalHelp
{
    public interface IAddInitialAdditionalHelpService
    {
        ResultMessage Execute();
    }
    public class AddInitialAdditionalHelpService : IAddInitialAdditionalHelpService
    {
        private readonly IPdfConverterContext _Context;
        public AddInitialAdditionalHelpService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IAddInitialAdditionalHelpService.Execute()
        {
            _Context.AdditionalHelps.RemoveRange(_Context.AdditionalHelps.ToList());
            _Context.SaveChanges();
            Common.InitialData data = new Common.InitialData();
            for (int i = 1; i <= 23; i++)
            {
                var Service = data.ReturnServiceName(i);
                if (Service != null)
                {
                    Domain.Entities.OtherContext.AdditionalHelp additional = new Domain.Entities.OtherContext.AdditionalHelp
                    {
                        Service = Service,
                        InsertTime = System.DateTime.Now,
                        ServiceType = i,
                        IsRemoved = false,
                        LastUpdate = System.DateTime.Now,
                        HelpContext = "Help Context",
                        ServiceDescription = "Service Description",
                        BlockTitlecenter = "None",
                        BlockTitleleft = "None",
                        BlockTitleright = "None",
                        Textcenter = "None",
                        Textleft = "None",
                        Textright = "None",
                        Title = "Title"
                    };
                    _Context.AdditionalHelps.Add(additional);
                }
            }
            _Context.SaveChanges();
            return new ResultMessage { Success = true };

        }
    }
}
