#pragma checksum "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\Home\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28726a55a78c2e51489e4a4d5244dfb06990d2ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_List), @"mvc.1.0.view", @"/Views/Home/List.cshtml")]
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
#line 2 "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\_ViewImports.cshtml"
using myfirstnetcoreapp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28726a55a78c2e51489e4a4d5244dfb06990d2ca", @"/Views/Home/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e978fcb7783270fa35d09a297d7ac852b0cba93", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<myfirstnetcoreapp.Models.Employee>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\Home\List.cshtml"
  

    ViewBag.Title = "Employee List";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table style=""border:2px solid black; font-family:Arial; "">
    <thead>
        <tr>
            <th>Employee Name</th>
            <th>Email</th>
            <th>Department</th>
            <th>FilePath</th>
            <th></th>
            <th></th>
        </tr>

    </thead>
");
#nullable restore
#line 21 "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\Home\List.cshtml"
     foreach (var emp in Model)
    {
        var filepath = "/images/" + (emp.FilePath ?? "car.png");

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tbody>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 26 "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\Home\List.cshtml"
               Write(emp.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\Home\List.cshtml"
               Write(emp.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\Home\List.cshtml"
               Write(emp.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><img");
            BeginWriteAttribute("src", " src=\"", 681, "\"", 696, 1);
#nullable restore
#line 29 "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\Home\List.cshtml"
WriteAttributeValue("", 687, filepath, 687, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"image\" style=\"width:75px;height:60px\" /></td>\r\n                <td> ");
#nullable restore
#line 30 "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\Home\List.cshtml"
                Write(Html.ActionLink("Edit", "Edit", new { Id = emp.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td> ");
#nullable restore
#line 31 "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\Home\List.cshtml"
                Write(Html.ActionLink("View", "Details", new { Id = emp.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n\r\n\r\n        </tbody>\r\n");
#nullable restore
#line 36 "C:\Projects\AspnetCore\myfirstnetcoreapp\myfirstnetcoreapp\Views\Home\List.cshtml"
       
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n  \r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n    <!--<img src=\"~/Images/car2.jfif\" alt=\"car\" asp-append-version=\"true\" />-->\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("    <!--<td><a asp-controller=\"Home\" asp-action=\"Details\" asp-route-id=\"emp.Id\">Display </a></td>-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<myfirstnetcoreapp.Models.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
