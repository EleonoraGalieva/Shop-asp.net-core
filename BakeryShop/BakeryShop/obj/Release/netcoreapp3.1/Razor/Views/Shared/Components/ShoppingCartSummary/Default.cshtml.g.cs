#pragma checksum "D:\STUDY\ASP\Shop-asp.net-core\BakeryShop\BakeryShop\Views\Shared\Components\ShoppingCartSummary\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d45670817e7c381a815d154ea7ea8b199a5b418"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ShoppingCartSummary_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ShoppingCartSummary/Default.cshtml")]
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
#line 1 "D:\STUDY\ASP\Shop-asp.net-core\BakeryShop\BakeryShop\Views\_ViewImports.cshtml"
using BakeryShop.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\STUDY\ASP\Shop-asp.net-core\BakeryShop\BakeryShop\Views\_ViewImports.cshtml"
using BakeryShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\STUDY\ASP\Shop-asp.net-core\BakeryShop\BakeryShop\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d45670817e7c381a815d154ea7ea8b199a5b418", @"/Views/Shared/Components/ShoppingCartSummary/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a06166806c362b5f88d6b1bbbb733c5527a8468", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ShoppingCartSummary_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShoppingCartViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\STUDY\ASP\Shop-asp.net-core\BakeryShop\BakeryShop\Views\Shared\Components\ShoppingCartSummary\Default.cshtml"
 if (Model.ShoppingCart.ShoppingCartItems.Count >= 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li>\r\n        <a>\r\n            <span class=\"glyphicon glyphicon-shopping-cart\"></span>\r\n            <span id=\"cart-status\">\r\n                ");
#nullable restore
#line 9 "D:\STUDY\ASP\Shop-asp.net-core\BakeryShop\BakeryShop\Views\Shared\Components\ShoppingCartSummary\Default.cshtml"
           Write(Model.ShoppingCart.ShoppingCartItems.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </span>\r\n        </a>\r\n    </li>\r\n");
#nullable restore
#line 13 "D:\STUDY\ASP\Shop-asp.net-core\BakeryShop\BakeryShop\Views\Shared\Components\ShoppingCartSummary\Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShoppingCartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
