#pragma checksum "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Dashboard\_LoadSlider.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16b9b12de0593336d1e9c7b9633f049288f7d8da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard__LoadSlider), @"mvc.1.0.view", @"/Views/Dashboard/_LoadSlider.cshtml")]
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
#line 1 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\_ViewImports.cshtml"
using TaxBarAssociation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\_ViewImports.cshtml"
using TaxBarAssociation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16b9b12de0593336d1e9c7b9633f049288f7d8da", @"/Views/Dashboard/_LoadSlider.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24860cdaa68183730317166b19fd785cd8aef50e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Dashboard__LoadSlider : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TaxBarAssociation.Models.Sliders>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Slider", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""table-responsive"">
    <table id=""SliderDatatable"" width=""100%"" class=""table table-bordered table-striped"">
        <thead>
            <tr>
                <th>S.No.</th>
                <th>Image</th>
                <th>Order By</th>
                <th>Operations</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 13 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Dashboard\_LoadSlider.cshtml"
              
                var i = 1;
                foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 18 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Dashboard\_LoadSlider.cshtml"
                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><img");
            BeginWriteAttribute("src", " src=\"", 604, "\"", 654, 2);
            WriteAttributeValue("", 610, "../../Uploads/SliderImages/", 610, 27, true);
#nullable restore
#line 19 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Dashboard\_LoadSlider.cshtml"
WriteAttributeValue("", 637, item.SliderImage, 637, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"50\" alt=\"No Image\" /></td>\r\n                        <td>");
#nullable restore
#line 20 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Dashboard\_LoadSlider.cshtml"
                       Write(item.Ord);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16b9b12de0593336d1e9c7b9633f049288f7d8da6124", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Dashboard\_LoadSlider.cshtml"
                                                                                WriteLiteral(item.SliderID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <a href=\"javascript:void(0)\"");
            BeginWriteAttribute("onclick", " onclick=\"", 992, "\"", 1026, 3);
            WriteAttributeValue("", 1002, "Delete(\'", 1002, 8, true);
#nullable restore
#line 23 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Dashboard\_LoadSlider.cshtml"
WriteAttributeValue("", 1010, item.SliderID, 1010, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1024, "\')", 1024, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-sm\"><i class=\"fa fa-trash\"></i></a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 26 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Dashboard\_LoadSlider.cshtml"
                    i = i + 1;
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TaxBarAssociation.Models.Sliders>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
