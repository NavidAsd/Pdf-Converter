#pragma checksum "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2b97dfe009c8ea0a48e9b6d9aa532c17bfbf106"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_PdfManagerArea_Views_OtherContext_HomeContext), @"mvc.1.0.view", @"/Areas/PdfManagerArea/Views/OtherContext/HomeContext.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2b97dfe009c8ea0a48e9b6d9aa532c17bfbf106", @"/Areas/PdfManagerArea/Views/OtherContext/HomeContext.cshtml")]
    #nullable restore
    public class Areas_PdfManagerArea_Views_OtherContext_HomeContext : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Common.ResultMessage<Application.Services.Query.ViewContext.ReturnHomeContext.ResultReturnHomeContextDto>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("shortcut icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("image/png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo/66-modified.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
  
    Layout = "~/Areas/PdfManagerArea/Views/Shared/_Adminlayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2b97dfe009c8ea0a48e9b6d9aa532c17bfbf1065408", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e2b97dfe009c8ea0a48e9b6d9aa532c17bfbf1065668", async() => {
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
                WriteLiteral("\n    <title>PdfConverter | Admin-HomeContext</title>\n");
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
            WriteLiteral("\n\n\n");
#nullable restore
#line 13 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
  
    string[] context = new string[] { Model.Enything.TopTitleText, Model.Enything.MainServicesPText, Model.Enything.ServicesInfoPText, Model.Enything.MainServicesH2Text, Model.Enything.ServicesInfoH1Text };

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
  
    string[] part = new string[] { "TopTitleText", "MainServicesDownText", "ServicesInfoDownText", "MainServicesTopText", "ServicesInfoTopText" };

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
  
    string[] nameoff = new string[] { nameof(Model.Enything.TopTitleText), nameof(Model.Enything.MainServicesPText), nameof(Model.Enything.ServicesInfoPText), nameof(Model.Enything.MainServicesH2Text), nameof(Model.Enything.ServicesInfoH1Text) };

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<div class=\"content-wrapper\">\n    <div class=\"container-fluid\">\n        <!-- Zero configuration table -->\n        <section id=\"configuration\">\n            <p id=\"_Id\" style=\"display:none\">");
#nullable restore
#line 28 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                        Write(Model.Enything.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
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
                                    <th>
                                        Part
                                    </th>
                                    <th>
                                        Context
                                    </th>
                                    <th>
                                        State
                                    </th>
                                    <th>
                                        LastUpdate
                                    </th>

                                    <th></th>
                                </tr>
                            </thead>

        ");
            WriteLiteral("                    <tbody>\n\n");
#nullable restore
#line 58 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                 for (int i = 0; i < part.Length; i++)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\n                                        <td");
            BeginWriteAttribute("id", " id=\"", 2412, "\"", 2420, 2);
            WriteAttributeValue("", 2417, "_", 2417, 1, true);
#nullable restore
#line 61 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
WriteAttributeValue("", 2418, i, 2418, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                            ");
#nullable restore
#line 62 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                       Write(part[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n");
#nullable restore
#line 65 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                             if (!string.IsNullOrWhiteSpace(context[i]))
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                                 if (context[i].Length > 12)
                                                {
                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                                Write(context[i].Substring(0, context[i].Length / 2).ToString() + "...");

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                                                                                                        
                                                    ;
                                                }
                                                else
                                                {
                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                               Write(context[i]);

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                                               
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                                 
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\n                                        <td>\n                                            True\n                                        </td>\n");
#nullable restore
#line 81 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                         if (Model.Success == true)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\n                                                ");
#nullable restore
#line 84 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                           Write(Model.Enything.LastUpdate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                            </td>\n");
#nullable restore
#line 86 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td></td>\n");
#nullable restore
#line 90 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>\n                                            <a style=\"color:blue\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4122, "\"", 4197, 7);
            WriteAttributeValue("", 4132, "OpenModal(\'", 4132, 11, true);
#nullable restore
#line 92 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
WriteAttributeValue("", 4143, part[i], 4143, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4151, "\',\'", 4151, 3, true);
#nullable restore
#line 92 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
WriteAttributeValue("", 4154, context[i].Replace("'",""), 4154, 27, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4181, "\',\'", 4181, 3, true);
#nullable restore
#line 92 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
WriteAttributeValue("", 4184, nameoff[i], 4184, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4195, "\')", 4195, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\n                                        </td>\n");
#nullable restore
#line 94 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                         if (i == 1 || i == 2)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\n");
#nullable restore
#line 97 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                                 if (i == 1)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <a style=\"color:blue\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4592, "\"", 4707, 7);
            WriteAttributeValue("", 4602, "OpenImageModal(\'", 4602, 16, true);
#nullable restore
#line 99 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
WriteAttributeValue("", 4618, Common.GetPath.GetHomeImages().Replace("wwwroot",""), 4618, 53, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4671, "/", 4671, 1, true);
#nullable restore
#line 99 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
WriteAttributeValue("", 4672, Common.GetPath.HomeTopImage, 4672, 28, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4700, "\',\'", 4700, 3, true);
#nullable restore
#line 99 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
WriteAttributeValue("", 4703, i, 4703, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4705, "\')", 4705, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Image</a>\n");
#nullable restore
#line 100 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <a style=\"color:blue\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4945, "\"", 5061, 7);
            WriteAttributeValue("", 4955, "OpenImageModal(\'", 4955, 16, true);
#nullable restore
#line 103 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
WriteAttributeValue("", 4971, Common.GetPath.GetHomeImages().Replace("wwwroot",""), 4971, 53, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5024, "/", 5024, 1, true);
#nullable restore
#line 103 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
WriteAttributeValue("", 5025, Common.GetPath.HomeDownImage, 5025, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5054, "\',\'", 5054, 3, true);
#nullable restore
#line 103 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
WriteAttributeValue("", 5057, i, 5057, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5059, "\')", 5059, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Image</a>\n");
#nullable restore
#line 104 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\n");
#nullable restore
#line 106 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tr>\n");
#nullable restore
#line 108 "D:\C#\Web\Core\PdfConverter\EndPoint\Areas\PdfManagerArea\Views\OtherContext\HomeContext.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </section>
    </div>
</div>

<script src=""https://code.jquery.com/jquery-1.12.3.min.js""></script>
<!---
<script src=""//cdn.ckeditor.com/4.5.9/standard/ckeditor.js""></script>
<script src=""//cdnjs.cloudflare.com/ajax/libs/ckeditor/4.5.9/adapters/jquery.js""></script>
    -->

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e2b97dfe009c8ea0a48e9b6d9aa532c17bfbf10621873", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2b97dfe009c8ea0a48e9b6d9aa532c17bfbf10622986", async() => {
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
    function SendData() {
        var Data = new FormData();
        Data.append(""Id"", document.getElementById(""_Id"").textContent);

        Data.append(document.getElementById('nameofModalLongTitle').textContent, $(""#normaltextArea"").val());
        $.ajax({
            type: ""POST"",
            url: ""/PdfManagerArea/OtherContext/UpdateHomeContext/"",
            contentType: false,
            processData: false,
            data: Data,
            success: function(data) {
                if (data.success == true) {

                    swal.fire(
                        'Success',
                        data.message,
                        'success'
                    ).then(function(isConfirm) {
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
            }");
            WriteLiteral(@",
            error: function(xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }

        });
    }

    function UpdateImage() {
        var ImageFilter = /(\.webp|\.png|\.)$/i;
        if (!ImageFilter.exec(document.getElementById(""upload"").value)) {
            swal.fire
                (
                    ""warning"",
                    ""Just .webp,.png File Format Valid"",
                    ""warning""
                );
            return;
        }

        var formData = new FormData();
        formData.append(""Image"", document.getElementById(""upload"").files[0]);
        formData.append(""Id"", document.getElementById(""_id"").textContent);

        $.ajax({
            type: ""POST"",
            url: ""/PdfManagerArea/OtherContext/UpdateHomeImage/"",
            contentType: false,
            processData: false,
            data: formData,
            success: function(data) {
                if (data.success == true) {
                    ");
            WriteLiteral(@"swal.fire(
                        'Success',
                        data.message,
                        'success'
                    ).then(function(isConfirm) {
                        location.reload();
                    });
                }
                else {
                    swal.fire(
                        'warning',
                        data.message,
                        'warning'
                    );
                }

            },
            error: function(xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }

        });
    }

    function OpenModal(part, context, nameof, type) {
        document.getElementById('nameofModalLongTitle').textContent = nameof;
        document.getElementById('NexampleModalLongTitle').textContent = part;
        $(""#normaltextArea"").val(context);
        $(""#normalmdlContext"").modal('show');
    }

    function OpenImageModal(src, id) {
        document.getElementById('_id').text");
            WriteLiteral(@"Content = id;
        document.getElementById('image').src = src;
        $(""#EditImage"").modal('show');
    }

    function changePicture() {
        $('#upload').click();
    }

    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function(e) {
                $('#image')
                    .attr('src', e.target.result);

            };
            reader.readAsDataURL(input.files[0]);
        }
    }

</script>

");
            DefineSection("ImageModals", async() => {
                WriteLiteral(@"
    <!-- Modal Edit Image -->
    <div class=""modal fade"" id=""EditImage"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLongTitle"">Edit Image</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">

                        <div id=""userphoto"">
                            <div class=""change-picture-slide"" style=""top: 30px;"">
                                <p style=""display:none"" id=""_id""></p>
                                <input accept=""image/*"" type=""file"" id=""upload"" name=""upload"" o");
                WriteLiteral("nchange=\"readURL(this);\" style=\"visibility: hidden;\" />\n                                <img id=\"image\"");
                BeginWriteAttribute("src", " src=\"", 10575, "\"", 10581, 0);
                EndWriteAttribute();
                WriteLiteral(" alt=\"Img\" class=\"logo\" width=\"185\" />\n                                <i class=\"fa fa-search\">\n                                    <label");
                BeginWriteAttribute("href", " href=\"", 10720, "\"", 10727, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""btn"" for=""files"" onclick=""changePicture(); return false"">Chosse Image</label>
                                </i>
                            </div>
                        </div>

                        <div class=""modal-footer"">
                            <a class=""btn btn-secondary"" data-dismiss=""modal"">Close</a>
                            <button class=""btn btn-primary"" onclick=""UpdateImage()"" type=""submit"">Edit</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            WriteLiteral("\n\n");
            DefineSection("Other", async() => {
                WriteLiteral(@"
    <!-- Modal Context -->
    <div class=""modal fade"" id=""normalmdlContext"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""NexampleModalLongTitle""></h5>
                    <p class=""modal-title"" id=""nameofModalLongTitle"" style=""display:none""></p>
                </div>

                <div class=""modal-body"">
                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                        <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                            <form>
                                <fieldset class=""form-group"">
                                    <textarea rows=""7"" cols=""45"" id=""normaltextArea""></textarea>
                                </fieldset>
                            </form>
                        </div>
               ");
                WriteLiteral(@"     </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-success"" onclick=""SendData()"">Save Changes</button>
                        <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Close</button>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Common.ResultMessage<Application.Services.Query.ViewContext.ReturnHomeContext.ResultReturnHomeContextDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
