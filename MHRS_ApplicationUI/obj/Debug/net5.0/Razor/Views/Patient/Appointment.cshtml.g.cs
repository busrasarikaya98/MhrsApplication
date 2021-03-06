#pragma checksum "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\Appointment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2450ee816f54b6a2b15539cff83a4835b081f5a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Patient_Appointment), @"mvc.1.0.view", @"/Views/Patient/Appointment.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2450ee816f54b6a2b15539cff83a4835b081f5a9", @"/Views/Patient/Appointment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7267cd1a6616bb9bb3b63a3c594ec24b7add7e60", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Patient_Appointment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Patient", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "???", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\Appointment.cshtml"
  
    ViewData["Title"] = "Appointment";
    Layout = "~/Views/Shared/_LayoutMHRS.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n");
            WriteLiteral("</div>\r\n\r\n<div class=\"row\" style=\"background-color:whitesmoke; border-radius:4px; padding:10px;\">\r\n    <div class=\"col-12\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2450ee816f54b6a2b15539cff83a4835b081f5a95622", async() => {
                WriteLiteral(@"
            <div class=""form-group"">
                <span class=""text-danger""
                      style=""font-weight:bold;margin-right:3px;"">*</span>
                <label for=""City"" style=""font-weight:bold;"">??L</label>
                <select id=""CitySelect"" name=""City"" class=""form-control"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2450ee816f54b6a2b15539cff83a4835b081f5a96218", async() => {
                    WriteLiteral("***??l Se??iniz***");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 19 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\Appointment.cshtml"
                     foreach (var item in ViewBag.cities)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2450ee816f54b6a2b15539cff83a4835b081f5a98102", async() => {
#nullable restore
#line 21 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\Appointment.cshtml"
                                            Write(item.CityName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\Appointment.cshtml"
                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\Appointment.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </select>
            </div>

            <div class=""form-group"">
                <span class=""text-danger""
                      style=""font-weight:bold;margin-right:3px;"">*</span>
                <label for=""District"" style=""font-weight:bold;"">??L??E</label>
                <select id=""DistrictSelect"" name=""District"" class=""form-control"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2450ee816f54b6a2b15539cff83a4835b081f5a910669", async() => {
                    WriteLiteral("***??l??e Se??iniz***");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </select>
            </div>

            <div class=""form-group"">
                <span class=""text-danger""
                      style=""font-weight:bold;margin-right:3px;"">*</span>
                <label for=""Clinic"" style=""font-weight:bold;"">KL??N??K</label>
                <select id=""ClinicSelect"" name=""Clinic"" class=""form-control"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2450ee816f54b6a2b15539cff83a4835b081f5a912625", async() => {
                    WriteLiteral("***Klinik Se??iniz***");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 41 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\Appointment.cshtml"
                     foreach (var item in ViewBag.clinics)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2450ee816f54b6a2b15539cff83a4835b081f5a914515", async() => {
#nullable restore
#line 43 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\Appointment.cshtml"
                                            Write(item.ClinicName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\Appointment.cshtml"
                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 44 "C:\Users\303BUSRA_AKSAM\source\repos\MHRS_Application\MHRS_ApplicationUI\Views\Patient\Appointment.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </select>
            </div>

            <div class=""form-group"">
                <span class=""text-danger""
                      style=""font-weight:bold;margin-right:3px;"">*</span>
                <label for=""Hospital"" style=""font-weight:bold;"">HASTANE</label>
                <select id=""HospitalSelect"" name=""Hospital"" class=""form-control"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2450ee816f54b6a2b15539cff83a4835b081f5a917088", async() => {
                    WriteLiteral("***Hastane Se??iniz***");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

                </select>
            </div>

            <div class=""form-group"">
                <span class=""text-danger""
                      style=""font-weight:bold;margin-right:3px;"">*</span>
                <label for=""Doctor"" style=""font-weight:bold;"">DOKTOR</label>
                <select id=""DoctorSelect"" name=""Doctor"" class=""form-control"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2450ee816f54b6a2b15539cff83a4835b081f5a919049", async() => {
                    WriteLiteral("***Doktor Se??iniz***");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

                </select>
            </div>

            <div class=""col-12"">
                <div class=""col-6"" style=""float:left"">
                    <input id=""searchAppointment"" value=""Randevu Ara""
                           class=""btn btn-block btn-default""
                           type=""button""
                           style=""background-color:white;color:red;border:1px solid red"" />
                </div>

                <div class=""col-6"" style=""float:right"">
                    <input id=""clearBtn"" value=""Temizle""
                           class=""btn btn-block btn-default""
                           type=""button""
                           style=""background-color:red;color:white;"" />
                </div>
            </div>

        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n");
            DefineSection("MhrsScripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            //sayfa a????ld??????nda il??e hastane doktor ve randevu ara pasif halde olacakt??r
            $('#DistrictSelect').attr(""disabled"", true);
            $('#HospitalSelect').attr(""disabled"", true);
            $('#DoctorSelect').attr(""disabled"", true);
            $('#searchAppointment').attr(""disabled"", true);
            //document.getElementById(""searchAppointment"")
        });
        //CitySelectten il se??ildi??inde bu fonksiyon ??al????s??n
        //change event??n ad??d??r
        $('#CitySelect').on('change', function () {
            //il??e combosu temizlensin
            var $district = $('#DistrictSelect');
            $district.empty();
            $district.append(""<option selected value='0'>***??l??e Se??iniz***</option>"");
            //hastane combosu temizlensin
            var $hospital = $('#HospitalSelect');
            //$('#HospitalSelect').empty();
            $hospital.empty();
            $hospital.append(""<option s");
                WriteLiteral(@"elected value='0'>***Hastane Se??iniz***</option>"");
            //doktor combosu temizlensin
            var $doctor = $('#DoctorSelect');
            $doctor.empty();
            $doctor.append(""<option selected value='0'>***Doktor Se??iniz***</option>"");
            //il de??i??ti??inde klinik combosunda klinik se??iniz optionu aktif olsun
            $('#ClinicSelect').val(0).trigger('change');
            //hangi ili se??ti??ini tutal??m
            //this CitySelect idsine sahip elementi yani il combosunu temsil eder.
            var cityId = this.value; //istanbulun idsi gelecek
            //il combosundan se??ilen de??er s??f??rdan b??y??kse
            //a??a????daki ajax arac??l??????yla se??ili ile ait il??eleri getirip il??e combosunun i??ine eklesin
            if (cityId > 0) {
                $.ajax({
                    type: ""GET"",
                    url: '/City/GetCityDistricts/' + cityId,
                    success: function (response) {
                        //e??er ba??ar??l?? bir d??n???? olursa
 ");
                WriteLiteral(@"                       //gelen json datay?? il??e combosuna ekleyece??iz
                        $(""#DistrictSelect"").attr(""disabled"", false);
                        $(""#DistrictSelect"").empty();
                        $(""#DistrictSelect"").append(""<option selected value='0'>***FARKETMEZ***</option>"");
                        //response ile json gelen datay?? d??ng?? ile tek tek d??nelim
                        $.each(response.data, function () {
                            $(""#DistrictSelect"")
                                .append($(""<option />"").val(this.id).text(this.districtName));
                        });
                    },
                    error: function (err) {
                        console.log(err);
                        alert(err);
                        $(""#DistrictSelect"").empty();
                        $(""#DistrictSelect"").append(""<option selected value='0'>***??l??e Se??iniz***</option>"");
                        $(""#DistrictSelect"").attr(""disabled"", true);
            ");
                WriteLiteral(@"        }
                });
            }
        });
        //il??e combosunda il??e se??ilirse bu fonksiyon ??al????acak
        $(""#DistrictSelect"").on(""change"", function () {
            // hastane combosu temizlensin
            $(""#HospitalSelect"").empty();
            $(""#HospitalSelect"").append(""<option selected value='0'>***Hastane Se??iniz***</option>"");
            //doktor combosu temizlensin
            $(""#DoctorSelect"").empty();
            $(""#DoctorSelect"").append(""<option selected value='0'>***Doktor Se??iniz***</option>"");
            //klinik combosunda Klinik Se??iniz se??ili olarak gelsin
            $(""#ClinicSelect"").val(0).trigger(""change"");
        });
        ////klinik combosundan bir klinik se??ilirse
        $(""#ClinicSelect"").on(""change"", function () {
            // hastane combosu temizlensin
            $(""#HospitalSelect"").empty();
            $(""#HospitalSelect"").append(""<option selected value='0'>***Hastane Se??iniz***</option>"");
            //doktor combosu te");
                WriteLiteral(@"mizlensin
            $(""#DoctorSelect"").empty();
            $(""#DoctorSelect"").append(""<option selected value='0'>***Doktor Se??iniz***</option>"");
            //hangi il??e se??ilmi?? bunu bir de??i??kene alal??m
            var districtId = $(""#DistrictSelect"").val(); //Kad??k??y --> id:500
            var clinicId = this.value; // KBB--> id:12
            if (clinicId > 0) {
                $.ajax({
                    type: ""GET"",
                    url: '/Hospital/GetHospitalsByClinicIdandDistrictId?clinicId=' + clinicId + '&districtId=' + districtId,
                    success: function (response) {
                        $(""#HospitalSelect"").attr(""disabled"", false);
                        $(""#HospitalSelect"").empty();
                        $(""#HospitalSelect"").append(""<option selected value='0'>***FARKETMEZ***</option>"");
                        //jquery foreach d??ng??s??
                        $.each(response.data, function () {
                            $(""#HospitalSelect"").append($(""");
                WriteLiteral(@"<option />"").val(this.id).text(this.hospitalName));
                        });
                    },
                    error: function (err) {
                        alert(err);
                        console.log(err);
                        $(""#HospitalSelect"").empty();
                        $(""#HospitalSelect"").append(""<option selected value='0'>***Hastane Se??iniz***</option>"");
                        $(""#HospitalSelect"").attr(""disabled"", true);
                    }
                });
            }
            if ($(""#CitySelect"").val() > 0 && $(""#ClinicSelect"").val() > 0) {
                //il ve klinik se??ili ise randevu ara butonu aktifle??sin
                $(""#searchAppointment"").attr(""disabled"", false);
            }
        });
        //Hastane combosundan bir hastane se??ilirse bu fonksiyon ??al????s??n
        $(""#HospitalSelect"").on(""change"", function () {
            //doktor combosu temizlensin
            $(""#DoctorSelect"").empty();
            $(""#DoctorSelect"").a");
                WriteLiteral(@"ppend(""<option selected value='0'>***Doktor Se??iniz***</option>"");
            //hangi klinik ve hangi hastane se??ilmi??
            var clinicId = $(""#ClinicSelect"").val();
            var hospitalId = $(""#HospitalSelect"").val();
            if (hospitalId > 0) {
                $.ajax({
                    type: ""GET"",
                    url: '/Hospital/GetDoctorsByHospitalClinicData?clinicId=' +
                        clinicId + ""&hospitalId="" + hospitalId,
                    success: function (response) {
                        $(""#DoctorSelect"").empty();
                        $(""#DoctorSelect"").attr(""disabled"", false);
                        $(""#DoctorSelect"").append(""<option selected value='0' data-userid=''>***FARKETMEZ***</option>"");
                        $.each(response.data, function () {
                            var option = ""<option data-userid='"" + this.id + ""'  value='"" + this.id + ""'> "" + this.name + "" "" + this.surname + ""</option>"";
                            $(""#Doc");
                WriteLiteral(@"torSelect"").append(option);
                        });
                    },
                    error: function (err) {
                        console.log(err);
                        alert(err);
                        $(""#DoctorSelect"").empty();
                        $(""#DoctorSelect"").append(""<option selected value='0' data-userid=''>***Doktor Se??iniz***</option>"");
                        $(""#DoctorSelect"").attr(""disabled"", true);
                    }
                });
            }
        });
        //randevu ara butonuna t??klan??ld??????nda se??ili de??erlere g??re arama yap??ls??n
        $(""#searchAppointment"").on('click', function () {
            //se??ili il
            var cityId = $(""#CitySelect"").val();
            //se??ili il??e
            var districtId = $(""#DistrictSelect"").val();
            //se??ili klinik
            var clinicId = $(""#ClinicSelect"").val();
            //se??ili hsatane
            var hospitalId = $(""#HospitalSelect"").val();
            //se??ili d");
                WriteLiteral(@"oktor
            var doctorId = $(""#DoctorSelect"").find(':selected').attr('data-userid');
            window.open('/Patient/FindAppointment?cityId=' + cityId
                + ""&districtId="" + districtId + ""&clinicId="" + clinicId
                + ""&hospitalId="" + hospitalId + ""&doctorId="" + doctorId, ""_self"");
        });
        //temizle butonu
        $(""#clearBtn"").on('click', function () {
            //iller combosunda il se??iniz se??ili hale gelince
            // di??erleri de resetlenecek
            //????nk?? hepsi birbirine ba??l??
            $(""#CitySelect"").val(0).trigger('change');
        });
    </script>


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
