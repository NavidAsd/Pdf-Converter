#pragma checksum "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Shared\Components\GetRatingPart\GetRatingPart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2be441ae27d4cb2566150c3afd9524e45d7feabb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_GetRatingPart_GetRatingPart), @"mvc.1.0.view", @"/Views/Shared/Components/GetRatingPart/GetRatingPart.cshtml")]
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
#line 1 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\_ViewImports.cshtml"
using EndPoint;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\_ViewImports.cshtml"
using EndPoint.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2be441ae27d4cb2566150c3afd9524e45d7feabb", @"/Views/Shared/Components/GetRatingPart/GetRatingPart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3cd8e7a4273f1e7f88356e8b76b3e7d2eb06234", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_GetRatingPart_GetRatingPart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("msgform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("javascript:void(0);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Shared\Components\GetRatingPart\GetRatingPart.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<footer>
    <div class=""section main-rate-page-box"">
        <div class=""main-rate-page-content"">
            <div class=""container"">
                <div class=""row justify-content-center text-center"">
                    <div class=""col-12"">
                        <div class=""rating"" onclick=""CreateNew()"">
                            <span><strong class=""me-3"">Rate this tool</strong></span>
                            <i class=""rating__star bi bi-star"" data-bs-toggle=""tooltip"" data-bs-placement=""top"" title=""Awful"" data-bs-original-title=""Awful"" aria-label=""Awful""></i>
                            <i class=""rating__star bi bi-star"" data-bs-toggle=""tooltip"" data-bs-placement=""top"" title=""Poor"" data-bs-original-title=""Poor"" aria-label=""Poor""></i>
                            <i class=""rating__star bi bi-star"" data-bs-toggle=""tooltip"" data-bs-placement=""top"" title=""Average"" data-bs-original-title=""Average"" aria-label=""Average""></i>
                            <i class=""rating__star bi bi-star"" data-bs-toggle=""");
            WriteLiteral(@"tooltip"" data-bs-placement=""top"" title=""Good"" data-bs-original-title=""Good"" aria-label=""Good""></i>
                            <i class=""rating__star bi bi-star"" data-bs-toggle=""tooltip"" data-bs-placement=""top"" title=""Excellent"" data-bs-original-title=""Excellent"" aria-label=""Excellent""></i>
                            <span><strong class=""ms-3"">");
#nullable restore
#line 19 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Shared\Components\GetRatingPart\GetRatingPart.cshtml"
                                                  Write(Model.Enything.Rate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> / 5  -  ");
#nullable restore
#line 19 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Shared\Components\GetRatingPart\GetRatingPart.cshtml"
                                                                                        Write(Model.Enything.CountUse);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Total Convert</span>\n                        </div>\n                    </div>\n                </div>\n                <div class=\"row justify-content-center text-start\">\n                    <div class=\"col-12 col-lg-6\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2be441ae27d4cb2566150c3afd9524e45d7feabb6646", async() => {
                WriteLiteral(@"
                            <div class=""mb-3 mt-3"">
                                <input type=""text"" class=""form-control"" id=""FullName"" placeholder="" Full Name"">
                            </div>
                            <div class=""mb-3 mt-3"">
                                <input type=""email"" class=""form-control"" id=""Emailaddress"" placeholder="" Email Address"">
                            </div>
                            <div class=""mb-3 mt-3"">
                                <textarea class=""form-control"" id=""Message"" rows=""3"" placeholder="" Your Message""></textarea>
                            </div>
                            <input type=""hidden"" id=""cpth"" style=""display:none"" />
                            <div class=""mb-3 mt-3"">
                                <div class=""form-group"">
                                    <div class=""col-md-10"">
                                    </div>
                                </div>
                            </div>
                            <button");
                WriteLiteral(" class=\"btn btn-outline-primary w-100\" onclick=\"SendMessage()\">Send</button>\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</footer>\n\n\n<script>\n    function CreateNew() {\n        grecaptcha.execute(\'");
#nullable restore
#line 54 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Shared\Components\GetRatingPart\GetRatingPart.cshtml"
                       Write(GoogleCaptchaConfig.Value.Google_SiteKey);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', { action: \'submit\' }).then(function(token) {\n            document.getElementById(\"cpth\").value = token;\n        });\n\n    }\n</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.Extensions.Options.IOptions<EndPoint.Models.GoogleCaptchaConfigModel> GoogleCaptchaConfig { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
