#pragma checksum "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Home\ReportBug.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b2e52193670cbaa953714fb1024afac19e6b047"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ReportBug), @"mvc.1.0.view", @"/Views/Home/ReportBug.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b2e52193670cbaa953714fb1024afac19e6b047", @"/Views/Home/ReportBug.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3cd8e7a4273f1e7f88356e8b76b3e7d2eb06234", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_ReportBug : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Home\ReportBug.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Header", async() => {
                WriteLiteral("\n    <link rel=\"canonical\"");
                BeginWriteAttribute("href", " href=\"", 202, "\"", 253, 2);
#nullable restore
#line 7 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Home\ReportBug.cshtml"
WriteAttributeValue("", 209, Common.GetPath.GetDomainHttps(), 209, 32, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 241, "/report-bug/", 241, 12, true);
                EndWriteAttribute();
                WriteLiteral(" />\n    ");
#nullable restore
#line 8 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Home\ReportBug.cshtml"
Write(await Component.InvokeAsync("GetMetaTags", "ReportBug"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4b2e52193670cbaa953714fb1024afac19e6b0476997", async() => {
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
                WriteLiteral("\n    <script src=\"https://www.google.com/recaptcha/api.js?hl=en\"></script>\n");
            }
            );
            WriteLiteral(@"
<br />
<br />

<!-- start main -->
<main>
    <br />
    <br />
    <div class=""container"">
        <div class=""section main-rate-page-box"">
            <div class=""main-rate-page-content"">
                <div class=""container"">
                    <div class=""row justify-content-center text-center"">
                        <div class=""col-7 mb-3"">
                            <h1>Report Bug</h1>
                            <p>If you encounter any problems in the program process, thank you for reporting to us to improve performance</p>
                            <p>Also, if you have any questions about how the services work, you can read the <a href=""/questions/"">FAQ</a> first</p>
                        </div>
                    </div>
                    <div class=""row justify-content-center text-start"">
                        <div class=""col-12 col-lg-6"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b2e52193670cbaa953714fb1024afac19e6b0479227", async() => {
                WriteLiteral(@"

                                <div class=""mb-3 mt-3"">
                                    <input type=""email"" class=""form-control"" id=""Emailaddress"" placeholder="" Email Address"">
                                </div>
                                <div class=""mb-3 mt-3"">
                                    <label class=""form-label"" for=""Url""> The address of the page where you found the problem </label>
                                    <input type=""url"" class=""form-control"" id=""Url"" placeholder="" Url"">
                                </div>
                                <div class=""mb-3 mt-3"">
                                    <textarea class=""form-control"" id=""Problem"" rows=""5"" placeholder=""Problem statement""></textarea>
                                </div>
                                <input type=""hidden"" id=""cpth"" style=""display:none"" />
                                <div class=""mb-3 mt-3"">
                                    <div class=""form-group"">
                                     ");
                WriteLiteral(@"   <div class=""col-md-10"">
                                        </div>
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
            WriteLiteral("\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <!-- end home main -->\n    </div>\n</main>\n<br />\n<br />\n\n<!-- end main -->\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n<!-- script -->\n\n<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js\"></script>\n<script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js\"></script>\n<script");
                BeginWriteAttribute("src", " src=\"", 3689, "\"", 3783, 2);
                WriteAttributeValue("", 3695, "https://www.google.com/recaptcha/api.js?render=", 3695, 47, true);
#nullable restore
#line 76 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Home\ReportBug.cshtml"
WriteAttributeValue("", 3742, GoogleCaptchaConfig.Value.Google_SiteKey, 3742, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b2e52193670cbaa953714fb1024afac19e6b04713610", async() => {
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
                WriteLiteral("\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b2e52193670cbaa953714fb1024afac19e6b04714704", async() => {
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
                WriteLiteral("\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b2e52193670cbaa953714fb1024afac19e6b04715798", async() => {
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
                WriteLiteral("\n\n<script>\n    grecaptcha.ready(function () {\n        grecaptcha.execute(\'");
#nullable restore
#line 83 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Views\Home\ReportBug.cshtml"
                       Write(GoogleCaptchaConfig.Value.Google_SiteKey);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { action: 'submit' }).then(function (token) {
            document.getElementById(""cpth"").value = token;
        });
    });
</script>

<script>

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
        Data.append(""Url"", document.getElementById(""Url"").value);
        Data.append(""Problem"", document.getElementById(""Problem"").value);
        Data.append(""Recaptcha"", document.getElementById(""cpth"").value);

        await fetch('/Home/SaveReportedBug/', {
            method: ""POST"",
            body: Data
        })
            .then(response => response.json())
            .then((data) => {
                if (data.success) {
               ");
                WriteLiteral(@"     document.getElementById(""Emailaddress"").value = """";
                    document.getElementById(""Url"").value = """";
                    swal.fire(
                        ""success"",
                        data.message,
                        ""success""
                    ).then(function (isConfirm) {
                        location.reload();
                    });
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
