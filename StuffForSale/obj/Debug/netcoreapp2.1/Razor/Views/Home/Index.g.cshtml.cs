#pragma checksum "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d842d7ef34478caaddb86447723a07355f949bf4"
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
#line 1 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d842d7ef34478caaddb86447723a07355f949bf4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fddf14152b3eb90ba6276941972eb916d194dc57", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 1263, true);
            WriteLiteral(@"
<script type=""text/javascript"" src=""js/Home.js""></script>

<div>
    <br />
    <div class=""row"">

        <div id='badge_layout' class=""d-none"" style=""display: block"">
            <button type=""button"" class=""btn btn-outline-primary"">Primary</button>
        </div>

        <div id=""tags"" class=""col-md-12"" style=""text-align: center"">

        </div>
    </div>
    <br />

    <div class=""container-fluid"">
        <div id=""index_table"" class=""col-sm-12""></div>

        <table id=""table_form_1"" class='table table-hover d-none'>
            <thead class=""table-dark col-11"">
                <tr>
                    <th scope=""col"" class='align-middle text-center col-sm-1'>Picture</th>
                    <th scope=""col"" class='align-middle text-center col-sm-1'>Name</th>
                    <th scope=""col"" class='align-middle text-center col-sm-1'>Description</th>
                    <th scope=""col"" class='align-middle text-center col-sm-1'>Tag</th>
                    <th scope=""col""");
            WriteLiteral(" class=\'align-middle text-center col-sm-1\'>Price</th>\r\n                    <th scope=\"col\" class=\'align-middle text-center col-sm-1\'>Quantity</th>\r\n                    <th scope=\"col\" class=\'align-middle text-center col-sm-1\'>Seller</th>\r\n");
            EndContext();
            BeginContext(1387, 315, true);
            WriteLiteral(@"                    <th scope=""col"" class='align-middle text-center col-sm-5'></th>
                </tr>
            </thead>
            <tbody>
                <tr class=""data_tr d-none"">
                    <td class="" col-sm-1"">
                        <img src=""https://via.placeholder.com/80x80"" />

");
            EndContext();
            BeginContext(1813, 448, true);
            WriteLiteral(@"                    </td>
                    <td class=""name align-middle col-sm-1""></td>
                    <td class=""description align-middle col-sm-1""></td>
                    <td class=""tag align-middle col-sm-1""></td>
                    <td class=""price align-middle col-sm-1""></td>
                    <td class=""quantity align-middle text-center col-sm-1""></td>
                    <td class=""seller align-middle col-sm-1""></td>
");
            EndContext();
            BeginContext(2322, 104, true);
            WriteLiteral("                    <td class=\"b align-middle\">\r\n                        <button class=\"btn\"></button>\r\n");
            EndContext();
            BeginContext(2479, 391, true);
            WriteLiteral(@"                    </td>
                </tr>
            </tbody>
        </table>

    </div>
    <br />
    <div align=""center"">
        <div id=""PagingDiv"" style=""display: inline-block"">

        </div>
    </div>


    <div id=""Page"" class=""d-none"" style=""display: inline-block"">
        <a class=""btn btn-outline-primary"">Test</a>
    </div>
    <br />
</div>


");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
