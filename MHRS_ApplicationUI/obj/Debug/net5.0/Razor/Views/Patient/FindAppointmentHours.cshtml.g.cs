#pragma checksum "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4adad89ff062fbd5a7c0aea523c94ba4d6854c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Patient_FindAppointmentHours), @"mvc.1.0.view", @"/Views/Patient/FindAppointmentHours.cshtml")]
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
#line 1 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\_ViewImports.cshtml"
using MHRS_ApplicationUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\_ViewImports.cshtml"
using MHRS_ApplicationUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\_ViewImports.cshtml"
using MHRS_ApplicationEntityLayer.IdentityModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4adad89ff062fbd5a7c0aea523c94ba4d6854c5", @"/Views/Patient/FindAppointmentHours.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7267cd1a6616bb9bb3b63a3c594ec24b7add7e60", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Patient_FindAppointmentHours : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AvailableDoctorAppointmentViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Patient", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FindAppointment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
  
    ViewData["Title"] = "FindAppointmentHours";
    Layout = "~/Views/Shared/_LayoutMHRS.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div style=""background-color:#ffffff; border-radius:18px;"">
    <div class=""container-fluid"">
        <div class=""row"" style=""border-radius:12px; padding:30px;
min-height: calc(100vh - 300px);"">

            <div class=""col-12"" style=""font-size:20px"">
                <span>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4adad89ff062fbd5a7c0aea523c94ba4d6854c54977", async() => {
                WriteLiteral("\r\n                        <i class=\"fa fa-arrow-left\"\r\n                           style=\"color:black\"></i>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-clinicId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 14 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                               WriteLiteral(TempData["ClinicId"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["clinicId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-clinicId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["clinicId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                                 WriteLiteral(TempData["HospitalId"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["hospitalId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-hospitalId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["hospitalId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    &emsp; Randevu Al\r\n                </span>\r\n            </div>\r\n            <div class=\"row\" style=\"font-size:20px\">\r\n                <span>&ensp;</span>\r\n                <span><b>Hekim: </b>");
#nullable restore
#line 24 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                               Write(ViewBag.Doctor);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
            </div>

            <div class=""m-4"">
                <ul class=""nav nav-tabs"" id=""myTab"" style=""margin-bottom:5px;"">
                    <li class=""nav-item"">
                        <a href=""#day"" class=""nav-link active""
                           data-bs-toggle=""tab""
                           style=""border-bottom:2px solid blue;"">
                            ");
#nullable restore
#line 33 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                       Write(ViewBag.AppointmentDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </a>\r\n                    </li>\r\n                </ul>\r\n\r\n                <div class=\"tab-content\">\r\n                    <div class=\"accordion\" id=\"myAccordion\">\r\n");
#nullable restore
#line 40 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                           byte sayac = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                         foreach (var item in Model)
                        {
                            if (item.Hours.Count == 0)
                            {
                                continue;
                            }


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"accordion-item\">\r\n                                <h2 class=\"accordion-header\"");
            BeginWriteAttribute("id", " id=\"", 2028, "\"", 2048, 2);
            WriteAttributeValue("", 2033, "heading", 2033, 7, true);
#nullable restore
#line 49 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
WriteAttributeValue("", 2040, sayac, 2040, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                    <button style=""height:50px""
                                            type=""button""
                                            class=""accordion-button collapsed""
                                            data-bs-toggle=""collapse""
                                            data-bs-target=""#collapse");
#nullable restore
#line 54 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                                                                 Write(sayac);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                        ");
#nullable restore
#line 55 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                                   Write(item.HourBase);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </button>\r\n                                </h2>\r\n                                <div");
            BeginWriteAttribute("id", " id=\"", 2586, "\"", 2607, 2);
            WriteAttributeValue("", 2591, "collapse", 2591, 8, true);
#nullable restore
#line 58 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
WriteAttributeValue("", 2599, sayac, 2599, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                     class=\"accordion-collapse collapse\"\r\n                                     data-bs-parent=\"#myAccordion\">\r\n                                    <div class=\"card-body\">\r\n");
#nullable restore
#line 62 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                                         foreach (var hourItem in item.Hours)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <button");
            BeginWriteAttribute("onClick", " onClick=\"", 2987, "\"", 3093, 9);
            WriteAttributeValue("", 2997, "SaveAppointment(", 2997, 16, true);
#nullable restore
#line 64 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
WriteAttributeValue("", 3013, item.HospitalClinicId, 3013, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3035, ",\'", 3035, 2, true);
#nullable restore
#line 64 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
WriteAttributeValue("", 3037, ViewBag.AppointmentDate, 3037, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3061, "\',\'", 3061, 3, true);
#nullable restore
#line 64 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
WriteAttributeValue("", 3064, hourItem, 3064, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3073, "\',\'", 3073, 3, true);
#nullable restore
#line 64 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
WriteAttributeValue("", 3076, ViewBag.Doctor, 3076, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3091, "\')", 3091, 2, true);
            EndWriteAttribute();
            WriteLiteral("class=\"btn btn-primary\" style=\"width:100px;\">\r\n                                                ");
#nullable restore
#line 65 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                                           Write(hourItem);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </button>\r\n");
#nullable restore
#line 67 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 71 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\FindAppointmentHours.cshtml"
                            sayac++;
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n\r\n\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>\r\n");
            DefineSection("MhrsScripts", async() => {
                WriteLiteral(@" 
<script type=""text/javascript"">
    function SaveAppointment(hcid, date, hour, dr) {
        Swal.fire({
            title: dr + '\n i??in randevuyu onayl??yor musunuz?',
            showDenyButton: false,
            showCancelButton: false,
            confirmButtonText: 'Onayla',
            cancelButtonText: '??ptal'
        }).then((result) => {
            if (result.isConfirmed) {
                //randevuyu almak istedi??i i??in ajax ile action resulta bilgi g??nderelim, randevu DBye kay??t olsun.
                $.ajax({
                    type: ""GET"",
                    url: '/Patient/SaveAppointment?hcid=' + hcid + '&date=' + date + ""&hour="" + hour,
                    success: function (res) {
                        Swal.fire({
                            title: res.message,
                            showDenyButton: false,
                            showCancelButton: false,
                        }).then((result) => {
                            window.open(""/Patient/Index"",");
                WriteLiteral(" \"_self\");\r\n                        });\r\n                    },\r\n                    error: function (err) {\r\n                        Swal.fire(err, \'\', \'danger\');\r\n                    }\r\n                });\r\n            }\r\n        });\r\n    }\r\n</script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AvailableDoctorAppointmentViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
