#pragma checksum "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "986b5e426e0c2882fc19beb6ad69d801e543dde5"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"986b5e426e0c2882fc19beb6ad69d801e543dde5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fddf14152b3eb90ba6276941972eb916d194dc57", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StuffForSale.Models.Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(68, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(121, 381, true);
            WriteLiteral(@"
<table class='table table-stripped' id=""firstTable"">
    <thead>
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Description</th>
            <th>Tag</th>
            <th>Price</th>
            <th>Quantity</th>
            <th>Seller</th>
            <th>Date Added</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 20 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
          
            int i = 0;
            foreach (var item in Model)
            {
                i = i + 1;

#line default
#line hidden
            BeginContext(622, 46, true);
            WriteLiteral("                <tr>\r\n                    <th>");
            EndContext();
            BeginContext(669, 1, false);
#line 26 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
                   Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(670, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(702, 9, false);
#line 27 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(711, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(743, 16, false);
#line 28 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
                   Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(759, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(791, 13, false);
#line 29 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
                   Write(item.Tag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(804, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(836, 10, false);
#line 30 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
                   Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(846, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(878, 13, false);
#line 31 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
                   Write(item.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(891, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(923, 18, false);
#line 32 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
                   Write(item.User.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(941, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(973, 14, false);
#line 33 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
                   Write(item.DateAdded);

#line default
#line hidden
            EndContext();
            BeginContext(987, 57, true);
            WriteLiteral("</th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1044, 214, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "067c3cc9a3714fe3a685eec808f0b122", async() => {
                BeginContext(1141, 110, true);
                WriteLiteral("\r\n                            <button class=\"btn\" type=\"submit\">Add to cart</button>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 35 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
                                 WriteLiteral(item.ProductId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1258, 52, true);
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n");
            EndContext();
#line 40 "C:\Users\Nowak\Coding\NET CodersLab\09_Projekt_Zaliczeniowy\StuffForSale\StuffForSale\Views\Home\Index.cshtml"
            }
        

#line default
#line hidden
            BeginContext(1336, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
