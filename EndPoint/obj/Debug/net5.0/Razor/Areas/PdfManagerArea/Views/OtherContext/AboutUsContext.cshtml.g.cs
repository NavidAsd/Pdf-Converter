#pragma checksum "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\AboutUsContext.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d4d105fe2a646bff586a4b94b30ebfb6d8c66ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_PdfManagerArea_Views_OtherContext_AboutUsContext), @"mvc.1.0.view", @"/Areas/PdfManagerArea/Views/OtherContext/AboutUsContext.cshtml")]
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
#line 2 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\AboutUsContext.cshtml"
using Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d4d105fe2a646bff586a4b94b30ebfb6d8c66ad", @"/Areas/PdfManagerArea/Views/OtherContext/AboutUsContext.cshtml")]
    #nullable restore
    public class Areas_PdfManagerArea_Views_OtherContext_AboutUsContext : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultMessage<Application.Services.Query.ViewContext.ReturnTermsOfUse.ResultReturnTermsOfUseDto>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("shortcut icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("image/png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo/PDFtoConverterfavicon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\AboutUsContext.cshtml"
  
    ViewData["Title"] = "Edit Service";
    Layout = "~/Areas/PdfManagerArea/Views/Shared/_Adminlayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d4d105fe2a646bff586a4b94b30ebfb6d8c66ad5661", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6d4d105fe2a646bff586a4b94b30ebfb6d8c66ad5921", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    <title>PdfConverter | Admin-About Us</title>\n");
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
    .ck-editor__editable {
        min-height: 300px;
        min-width: 850px;
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
                        <h4 class=""card-title mb-0"">Edit Frequently Question</h4>
");
#nullable restore
#line 32 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\AboutUsContext.cshtml"
                         if (Model.Success == true)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h7 class=\"card-title mb-0\">lastupdate: ");
#nullable restore
#line 34 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\AboutUsContext.cshtml"
                                                               Write(Model.Enything.LastUpdate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h7>\n");
#nullable restore
#line 35 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\AboutUsContext.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p id=\"_Id\" style=\"display:none\">");
#nullable restore
#line 36 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\AboutUsContext.cshtml"
                                                    Write(Model.Enything.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

                    </div>
                </div>
                <hr />

                <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                    <fieldset class=""form-group"">
                        <label>Write Your Context Here</label>

            <textarea name=""editor"" id=""editor"" rows=""10"" cols=""80"">
                ");
#nullable restore
#line 47 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\AboutUsContext.cshtml"
           Write(Html.Raw(Model.Enything.Text));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </textarea>
                    </fieldset>
                </div>


            </div>
            <a class=""btn btn-success col-md-12"" onclick=""SendData()""> Save Changes </a>
        </div>
    </div>
</section>


<script src=""https://code.jquery.com/jquery-1.12.3.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>
<script src=""https://cdn.ckeditor.com/4.19.1/standard/ckeditor.js""></script>


");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6d4d105fe2a646bff586a4b94b30ebfb6d8c66ad10756", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d4d105fe2a646bff586a4b94b30ebfb6d8c66ad11869", async() => {
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
            WriteLiteral(@"


<script>
var Editor = CKEDITOR.replace('editor');
</script>


<script>
    function SendData() {
        var Data = new FormData();
        Data.append(""Id"", document.getElementById(""_Id"").textContent);
        Data.append(""Text"", Editor.getData());

        $.ajax({
            type: ""POST"",
            url: ""/PdfManagerArea/OtherContext/UpdateAboutUsContext/"",
            contentType: false,
            processData: false,
            data: Data,
            success: function (data) {
                if (data.success == true) {

                    swal.fire(
                        'Success',
                        data.message,
                        'success'
                    ).then(function (isConfirm) {
                        location.reload();

                    });
                }
                else {
                    swal.fire(
                        'Warning',
                        data.message,
                        'warning'
                    );
                }
        ");
            WriteLiteral("    },\n            error: function (xhr, ajaxOptions, thrownError) {\n                alert(xhr.status);\n                alert(thrownError);\n            }\n        });\n    }\n\n</script>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultMessage<Application.Services.Query.ViewContext.ReturnTermsOfUse.ResultReturnTermsOfUseDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
