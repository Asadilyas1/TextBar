#pragma checksum "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f95081472b0c3800e20ebc4b13220d38629b87e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__CommentPartial), @"mvc.1.0.view", @"/Views/Home/_CommentPartial.cshtml")]
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
#line 1 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\_ViewImports.cshtml"
using TaxBarAssociation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\_ViewImports.cshtml"
using TaxBarAssociation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f95081472b0c3800e20ebc4b13220d38629b87e2", @"/Views/Home/_CommentPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24860cdaa68183730317166b19fd785cd8aef50e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home__CommentPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TaxBarAssociation.Models.Comment>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
  
    void RenderComment(IEnumerable<TaxBarAssociation.Models.Comment> comments)
    {
        foreach (var comment in comments)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"comment-body\"");
            BeginWriteAttribute("id", " id=\"", 237, "\"", 268, 2);
            WriteAttributeValue("", 242, "comment-", 242, 8, true);
#nullable restore
#line 8 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
WriteAttributeValue("", 250, comment.CommentID, 250, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 8 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
                                                                         Write(comment.CommentID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <div class=\"avatar\"><img src=\"https://ssl.gstatic.com/accounts/ui/avatar_2x.png\" alt=\"avatar\" /></div>\r\n                <div class=\"comment\">\r\n                    <h6>");
#nullable restore
#line 11 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
                   Write(comment.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                    <div class=\"date\">Feb 28, 2019 - 08:07 pm</div>\r\n                    <p>");
#nullable restore
#line 13 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
                  Write(comment.CommentText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <a class=\"reply-link\"");
            BeginWriteAttribute("href", " href=\"", 667, "\"", 692, 1);
#nullable restore
#line 14 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
WriteAttributeValue("", 674, comment.CommentID, 674, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 14 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
                                                                        Write(comment.CommentID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Reply</a>\r\n");
#nullable restore
#line 15 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
                      
                        var children = Model.Where(x => x.ParentId == comment.CommentID).ToList();
                        if (children.Count() > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul data-parentid=\"");
#nullable restore
#line 19 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
                                          Write(comment.CommentID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"replies-list\">\r\n");
#nullable restore
#line 20 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
                                  
                                    RenderComment(children);
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n");
#nullable restore
#line 24 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </li>\r\n");
#nullable restore
#line 28 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"entry-widget-title\">\r\n    <h4><span class=\"comments-number\">");
#nullable restore
#line 32 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
                                 Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> comments</h4>\r\n</div>\r\n<div class=\"entry-widget-content\">\r\n    <ul class=\"comments-list\">\r\n");
#nullable restore
#line 36 "C:\Users\Saba Asghar\Downloads\Compressed\TaxBarAssociation\TaxBarAssociation\TaxBarAssociation\Views\Home\_CommentPartial.cshtml"
          
            RenderComment(Model.Where(x => x.ParentId == 0));
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n    <!-- End .comments-list-->\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TaxBarAssociation.Models.Comment>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
