#pragma checksum "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88df095367d74cc3d0fe63e08148b05f03584e2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Karyawan_Index), @"mvc.1.0.view", @"/Views/Karyawan/Index.cshtml")]
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
#line 1 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\_ViewImports.cshtml"
using EmployeeApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\_ViewImports.cshtml"
using EmployeeApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88df095367d74cc3d0fe63e08148b05f03584e2d", @"/Views/Karyawan/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f82655e463f87e91c1d4f9696068e4817f27c41", @"/Views/_ViewImports.cshtml")]
    public class Views_Karyawan_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EmployeeApp.Models.Karyawan>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
  
    ViewData["Title"] = "Manage Karyawan";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Manage Karyawan</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88df095367d74cc3d0fe63e08148b05f03584e2d3809", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nama));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NIK));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Jenis_Kelamin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Tanggal_Lahir));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Alamat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nomor_Telp));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Nama Divisi\r\n            </th>\r\n            <th>Action</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 43 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nama));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NIK));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Jenis_Kelamin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(item.Tanggal_Lahir.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Alamat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 64 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nomor_Telp));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 67 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Divisi.Nama));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 70 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 71 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 72 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 75 "D:\belajar\C#\pertemuan 8 - asp.net core mvc perkenalan\EmployeeApp\EmployeeApp\Views\Karyawan\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EmployeeApp.Models.Karyawan>> Html { get; private set; }
    }
}
#pragma warning restore 1591
