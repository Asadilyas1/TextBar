#pragma checksum "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33d377f29c6afcd206598e0e8056bd1c4ab2d170"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Gallery), @"mvc.1.0.view", @"/Views/Home/Gallery.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33d377f29c6afcd206598e0e8056bd1c4ab2d170", @"/Views/Home/Gallery.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24860cdaa68183730317166b19fd785cd8aef50e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Gallery : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TaxBarAssociation.Models.GalleryModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-gallery-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("wind generators item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Gallery", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
  
    ViewData["Title"] = "Gallery";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!--
============================
Projects Gallery Section
============================
-->
<section class=""projects projects-gallery"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col section-title-s3"">
                <h2>Our Gallery</h2>
            </div>
        </div>
        <div class=""row"">
");
#nullable restore
#line 19 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
             foreach (var gallery in Model.galleries)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-12 col-md-4 col-lg-3 team-item "">
                    <div class=""project-panel"">
                        <div class=""project-panel-holder"">
                            <div class=""project-img"">
                                <div");
            BeginWriteAttribute("style", " style=\"", 820, "\"", 984, 11);
            WriteAttributeValue("", 828, "background-image:", 828, 17, true);
            WriteAttributeValue(" ", 845, "url(\'../../Uploads/GalleryImages/", 846, 34, true);
#nullable restore
#line 25 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
WriteAttributeValue("", 879, gallery.GalleryImage, 879, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 900, "\');", 900, 3, true);
            WriteAttributeValue(" ", 903, "height:", 904, 8, true);
            WriteAttributeValue(" ", 911, "160px;width:", 912, 13, true);
            WriteAttributeValue(" ", 924, "250px;", 925, 7, true);
            WriteAttributeValue(" ", 931, "background-size:", 932, 17, true);
            WriteAttributeValue(" ", 948, "cover;", 949, 7, true);
            WriteAttributeValue(" ", 955, "background-repeat:", 956, 19, true);
            WriteAttributeValue(" ", 974, "no-repeat", 975, 10, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n");
            WriteLiteral("                                <div class=\"project-hover\">\r\n                                    <div class=\"project-action\">\r\n                                        <div class=\"project-zoom\"><i class=\"far fa-eye\"></i>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33d377f29c6afcd206598e0e8056bd1c4ab2d1707711", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1437, "~/Uploads/GalleryImages/", 1437, 24, true);
#nullable restore
#line 29 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
AddHtmlAttributeValue("", 1461, gallery.GalleryImage, 1461, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</div>
                                    </div>
                                    <!-- End .project-action -->
                                </div>
                                <!-- End .project-hover-->
                            </div>
                            <!-- End .project-img-->
                        </div>
                        <!-- End .project-panel-holder-->
                    </div>
                    <!-- End .project-panel-->
                </div>
");
#nullable restore
#line 41 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"row\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33d377f29c6afcd206598e0e8056bd1c4ab2d17010181", async() => {
                WriteLiteral("\r\n                <div class=\"col-12 text-center\">\r\n");
#nullable restore
#line 46 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
                     for (int i = 1; i <= Model.PageCount; i++)
                    {
                        var acc = "";
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
                         if (i == Model.CurrentPageIndex)
                        {
                            acc = "active-gallery";
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
                         if (i != Model.CurrentPageIndex)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <a");
                BeginWriteAttribute("class", " class=\"", 2610, "\"", 2660, 4);
                WriteAttributeValue("", 2618, "btn", 2618, 3, true);
                WriteAttributeValue(" ", 2621, "btn--white", 2622, 11, true);
                WriteAttributeValue(" ", 2632, "justify-content-center", 2633, 23, true);
#nullable restore
#line 55 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
WriteAttributeValue(" ", 2655, acc, 2656, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("href", " href=\"", 2661, "\"", 2694, 3);
                WriteAttributeValue("", 2668, "javascript:PagerClick(", 2668, 22, true);
#nullable restore
#line 55 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
WriteAttributeValue("", 2690, i, 2690, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2692, ");", 2692, 2, true);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 55 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
                                                                                                               Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n");
#nullable restore
#line 56 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span");
                BeginWriteAttribute("class", " class=\"", 2821, "\"", 2871, 4);
                WriteAttributeValue("", 2829, "btn", 2829, 3, true);
                WriteAttributeValue(" ", 2832, "btn--white", 2833, 11, true);
                WriteAttributeValue(" ", 2843, "justify-content-center", 2844, 23, true);
#nullable restore
#line 59 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
WriteAttributeValue(" ", 2866, acc, 2867, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 59 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
                                                                                Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 60 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\cuty computer\Downloads\TaxBarAssociation\TaxBarAssociation\Views\Home\Gallery.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </div>\r\n                <input type=\"hidden\" id=\"hfCurrentPageIndex\" name=\"currentPageIndex\" />\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <!-- End .row-->\r\n    </div>\r\n    <!-- End .container-->\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TaxBarAssociation.Models.GalleryModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
