#pragma checksum "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a37b164f2fb56d23cdb77b83a4107f0e51fde9e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Details), @"mvc.1.0.view", @"/Views/Users/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Users/Details.cshtml", typeof(AspNetCore.Views_Users_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a37b164f2fb56d23cdb77b83a4107f0e51fde9e1", @"/Views/Users/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1131930eb5e43e9f43f2fa96b56990df5d3b8f7", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LoginWebApp.Models.ViewModels.UserDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(104, 80, true);
            WriteLiteral("\r\n\r\n<div>\r\n    <h4>User Details</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        ");
            EndContext();
            BeginContext(185, 25, false);
#line 12 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
   Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
            EndContext();
            BeginContext(210, 45, true);
            WriteLiteral("\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(256, 45, false);
#line 14 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(301, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(363, 41, false);
#line 17 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(404, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(465, 44, false);
#line 20 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(509, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(571, 40, false);
#line 23 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(611, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(672, 41, false);
#line 26 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(713, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(775, 37, false);
#line 29 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(812, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(873, 47, false);
#line 32 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
            EndContext();
            BeginContext(920, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(982, 43, false);
#line 35 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1025, 135, true);
            WriteLiteral("\r\n        </dd>\r\n    \r\n\r\n        \r\n    </dl>\r\n    <table class=\"\">\r\n        <thead>\r\n            <tr>\r\n                <th scope=\"col\">");
            EndContext();
            BeginContext(1161, 41, false);
#line 44 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.Roles));

#line default
#line hidden
            EndContext();
            BeginContext(1202, 61, true);
            WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 48 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
                  int i = 1; 

#line default
#line hidden
            BeginContext(1295, 16, true);
            WriteLiteral("                ");
            EndContext();
#line 49 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
                 foreach (var item in Model.Roles)
                {

#line default
#line hidden
            BeginContext(1366, 66, true);
            WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
            EndContext();
            BeginContext(1433, 1, false);
#line 52 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
                                   Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1434, 35, true);
            WriteLiteral("</th>\r\n                        <td>");
            EndContext();
            BeginContext(1470, 35, false);
#line 53 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
                       Write(Html.DisplayFor(model => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1505, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 55 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
                    {i++; }
                }

#line default
#line hidden
            BeginContext(1587, 53, true);
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1641, 54, false);
#line 62 "C:\Projects\Smollan\FinanceReportingRegistrationAPI\FinanceReportingRegistrationAPI\LoginWebApp\Views\Users\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1695, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1703, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a37b164f2fb56d23cdb77b83a4107f0e51fde9e111145", async() => {
                BeginContext(1725, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1741, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LoginWebApp.Models.ViewModels.UserDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591