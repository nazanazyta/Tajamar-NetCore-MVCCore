#pragma checksum "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac07640a64e4b56f0f7f3d08ea38c1fe6b1a7ea0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departamentos_SeleccionMultiple), @"mvc.1.0.view", @"/Views/Departamentos/SeleccionMultiple.cshtml")]
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
#line 1 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\_ViewImports.cshtml"
using MvcCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\_ViewImports.cshtml"
using MvcCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac07640a64e4b56f0f7f3d08ea38c1fe6b1a7ea0", @"/Views/Departamentos/SeleccionMultiple.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96b20d19bb6bf05602367549330a6c2b7ce7662b", @"/Views/_ViewImports.cshtml")]
    public class Views_Departamentos_SeleccionMultiple : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Empleado>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
  
    ViewData["Title"] = "SeleccionMultiple";
    List<Departamento> departamentos = ViewData["departamentos"] as List<Departamento>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("styles", async() => {
                WriteLiteral("\r\n    <style>\r\n        ul#menu li{\r\n            display: inline;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral("\r\n<h1>Selección Múltiple empleados</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac07640a64e4b56f0f7f3d08ea38c1fe6b1a7ea04275", async() => {
                WriteLiteral("\r\n    <ul id=\"menu\" class=\"list-group\">\r\n");
#nullable restore
#line 20 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
         foreach (Departamento dept in departamentos)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <li class=\"list-group-item\">\r\n                <input type=\"checkbox\" name=\"iddepartamentos\"\r\n                       class=\"form-check\"");
                BeginWriteAttribute("value", " value=\"", 602, "\"", 622, 1);
#nullable restore
#line 24 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
WriteAttributeValue("", 610, dept.Numero, 610, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                ");
#nullable restore
#line 25 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
           Write(dept.Nombre);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </li>\r\n");
#nullable restore
#line 27 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </ul>\r\n    <button type=\"submit\" class=\"btn btn-success\">Mostrar empleados</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 32 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-danger\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 38 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
               Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 41 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
               Write(Html.DisplayNameFor(model => model.Oficio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 44 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
               Write(Html.DisplayNameFor(model => model.Salario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 47 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
               Write(Html.DisplayNameFor(model => model.Departamento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 53 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 57 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 60 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Oficio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 63 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Salario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 66 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Departamento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 69 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 70 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 71 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 74 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 77 "C:\Users\Nazaret\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\Departamentos\SeleccionMultiple.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Empleado>> Html { get; private set; }
    }
}
#pragma warning restore 1591