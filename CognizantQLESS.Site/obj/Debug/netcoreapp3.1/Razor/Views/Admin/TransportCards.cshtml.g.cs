#pragma checksum "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48e69b7d64683ca7ddff3189b1857291703e4bfb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_TransportCards), @"mvc.1.0.view", @"/Views/Admin/TransportCards.cshtml")]
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
#line 1 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\_ViewImports.cshtml"
using CognizantQLESS.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\_ViewImports.cshtml"
using CognizantQLESS.Site.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48e69b7d64683ca7ddff3189b1857291703e4bfb", @"/Views/Admin/TransportCards.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bc9b9be03780d72ca45d0a0e1f81e2501bb7778", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_TransportCards : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CognizantQLESS.Core.Models.TransportCard>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TransportCardCreate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TransportCardDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"window-wrapper\">\r\n            <h4 style=\"margin-bottom:0px !important;\" class=\"window-heading\">Transport Cards</h4>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48e69b7d64683ca7ddff3189b1857291703e4bfb4674", async() => {
                WriteLiteral("\r\n                <p>\r\n                    <button style=\"margin-bottom:40px !important;\" class=\"btn btn-xs btn-success\" type=\"submit\">Create New</button>\r\n                </p>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            <table class=\"table\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>\r\n                            ");
#nullable restore
#line 21 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                       Write(Html.DisplayNameFor(model => model.SerialNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            Type\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 27 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                       Write(Html.DisplayNameFor(model => model.Load));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 30 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                       Write(Html.DisplayNameFor(model => model.PurchaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 33 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                       Write(Html.DisplayNameFor(model => model.ExpirationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 39 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 43 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SerialNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 46 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                             if (item.IsDiscountType)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"text-success\">Discount</span>\r\n");
#nullable restore
#line 49 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"text-primary\">Regular</span>\r\n");
#nullable restore
#line 53 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 56 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Load));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 59 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PurchaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 62 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ExpirationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48e69b7d64683ca7ddff3189b1857291703e4bfb11427", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                                                                   WriteLiteral(item.TransportCardId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            &nbsp;\r\n                            <!--\r\n                                <a asp-action=\"TransportCardDelete\" asp-route-id=\"");
#nullable restore
#line 68 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                                                                             Write(item.TransportCardId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Delete</a>\r\n                            -->\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 72 "C:\Users\YZPC\Documents\Visual Studio 2019\Projects\CognizantQLESS\CognizantQLESS.Site\Views\Admin\TransportCards.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CognizantQLESS.Core.Models.TransportCard>> Html { get; private set; }
    }
}
#pragma warning restore 1591
