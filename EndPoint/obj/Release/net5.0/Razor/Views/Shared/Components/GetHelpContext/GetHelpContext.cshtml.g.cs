#pragma checksum "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68e11ed1ef084e9a97c53797f569fba1a819b40c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_GetHelpContext_GetHelpContext), @"mvc.1.0.view", @"/Views/Shared/Components/GetHelpContext/GetHelpContext.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\_ViewImports.cshtml"
using EndPoint;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\_ViewImports.cshtml"
using EndPoint.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68e11ed1ef084e9a97c53797f569fba1a819b40c", @"/Views/Shared/Components/GetHelpContext/GetHelpContext.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3cd8e7a4273f1e7f88356e8b76b3e7d2eb06234", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_GetHelpContext_GetHelpContext : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Common.ResultMessage<Domain.Entities.OtherContext.AdditionalHelp>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"section main-services-info-box\">\r\n    <div class=\"row justify-content-center\">\r\n");
#nullable restore
#line 7 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
         if (!string.IsNullOrWhiteSpace(ViewBag.FetureDetails.Enything.HelpContext))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-12 text-center mt-5\">\r\n\r\n                        <h2>");
#nullable restore
#line 12 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
                       Write(Model.Enything.HelpContext);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        <p>");
#nullable restore
#line 13 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
                      Write(Html.Raw(ViewBag.FetureDetails.Enything.HelpContext));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n");
#nullable restore
#line 15 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
         if (!string.IsNullOrWhiteSpace(ViewBag.FetureDetails.Enything.Description))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""section main-services-info-box m-4"">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <div class=""row text-left"" style=""direction: rtl;"">
                            <div class=""col-md-8 col-12 text-center""");
            BeginWriteAttribute("style", " style=\"", 1013, "\"", 1021, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 26 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
                         if (ViewBag.images.Success)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
                             if (ViewBag.Images.Enything.ImageAlt != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <img");
            BeginWriteAttribute("src", " src=\"", 1249, "\"", 1342, 3);
#nullable restore
#line 30 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
WriteAttributeValue("", 1255, Common.GetPath.GetServiceImages().Replace("wwwroot",""), 1255, 56, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1311, "/", 1311, 1, true);
#nullable restore
#line 30 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
WriteAttributeValue("", 1312, ViewBag.Images.Enything.Image, 1312, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", "title=\"", 1343, "\"", 1385, 1);
#nullable restore
#line 30 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
WriteAttributeValue("", 1350, ViewBag.Images.Enything.ImageTitle, 1350, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "  alt=\"", 1386, "\"", 1426, 1);
#nullable restore
#line 30 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
WriteAttributeValue("", 1393, ViewBag.Images.Enything.ImageAlt, 1393, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"auto\" height=\"auto\">\r\n");
#nullable restore
#line 31 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                 <img");
            BeginWriteAttribute("src", " src=\"", 1590, "\"", 1683, 3);
#nullable restore
#line 34 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
WriteAttributeValue("", 1596, Common.GetPath.GetServiceImages().Replace("wwwroot",""), 1596, 56, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1652, "/", 1652, 1, true);
#nullable restore
#line 34 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
WriteAttributeValue("", 1653, ViewBag.Images.Enything.Image, 1653, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("  alt=\"pdfconverter-main-services-img\" width=\"auto\" height=\"auto\">\r\n");
#nullable restore
#line 35 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div><div class=\"col-md-4 col-12 text-center\">\r\n                                <h2 class=\"mb-4 mt-5\">");
#nullable restore
#line 38 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
                                                 Write(Model.Enything.ServiceDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                                <p>");
#nullable restore
#line 39 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
                              Write(Html.Raw(ViewBag.FetureDetails.Enything.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <br />\r\n                        <br />\r\n                        <br />\r\n                    </div>\r\n");
#nullable restore
#line 46 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Shared\Components\GetHelpContext\GetHelpContext.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Common.ResultMessage<Domain.Entities.OtherContext.AdditionalHelp>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591