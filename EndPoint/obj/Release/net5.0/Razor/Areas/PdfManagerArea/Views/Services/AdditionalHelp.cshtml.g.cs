#pragma checksum "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2766e2aa6f840d46d26adfad348346d1ef075c64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_PdfManagerArea_Views_Services_AdditionalHelp), @"mvc.1.0.view", @"/Areas/PdfManagerArea/Views/Services/AdditionalHelp.cshtml")]
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
#line 2 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
using Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
using Application.Services.Query.GetAllFeaturesDetails;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2766e2aa6f840d46d26adfad348346d1ef075c64", @"/Areas/PdfManagerArea/Views/Services/AdditionalHelp.cshtml")]
    #nullable restore
    public class Areas_PdfManagerArea_Views_Services_AdditionalHelp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultMessage<List<Domain.Entities.OtherContext.AdditionalHelp>>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Areas/Admin/css/NoResult.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("shortcut icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("image/png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo/66-modified.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Areas/Admin/images/microsoft_todo_2019_240px.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("40"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("cursor:pointer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Click To Disabled Service"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Areas/Admin/images/delete_240px.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Click To Enabled Service"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
  
    Layout = "~/Areas/PdfManagerArea/Views/Shared/_Adminlayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2766e2aa6f840d46d26adfad348346d1ef075c648395", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2766e2aa6f840d46d26adfad348346d1ef075c648655", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2766e2aa6f840d46d26adfad348346d1ef075c649831", async() => {
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
                WriteLiteral("\n    <title>PdfConverter | Admin-AdditionalHelps</title>\n");
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



<div class=""content-wrapper"">
    <div class=""container-fluid"">
        <!-- Zero configuration table -->
        <section id=""configuration"">

            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <p>
                            <br />
                            <br />
                        </p>
                        <table class=""table table-striped"">
                            <thead>
                                <tr>
                                    <th></th>

                                    <th>
                                        ");
            WriteLiteral(@"ServiceName
                                    </th>
                                    <th>
                                        Title
                                    </th>
                                    <th>
                                        LastUpdate
                                    </th>
                                    <th>
                                        State
                                    </th>

                                    <th></th>
                                </tr>
                            </thead>

                            <tbody>
");
#nullable restore
#line 68 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
                                 foreach (var item in Model.Enything)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\n                                        <td></td>\n                                        <td>\n                                            ");
#nullable restore
#line 73 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
                                       Write(item.Service);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
#nullable restore
#line 76 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
                                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
#nullable restore
#line 79 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
                                       Write(item.LastUpdate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n\n");
#nullable restore
#line 82 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
                                         if (item.IsRemoved == false)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2766e2aa6f840d46d26adfad348346d1ef075c6415640", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3066, "ChangeState(\'", 3066, 13, true);
#nullable restore
#line 85 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
AddHtmlAttributeValue("", 3079, item.Id, 3079, 8, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 3087, "\',", 3087, 2, true);
            AddHtmlAttributeValue(" ", 3089, "true)", 3090, 6, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                            </td>\n");
#nullable restore
#line 87 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2766e2aa6f840d46d26adfad348346d1ef075c6418121", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3501, "ChangeState(\'", 3501, 13, true);
#nullable restore
#line 91 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
AddHtmlAttributeValue("", 3514, item.Id, 3514, 8, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 3522, "\',false)", 3522, 8, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                            </td>\n");
#nullable restore
#line 93 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        <td>\n                                            <a style=\"color:blue\"");
            BeginWriteAttribute("href", " href=\"", 3738, "\"", 3800, 2);
            WriteAttributeValue("", 3745, "/PdfManagerArea/Services/EditAdditionalHelp?Id=", 3745, 47, true);
#nullable restore
#line 96 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
WriteAttributeValue("", 3792, item.Id, 3792, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>|\n                                            <a style=\"color:blue\"");
            BeginWriteAttribute("href", " href=\"", 3877, "\"", 3937, 3);
            WriteAttributeValue("", 3884, "/PdfManagerArea/Services/EditBlock?Id=", 3884, 38, true);
#nullable restore
#line 97 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
WriteAttributeValue("", 3922, item.Id, 3922, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3930, "&Type=1", 3930, 7, true);
            EndWriteAttribute();
            WriteLiteral(">left </a>|\n                                            <a style=\"color:blue\"");
            BeginWriteAttribute("href", " href=\"", 4015, "\"", 4075, 3);
            WriteAttributeValue("", 4022, "/PdfManagerArea/Services/EditBlock?Id=", 4022, 38, true);
#nullable restore
#line 98 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
WriteAttributeValue("", 4060, item.Id, 4060, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4068, "&Type=2", 4068, 7, true);
            EndWriteAttribute();
            WriteLiteral(">center </a>|\n                                            <a style=\"color:blue\"");
            BeginWriteAttribute("href", " href=\"", 4155, "\"", 4215, 3);
            WriteAttributeValue("", 4162, "/PdfManagerArea/Services/EditBlock?Id=", 4162, 38, true);
#nullable restore
#line 99 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
WriteAttributeValue("", 4200, item.Id, 4200, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4208, "&Type=3", 4208, 7, true);
            EndWriteAttribute();
            WriteLiteral(">right </a>\n                                        </td>\n\n                                    </tr>\n");
#nullable restore
#line 103 "C:\Users\Mr.Win\Downloads\ps-pepo-master\EndPoint\Areas\PdfManagerArea\Views\Services\AdditionalHelp.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\n                        </table>\n                    </div>\n                </div>\n            </div>\n        </section>\n    </div>\n</div>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2766e2aa6f840d46d26adfad348346d1ef075c6423426", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2766e2aa6f840d46d26adfad348346d1ef075c6424540", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>

    function ChangeState(Id, State) {

        var postdata = {
            'Id': Id,
            'State': State
        };
        $.ajax({
            contentType: 'application/x-www-form-urlencoded',
            dataType: 'json',
            type: ""POST"",
            url: ""/PdfManagerArea/Services/ChangeStatusAdditional/"",
            data: postdata,
            success: function(data) {
                if (data.success == true) {
                    location.reload();
                }
                else {
                    swal.fire(
                        'warning',
                        data.message,
                        'warning'
                    );
                }
            },
            error: function(request, status, error) {
                alert(request.responseText);
            }

        });


    }



    function ShowModal(Message) {
        document.getElementById(""areaContext"").value = Message;
        $(""#mdlContext"").modal('show');
    }

    function OpenI");
            WriteLiteral("mageModal(src, name) {\n        document.getElementById(\'_id\').textContent = name;\n        document.getElementById(\'image\').src = src;\n        $(\"#EditImage\").modal(\'show\');\n    }\n\n</script>\n\n");
            DefineSection("Modals", async() => {
                WriteLiteral(@"
    <!-- Modal Context -->
    <div class=""modal fade"" id=""mdlContext"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLongTitle"">Context</h5>
                </div>

                <div class=""modal-body"">
                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                        <form>
                            <fieldset class=""form-group"">
                                <textarea id=""areaContext"" class=""form-control "" rows=""5"" readonly> None </textarea>
                            </fieldset>
                        </form>
                    </div>
                </div>
                <div class=""modal-footer"">
                </div>
            </div>
        </div>
    </div>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultMessage<List<Domain.Entities.OtherContext.AdditionalHelp>>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
