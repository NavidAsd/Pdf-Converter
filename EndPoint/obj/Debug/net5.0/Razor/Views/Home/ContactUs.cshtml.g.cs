#pragma checksum "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Home\ContactUs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37b290ee57bdaa100fc32fb07ec5c10046eb0492"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ContactUs), @"mvc.1.0.view", @"/Views/Home/ContactUs.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37b290ee57bdaa100fc32fb07ec5c10046eb0492", @"/Views/Home/ContactUs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3cd8e7a4273f1e7f88356e8b76b3e7d2eb06234", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_ContactUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("msgform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("javascript:void(0);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Home\ContactUs.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Header", async() => {
                WriteLiteral("\n        <link rel=\"canonical\"");
                BeginWriteAttribute("href", " href=\"", 206, "\"", 257, 2);
#nullable restore
#line 7 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Home\ContactUs.cshtml"
WriteAttributeValue("", 213, Common.GetPath.GetDomainHttps(), 213, 32, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 245, "/contact-us/", 245, 12, true);
                EndWriteAttribute();
                WriteLiteral(" />\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "37b290ee57bdaa100fc32fb07ec5c10046eb04926676", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
#nullable restore
#line 9 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Home\ContactUs.cshtml"
Write(await Component.InvokeAsync("GetMetaTags", "ContactUs"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
            }
            );
            WriteLiteral(@"

    <div class=""section main-rate-page-box"">
        <div class=""main-rate-page-content"">
            <div class=""container"">
                <div class=""row justify-content-center text-start"">
                    <div class=""col-12 col-lg-6"">
                        <br/>
<br/>
<br/>
<br/>
<br/>
<br/>
    
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37b290ee57bdaa100fc32fb07ec5c10046eb04928503", async() => {
                WriteLiteral(@"
                                <h1 class=""text-center"">Contact Us</h1>
                                <p class=""text-center"">This is a non-commercial website.
All services provided are completely free and without obligation.
There is no local version of the converter available. Only this service is offered online.
</p>
                            <div class=""mb-3 mt-3"">
                                <input type=""email"" class=""form-control"" id=""Emailaddress"" placeholder="" Email Address"">
                            </div>
                            <div class=""mb-3 mt-3"">
                                <textarea class=""form-control"" id=""Message"" rows=""5"" placeholder="" Your Message""></textarea>
                            </div>
                            <input type=""hidden"" id=""cpth"" style=""display:none"" />
                            <div class=""mb-3 mt-3"">
                                <div class=""form-group"">
                                    <div class=""col-md-10"">
                            ");
                WriteLiteral(@"        </div>
                                </div>
                            </div>
                                                            <label class=""p-checkbox--inline"">
                                    <input style=""cursor:pointer"" type=""checkbox"" class=""p-checkbox__input"" aria-labelledby=""inlineCheckbox3label"" id=""chbox"">
                                    <span class=""p-checkbox__label"" id=""inlineCheckbox3label"">I’ve read and accepted the <a href=""/terms-of-use"">Terms & Conditions</a> and <a href=""/privacy"">Privacy Policy</a>.</span>
                                </label>                                
                            <button class=""btn btn-outline-primary w-100"" onclick=""SendMessage()"">Send</button>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n\n            <script");
                BeginWriteAttribute("src", " src=\"", 2718, "\"", 2812, 2);
                WriteAttributeValue("", 2724, "https://www.google.com/recaptcha/api.js?render=", 2724, 47, true);
#nullable restore
#line 57 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Home\ContactUs.cshtml"
WriteAttributeValue("", 2771, GoogleCaptchaConfig.Value.Google_SiteKey, 2771, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37b290ee57bdaa100fc32fb07ec5c10046eb049212520", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37b290ee57bdaa100fc32fb07ec5c10046eb049213622", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37b290ee57bdaa100fc32fb07ec5c10046eb049214728", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n\n\n\n                    <script>\n                        grecaptcha.ready(function() {\n                            grecaptcha.execute(\'");
#nullable restore
#line 66 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Home\ContactUs.cshtml"
                                           Write(GoogleCaptchaConfig.Value.Google_SiteKey);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { action: 'submit' }).then(function(token) {
                                document.getElementById(""cpth"").value = token;
                            });
                        });
                    </script>
    <script>
    function CreateNew() {
        grecaptcha.execute('");
#nullable restore
#line 73 "D:\C#\Web\Core\PdfConverter\EndPoint\Views\Home\ContactUs.cshtml"
                       Write(GoogleCaptchaConfig.Value.Google_SiteKey);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { action: 'submit' }).then(function(token) {
            document.getElementById(""cpth"").value = token;
        });
    }

        async function SendMessage() {
                        if (document.getElementById(""chbox"").checked == false) {
                swal.fire(
                    'warning',
                    'Please read and accept the Terms and Conditions and Privacy Policy',
                    'warning'
                );
                return;
            }

        var Data = new FormData();
            Data.append(""Email"", document.getElementById(""Emailaddress"").value);
        Data.append(""Message"", document.getElementById(""Message"").value);
        Data.append(""Recaptcha"", document.getElementById(""cpth"").value);

            await fetch('/Home/SaveUserMessage/', {
            method: ""POST"",
            body: Data
        })
            .then(response => response.json())
            .then((data) => {
                if (data.success) {
                    document.getElementById(""Emaila");
                WriteLiteral(@"ddress"").value = """";
                    swal.fire(
                        ""success"",
                        data.message,
                        ""success""
                    );
                }
                else {
                    swal.fire(
                        ""warning"",
                        data.message,
                        ""warning""
                    );
                }
            })
    }

</script>
");
            }
            );
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
