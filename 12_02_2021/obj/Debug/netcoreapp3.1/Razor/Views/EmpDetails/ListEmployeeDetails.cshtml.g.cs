#pragma checksum "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "050ec416664fad219a074efe78880a666271c3c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EmpDetails_ListEmployeeDetails), @"mvc.1.0.view", @"/Views/EmpDetails/ListEmployeeDetails.cshtml")]
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
#line 1 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\_ViewImports.cshtml"
using SampleProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\_ViewImports.cshtml"
using SampleProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"050ec416664fad219a074efe78880a666271c3c3", @"/Views/EmpDetails/ListEmployeeDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7547ae200e22a29bcae05ee832a90868ebf4ba26", @"/Views/_ViewImports.cshtml")]
    public class Views_EmpDetails_ListEmployeeDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<System.Data.DataTable>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("List of Employees\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
  
    ViewBag.Title = "onclick";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<table class=""table table-bordered table-striped"">
    <tr>
        <th> EmpDetailid</th>
        <th> Empid</th>
        <th> EmpName</th>
        <th> DateOfbirth</th>
        <th> DateOfJoining</th>
        <th> Designation</th>
        <th> Degree</th>
        <th> Passoutyear</th>
        <th>GrossSalary</th>
        <th>NetSalary</th>

    </tr>

");
#nullable restore
#line 23 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
     for (int i = 0; i < Model.Rows.Count; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <!--<td>-->\r\n");
            WriteLiteral(" <!--");
#nullable restore
#line 27 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
                                                                                       Write(Model.Rows[i][0]);

#line default
#line hidden
#nullable disable
            WriteLiteral("-->");
            WriteLiteral("\r\n    <!--</td>-->\r\n    <td>");
#nullable restore
#line 29 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
   Write(Model.Rows[i][0]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 30 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
   Write(Model.Rows[i][1]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 31 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
   Write(Model.Rows[i][2]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 32 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
   Write(Model.Rows[i][3]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 33 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
   Write(Model.Rows[i][4]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 34 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
   Write(Model.Rows[i][5]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 35 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
   Write(Model.Rows[i][6]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 36 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
   Write(Model.Rows[i][7]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 957, "\"", 1033, 1);
#nullable restore
#line 38 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
WriteAttributeValue("", 964, Url.Action("ShowGrossSalary","Bank", new { @id = @Model.Rows[i][0]}), 964, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 38 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
                                                                                    Write(Model.Rows[i][8]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </td>\r\n    <td>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 1090, "\"", 1164, 1);
#nullable restore
#line 41 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
WriteAttributeValue("", 1097, Url.Action("ShowNetSalary","Bank", new { @id = @Model.Rows[i][0]}), 1097, 67, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 41 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
                                                                                  Write(Model.Rows[i][9]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </td>\r\n\r\n    <td>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 1223, "\"", 1310, 1);
#nullable restore
#line 45 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
WriteAttributeValue("", 1230, Url.Action("DeleteEmployeeDetails","EmpDetails",new { @id = @Model.Rows[i][0]}), 1230, 80, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n\r\n    </td>\r\n    <td>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 1357, "\"", 1436, 1);
#nullable restore
#line 49 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
WriteAttributeValue("", 1364, Url.Action("EditEmpDetail","EmpDetails",new { @id = @Model.Rows[i][0]}), 1364, 72, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\r\n\r\n    </td>\r\n\r\n</tr>\r\n");
#nullable restore
#line 54 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n<a");
            BeginWriteAttribute("href", " href=\"", 1491, "\"", 1547, 1);
#nullable restore
#line 57 "C:\Users\Ravina Ghadshi\source\repos\SampleProject\SampleProject\Views\EmpDetails\ListEmployeeDetails.cshtml"
WriteAttributeValue(" ", 1498, Url.Action("CreateEmployeeDetail","EmpDetails"), 1499, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Add Employee Details</a>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<System.Data.DataTable> Html { get; private set; }
    }
}
#pragma warning restore 1591
