#pragma checksum "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42184828e240558280482ad912f7ac85b9029f0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Order), @"mvc.1.0.view", @"/Views/Order/Order.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/Order.cshtml", typeof(AspNetCore.Views_Order_Order))]
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
#line 1 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\_ViewImports.cshtml"
using SkinShop;

#line default
#line hidden
#line 2 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\_ViewImports.cshtml"
using SkinShop.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42184828e240558280482ad912f7ac85b9029f0f", @"/Views/Order/Order.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ada4e39815f9fbc12b19bfda74e554ad4e539da3", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Order : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SkinShop.ViewModel.Order.OrderViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PlaceOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
  
    var sum = 0;

#line default
#line hidden
            BeginContext(75, 108, true);
            WriteLiteral("<div class=\"rowz\">\r\n\r\n</div>\r\n<div class=\"container\">\r\n    <div>\r\n        <strong>Bedankt voor u bestelling ");
            EndContext();
            BeginContext(184, 21, false);
#line 11 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
                                     Write(Model.order.User.Name);

#line default
#line hidden
            EndContext();
            BeginContext(205, 304, true);
            WriteLiteral(@"</strong><br />
    </div>

    <div>
        <h1>Factuur</h1><br />
        <strong>Gegevens:</strong><br />
        SkinShop <br />
        Eindhoven <br />
        0640982179<br />
    </div>
    <br />
    <div class=""products"">
        <div class=""txt-heading"">Order </div>


        ");
            EndContext();
            BeginContext(509, 2345, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a52b3a36378145cd9c9bf6f9de6e9daa", async() => {
                BeginContext(576, 450, true);
                WriteLiteral(@"


            <table class=""table table-bordered"">
                <thead>
                    <tr>
                        <th scope=""col"">ID</th>
                        <th scope=""col"">Name</th>
                        <th scope=""col"">Quantity</th>
                        <th scope=""col"">Price</th>
                        <th scope=""col"">Total Price</th>
                    </tr>
                </thead>
                <tbody>
");
                EndContext();
#line 40 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
                     foreach (var item in Model.order.Cart.Products)
                    {

#line default
#line hidden
                BeginContext(1119, 91, true);
                WriteLiteral("                    <tr>\r\n                        <td>\r\n                            <label>");
                EndContext();
                BeginContext(1211, 14, false);
#line 44 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
                              Write(item.ProductID);

#line default
#line hidden
                EndContext();
                BeginContext(1225, 58, true);
                WriteLiteral("</label>\r\n                            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1283, "\"", 1306, 1);
#line 45 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
WriteAttributeValue("", 1291, item.ProductID, 1291, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1307, 105, true);
                WriteLiteral(" />\r\n\r\n                        </td>\r\n\r\n                        <td>\r\n                            <label>");
                EndContext();
                BeginContext(1413, 16, false);
#line 50 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
                              Write(item.Productname);

#line default
#line hidden
                EndContext();
                BeginContext(1429, 58, true);
                WriteLiteral("</label>\r\n                            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1487, "\"", 1512, 1);
#line 51 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
WriteAttributeValue("", 1495, item.Productname, 1495, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1513, 158, true);
                WriteLiteral(" />\r\n\r\n                        </td>\r\n\r\n                        <td>\r\n                            <input type=\"text\" id=\"inputquantity\" size=\"3\" maxlength=\"2\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1671, "\"", 1691, 1);
#line 56 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
WriteAttributeValue("", 1679, item.Amount, 1679, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1692, 103, true);
                WriteLiteral(" />\r\n                        </td>\r\n\r\n                        <td>\r\n                            <label>");
                EndContext();
                BeginContext(1796, 17, false);
#line 60 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
                              Write(item.Productprice);

#line default
#line hidden
                EndContext();
                BeginContext(1813, 58, true);
                WriteLiteral("</label>\r\n                            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1871, "\"", 1897, 1);
#line 61 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
WriteAttributeValue("", 1879, item.Productprice, 1879, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1898, 103, true);
                WriteLiteral(" />\r\n                        </td>\r\n\r\n                        <td>\r\n                            <label>");
                EndContext();
                BeginContext(2002, 13, false);
#line 65 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
                              Write(item.SubTotal);

#line default
#line hidden
                EndContext();
                BeginContext(2015, 58, true);
                WriteLiteral("</label>\r\n                            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2073, "\"", 2095, 1);
#line 66 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
WriteAttributeValue("", 2081, item.SubTotal, 2081, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2096, 63, true);
                WriteLiteral(" />\r\n                        </td>\r\n                    </tr>\r\n");
                EndContext();
#line 69 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
                    }

#line default
#line hidden
                BeginContext(2182, 28, true);
                WriteLiteral("                    <tr>\r\n\r\n");
                EndContext();
#line 72 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
                         foreach (var x in Model.order.Cart.Products)
                        {
                            sum = Convert.ToInt32(x.SubTotal) + sum;
                        }

#line default
#line hidden
                BeginContext(2405, 142, true);
                WriteLiteral("\r\n                        <td colspan=\"6\" align=right>\r\n                            <strong>\r\n                                Totale Kosten : ");
                EndContext();
                BeginContext(2548, 3, false);
#line 79 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\Order.cshtml"
                                           Write(sum);

#line default
#line hidden
                EndContext();
                BeginContext(2551, 296, true);
                WriteLiteral(@"
                            </strong>
                        </td>
                    </tr>

                </tbody>

            </table>


            <div class=""buttonBestel"">
                <button type=""submit"" name=""bestellen"">Printen</button>
            </div>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2854, 20, true);
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SkinShop.ViewModel.Order.OrderViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
