#pragma checksum "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Reports\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71ee134994360b1ecce644955109d0589858120b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reports_Index), @"mvc.1.0.view", @"/Views/Reports/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Reports/Index.cshtml", typeof(AspNetCore.Views_Reports_Index))]
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
#line 1 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\_ViewImports.cshtml"
using LoginWebApp;

#line default
#line hidden
#line 2 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\_ViewImports.cshtml"
using LoginWebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71ee134994360b1ecce644955109d0589858120b", @"/Views/Reports/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1131930eb5e43e9f43f2fa96b56990df5d3b8f7", @"/Views/_ViewImports.cshtml")]
    public class Views_Reports_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/reports.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Reports\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(43, 1625, true);
            WriteLiteral(@"
<h3>Reports</h3>

<ul class=""nav nav-tabs"" role=""tablist"">
    <li class=""nav-item"">
        <a class=""nav-link active"" data-toggle=""tab"" href=""#creditCard"" role=""tab"" id=""creditReportTab"">Credit Card</a>
    </li>
    <li class=""nav-item"">
        <a class=""nav-link"" data-toggle=""tab"" href=""#cellular"" role=""tab"" id=""cellularReportTab"">Cellular</a>
    </li>
    <li class=""nav-item"">
        <a class=""nav-link"" data-toggle=""tab"" href=""#fleet"" role=""tab"" id=""fleetReportTab"">Fleet</a>
    </li>

    <li class=""nav-item"">
        <a class=""nav-link"" data-toggle=""tab"" href=""#payroll"" role=""tab"" id=""payrollReportTab"">Payroll</a>
    </li>

    <li class=""nav-item"">
        <a class=""nav-link"" data-toggle=""tab"" href=""#procurement"" role=""tab"" id=""procurementReportTab"">Procurement</a>
    </li>

    <li class=""nav-item"">
        <a class=""nav-link"" data-toggle=""tab"" href=""#travel"" role=""tab"" id=""travelReportTab"">Travel</a>
    </li>
</ul>

<div class=""tab-content"">
    <div class=""tab-pan");
            WriteLiteral(@"e fade active show"" id=""creditCard"">
        <div id=""creditCard-view""></div>
    </div>

    <div class=""tab-pane fade"" id=""cellular"">
        <div id=""cellular-view""></div>
    </div>

    <div class=""tab-pane fade"" id=""fleet"">
        <div id=""fleet-view""></div>
    </div>

    <div class=""tab-pane fade"" id=""payroll"">
        <div id=""payroll-view""></div>
    </div>

    <div class=""tab-pane fade"" id=""procurement"">
        <div id=""procurement-view""></div>
    </div>

    <div class=""tab-pane fade"" id=""travel"">
        <div id=""travel-view""></div>
    </div>
</div>

");
            EndContext();
            BeginContext(1668, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71ee134994360b1ecce644955109d0589858120b6136", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1719, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1721, 39, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71ee134994360b1ecce644955109d0589858120b7315", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1760, 2, true);
            WriteLiteral("\r\n");
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
