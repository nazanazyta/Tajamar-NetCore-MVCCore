#pragma checksum "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\EmpleadosSession\Pedidos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0dd214313a00a7ea57ed26c9270358c0de9c9cc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EmpleadosSession_Pedidos), @"mvc.1.0.view", @"/Views/EmpleadosSession/Pedidos.cshtml")]
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
#line 1 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\_ViewImports.cshtml"
using MvcCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\_ViewImports.cshtml"
using MvcCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\_ViewImports.cshtml"
using MvcCore.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0dd214313a00a7ea57ed26c9270358c0de9c9cc0", @"/Views/EmpleadosSession/Pedidos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aacf604b8c192754de1957aafa586ce281ae238d", @"/Views/_ViewImports.cshtml")]
    public class Views_EmpleadosSession_Pedidos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MvcCore.Models.Empleado>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\EmpleadosSession\Pedidos.cshtml"
  
    ViewData["Title"] = "Pedidos";
    List<int> cantidades = ViewData["cantidades"] as List<int>;
    int contador = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Pedidos</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\EmpleadosSession\Pedidos.cshtml"
           Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\EmpleadosSession\Pedidos.cshtml"
           Write(Html.DisplayNameFor(model => model.Oficio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>Cantidad</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 25 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\EmpleadosSession\Pedidos.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 28 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\EmpleadosSession\Pedidos.cshtml"
           Write(Html.DisplayFor(modelItem => item.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\EmpleadosSession\Pedidos.cshtml"
           Write(Html.DisplayFor(modelItem => item.Oficio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td style=\"color: red\">");
#nullable restore
#line 33 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\EmpleadosSession\Pedidos.cshtml"
                              Write(cantidades[contador]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 34 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\EmpleadosSession\Pedidos.cshtml"
              contador++;

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 36 "G:\Repos\Tajamar-NetCore-MVCCore\MvcCore\Views\EmpleadosSession\Pedidos.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MvcCore.Models.Empleado>> Html { get; private set; }
    }
}
#pragma warning restore 1591