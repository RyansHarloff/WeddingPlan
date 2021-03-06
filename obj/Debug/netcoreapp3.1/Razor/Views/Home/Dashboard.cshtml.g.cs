#pragma checksum "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e59ca0c8955ffb73bee24031f297e56ed6a191e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
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
#line 1 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\_ViewImports.cshtml"
using WeddingPlan;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\_ViewImports.cshtml"
using WeddingPlan.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e59ca0c8955ffb73bee24031f297e56ed6a191e7", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38b7769b83d68bf5f274258cd5bd6a20c31cc6be", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_NavBarPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e59ca0c8955ffb73bee24031f297e56ed6a191e73377", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<h1>Welcome to the Wedding Planner!</h1>\r\n<table class = \"table table-striped\">\r\n    <tr>\r\n        <th>Wedding</th>\r\n        <th>Date</th>\r\n        <th>Guest</th>\r\n        <th>Action</th>\r\n    </tr>\r\n");
#nullable restore
#line 10 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
     foreach(Wedding w in ViewBag.OtherWeddings)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td><a href=\"/OneWedding/{WeddingId}\">");
#nullable restore
#line 13 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
                                             Write(w.WedderOne);

#line default
#line hidden
#nullable disable
            WriteLiteral(" & ");
#nullable restore
#line 13 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
                                                            Write(w.WedderTwo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n            <td>");
#nullable restore
#line 14 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
           Write(w.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 15 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
           Write(w.GuestAttending.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n");
#nullable restore
#line 17 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
              
                if(w.GuestAttending.Any(a => a.UserId == ViewBag.Users.UserId))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 653, "\"", 701, 4);
            WriteAttributeValue("", 660, "norsvp/", 660, 7, true);
#nullable restore
#line 20 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 667, ViewBag.Users.UserId, 667, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 688, "/", 688, 1, true);
#nullable restore
#line 20 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 689, w.WeddingId, 689, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\">NoRsvp</a>\r\n");
#nullable restore
#line 21 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
                }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 799, "\"", 845, 4);
            WriteAttributeValue("", 806, "rsvp/", 806, 5, true);
#nullable restore
#line 22 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 811, ViewBag.Users.UserId, 811, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 832, "/", 832, 1, true);
#nullable restore
#line 22 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 833, w.WeddingId, 833, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\">Rsvp</a>\r\n");
#nullable restore
#line 23 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 26 "C:\Users\ryans\OneDrive\Desktop\CodingDojo\cSharp\WeddingPlan\Views\Home\Dashboard.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n");
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
