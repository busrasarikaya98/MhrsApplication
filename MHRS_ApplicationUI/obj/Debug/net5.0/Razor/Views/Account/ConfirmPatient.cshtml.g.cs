#pragma checksum "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Account\ConfirmPatient.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15e43e62159874f8c7c6d86d134890d19ce0e709"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ConfirmPatient), @"mvc.1.0.view", @"/Views/Account/ConfirmPatient.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15e43e62159874f8c7c6d86d134890d19ce0e709", @"/Views/Account/ConfirmPatient.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7267cd1a6616bb9bb3b63a3c594ec24b7add7e60", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_ConfirmPatient : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Account\ConfirmPatient.cshtml"
  
    ViewData["Title"] = "ConfirmPatient";
    Layout = "~/Views/Shared/_LayoutAccountMHRS.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Account\ConfirmPatient.cshtml"
 if (ViewBag.ConfirmPatientError != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <h4 class=\"text-danger\">");
#nullable restore
#line 10 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Account\ConfirmPatient.cshtml"
                           Write(ViewBag.ConfirmPatientError);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    </div>\r\n");
#nullable restore
#line 12 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Account\ConfirmPatient.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
