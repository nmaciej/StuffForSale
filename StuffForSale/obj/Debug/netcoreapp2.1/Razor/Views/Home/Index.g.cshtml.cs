#pragma checksum "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "420bfcc5e04f90f4563df5cc2e43e1ce69664ba3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\_ViewImports.cshtml"
using StuffForSale;

#line default
#line hidden
#line 3 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"420bfcc5e04f90f4563df5cc2e43e1ce69664ba3", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fddf14152b3eb90ba6276941972eb916d194dc57", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StuffForSale.Models.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(68, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(155, 2238, true);
            WriteLiteral(@"
<script type=""text/javascript"" src=""js/Home.js""></script>

<div class=""container"">
    <br />
    <div class=""row"">
        <h2>Select tag to filter results!</h2>
        <div id='badge_layout' class=""d-none"">
            <button type=""button"" class=""btn btn-outline-primary"">Primary</button>
        </div>

        <div id=""tags"" class=""col-md-12"">

        </div>
    </div>
    <br />
    <div class=""row"">
        <div id=""index_table""></div>

        <table id=""table_form_1"" class='table table-hover d-none'>
            <thead class=""table-dark col-11"">
                <tr>
                    <th scope=""col"" class='align-middle text-center'>Id</th>
                    <th scope=""col"" class='align-middle text-center'>Picture</th>
                    <th scope=""col"" class='align-middle text-center'>Name</th>
                    <th scope=""col"" class='align-middle text-center'>Description</th>
                    <th scope=""col"" class='align-middle text-center'>Tag</th>
           ");
            WriteLiteral(@"         <th scope=""col"" class='align-middle text-center'>Price</th>
                    <th scope=""col"" class='align-middle text-center'>Quantity</th>
                    <th scope=""col"" class='align-middle text-center'>Seller</th>
                    <th scope=""col"" class='align-middle text-center'>Date Added</th>
                    <th scope=""col"" class='align-middle text-center'></th>
                </tr>
            </thead>
            <tbody>
                <tr class=""data_tr d-none"">
                    <th scope=""row"" class=""id align-middle""></th>
                    <td><img src=""images/logo.jpg"" style=""width:100px;height:100px;"" class=""rounded"" /></td>
                    <td class=""name align-middle""></td>
                    <td class=""description align-middle""></td>
                    <td class=""tag align-middle""></td>
                    <td class=""price align-middle""></td>
                    <td class=""quantity align-middle text-center""></td>
                    <td class=");
            WriteLiteral("\"seller align-middle\"></td>\r\n                    <td class=\"date align-middle\"></td>\r\n                    <td class=\"b align-middle\">\r\n                        <button class=\"btn\"></button>\r\n");
            EndContext();
            BeginContext(2446, 118, true);
            WriteLiteral("                    </td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StuffForSale.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
