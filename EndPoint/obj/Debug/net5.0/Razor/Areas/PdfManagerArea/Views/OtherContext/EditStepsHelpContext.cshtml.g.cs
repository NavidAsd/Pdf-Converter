#pragma checksum "D:\C#\Web\Core\PdfConverter_NewView\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\EditStepsHelpContext.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16f6bcbecd8685652ebef9dba799faeedfcdc33f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_PdfManagerArea_Views_OtherContext_EditStepsHelpContext), @"mvc.1.0.view", @"/Areas/PdfManagerArea/Views/OtherContext/EditStepsHelpContext.cshtml")]
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
#line 2 "D:\C#\Web\Core\PdfConverter_NewView\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\EditStepsHelpContext.cshtml"
using Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16f6bcbecd8685652ebef9dba799faeedfcdc33f", @"/Areas/PdfManagerArea/Views/OtherContext/EditStepsHelpContext.cshtml")]
    #nullable restore
    public class Areas_PdfManagerArea_Views_OtherContext_EditStepsHelpContext : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultMessage<Application.Services.Query.ViewContext.ReturnTreeStepHelp.ResultReturnTreeStepHelpDto>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Areas/Admin/css/NoResult.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("shortcut icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("image/png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo/66-modified.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\C#\Web\Core\PdfConverter_NewView\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\EditStepsHelpContext.cshtml"
  
    ViewData["Title"] = "Edit Service";
    Layout = "~/Areas/PdfManagerArea/Views/Shared/_Adminlayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16f6bcbecd8685652ebef9dba799faeedfcdc33f6129", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "16f6bcbecd8685652ebef9dba799faeedfcdc33f6389", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "16f6bcbecd8685652ebef9dba799faeedfcdc33f7565", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    <title>PdfConverter | Admin-Edit Steps Help Context</title>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<style>
    body {
        align-items: center;
        background-color: var(--blue);
        background: url(""/Areas/Admin/images/New_A.jpg"");
        background-attachment: fixed;
        background-position: center;
        background-repeat: no-repeat;
        background-size: cover;
        display: grid;
        height: 100vh;
        place-items: center;
    }
</style>


<section class=""basic-elements"">
    <div class=""row"">
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <div class=""card-title-wrap bar-success"">
                        <h4 class=""card-title mb-0"">Edit ");
#nullable restore
#line 40 "D:\C#\Web\Core\PdfConverter_NewView\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\EditStepsHelpContext.cshtml"
                                                    Write(Model.Enything.Service);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Help Context</h4>
                    </div>
                </div>
                <div class=""card-body"">
                    <div class=""px-3"">
                        <div class=""form"">
                            <div class=""form-body"">
                                <div class=""row"">

                                    <p id=""_Id"" style=""display:none"">");
#nullable restore
#line 49 "D:\C#\Web\Core\PdfConverter_NewView\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\EditStepsHelpContext.cshtml"
                                                                Write(Model.Enything.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

                                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput""> Step1</label>
                                            <textarea id=""Step1"" class=""form-control "" rows=""6"" required>");
#nullable restore
#line 54 "D:\C#\Web\Core\PdfConverter_NewView\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\EditStepsHelpContext.cshtml"
                                                                                                    Write(Model.Enything.Step1);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</textarea>
                                        </fieldset>
                                    </div>

                                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput""> Step2</label>
                                            <textarea id=""Step2"" class=""form-control "" rows=""6"" required>");
#nullable restore
#line 61 "D:\C#\Web\Core\PdfConverter_NewView\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\EditStepsHelpContext.cshtml"
                                                                                                    Write(Model.Enything.Step2);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</textarea>
                                        </fieldset>
                                    </div>

                                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">
                                            <label for=""basicInput""> Step3</label>
                                            <textarea id=""Step3"" class=""form-control "" rows=""6"" required>");
#nullable restore
#line 68 "D:\C#\Web\Core\PdfConverter_NewView\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\EditStepsHelpContext.cshtml"
                                                                                                    Write(Model.Enything.Step3);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</textarea>
                                        </fieldset>
                                    </div>

                                    <hr />

                                    <a class=""btn btn-success col-md-12"" onclick=""EditBasicInfo()""> Save Changes </a>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<script src=""https://code.jquery.com/jquery-1.12.3.min.js""></script>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "16f6bcbecd8685652ebef9dba799faeedfcdc33f14293", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16f6bcbecd8685652ebef9dba799faeedfcdc33f15406", async() => {
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
            WriteLiteral(@"


<script>

    function EditBasicInfo() {
        var Data = {
            ""Step1"": $(""#Step1"").val(),
            ""Step2"": $(""#Step2"").val(),
            ""Step3"": $(""#Step3"").val(),
            ""Id"": document.getElementById(""_Id"").textContent,
        };
        $.ajax({
            contentType: 'application/x-www-form-urlencoded',
            dataType: 'json',
            type: ""POST"",
            url: ""/PdfManagerArea/OtherContext/UpdateThreeStepHelpContext/"",
            data: Data,
            success: function (data) {
                if (data.success == true) {
                    swal.fire(
                        'success',
                        data.message,
                        'success'
                    ).then(function (isConfirm) {
                        location.reload();
                    });
                }
                else {
                    swal.fire(
                        'warning',
                        data.message,
                        'warning'
             ");
            WriteLiteral("       );\n                }\n            },\n            error: function (request, status, error) {\n                alert(request.responseText);\n            }\n        });\n    }\n\n</script>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultMessage<Application.Services.Query.ViewContext.ReturnTreeStepHelp.ResultReturnTreeStepHelpDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
