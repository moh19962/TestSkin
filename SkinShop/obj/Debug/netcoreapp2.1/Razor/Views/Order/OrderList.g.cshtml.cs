#pragma checksum "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8444f50ae19d4949eac78991a0a7972c2fdede87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_OrderList), @"mvc.1.0.view", @"/Views/Order/OrderList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/OrderList.cshtml", typeof(AspNetCore.Views_Order_OrderList))]
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
#line 1 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
using Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8444f50ae19d4949eac78991a0a7972c2fdede87", @"/Views/Order/OrderList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ada4e39815f9fbc12b19bfda74e554ad4e539da3", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_OrderList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SkinShop.ViewModel.Order.OrderViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(62, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
  
    var sum = 0;

#line default
#line hidden
            BeginContext(89, 146, true);
            WriteLiteral("<div class=\"rowz\">\r\n\r\n</div>\r\n<div class=\"container\">\r\n\r\n    <br />\r\n    <div class=\"products\">\r\n        <div class=\"txt-heading\">Order </div>\r\n\r\n");
            EndContext();
#line 16 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
         foreach (var order in Model.OrderList)
        {

#line default
#line hidden
            BeginContext(295, 158, true);
            WriteLiteral("            <table class=\"table table-bordered\">\r\n                <thead>\r\n                <td colspan=\"5\">\r\n                    <strong>Ordernummer</strong> ");
            EndContext();
            BeginContext(454, 13, false);
#line 21 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
                                            Write(order.OrderId);

#line default
#line hidden
            EndContext();
            BeginContext(467, 477, true);
            WriteLiteral(@"
                    <strong>Winkel: </strong>  Eindhoven
                    <strong>Klant:</strong> Pendego
                </td>
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
#line 34 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
                 foreach (var item in order.Products)
                {

#line default
#line hidden
            BeginContext(1018, 91, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            <label>");
            EndContext();
            BeginContext(1110, 14, false);
#line 38 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
                              Write(item.ProductID);

#line default
#line hidden
            EndContext();
            BeginContext(1124, 58, true);
            WriteLiteral("</label>\r\n                            <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1182, "\"", 1205, 1);
#line 39 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
WriteAttributeValue("", 1190, item.ProductID, 1190, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1206, 104, true);
            WriteLiteral("/>\r\n\r\n                        </td>\r\n\r\n                        <td>\r\n                            <label>");
            EndContext();
            BeginContext(1311, 16, false);
#line 44 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
                              Write(item.Productname);

#line default
#line hidden
            EndContext();
            BeginContext(1327, 58, true);
            WriteLiteral("</label>\r\n                            <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1385, "\"", 1410, 1);
#line 45 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
WriteAttributeValue("", 1393, item.Productname, 1393, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1411, 157, true);
            WriteLiteral("/>\r\n\r\n                        </td>\r\n\r\n                        <td>\r\n                            <input type=\"text\" id=\"inputquantity\" size=\"3\" maxlength=\"2\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1568, "\"", 1588, 1);
#line 50 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
WriteAttributeValue("", 1576, item.Amount, 1576, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1589, 102, true);
            WriteLiteral("/>\r\n                        </td>\r\n\r\n                        <td>\r\n                            <label>");
            EndContext();
            BeginContext(1692, 17, false);
#line 54 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
                              Write(item.Productprice);

#line default
#line hidden
            EndContext();
            BeginContext(1709, 58, true);
            WriteLiteral("</label>\r\n                            <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1767, "\"", 1793, 1);
#line 55 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
WriteAttributeValue("", 1775, item.Productprice, 1775, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1794, 102, true);
            WriteLiteral("/>\r\n                        </td>\r\n\r\n                        <td>\r\n                            <label>");
            EndContext();
            BeginContext(1897, 13, false);
#line 59 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
                              Write(item.SubTotal);

#line default
#line hidden
            EndContext();
            BeginContext(1910, 58, true);
            WriteLiteral("</label>\r\n                            <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1968, "\"", 1990, 1);
#line 60 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
WriteAttributeValue("", 1976, item.SubTotal, 1976, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1991, 62, true);
            WriteLiteral("/>\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 63 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
                }

#line default
#line hidden
            BeginContext(2072, 38, true);
            WriteLiteral("                <tr>\r\n            \r\n\r\n");
            EndContext();
            BeginContext(2317, 130, true);
            WriteLiteral("\r\n                    <td colspan=\"6\" align=right>\r\n                        <strong>\r\n                            Totale Kosten : ");
            EndContext();
            BeginContext(2448, 39, false);
#line 75 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
                                       Write(Model.OrderList[0].Products[0].SubTotal);

#line default
#line hidden
            EndContext();
            BeginContext(2487, 4, true);
            WriteLiteral(" += ");
            EndContext();
            BeginContext(2492, 39, false);
#line 75 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
                                                                                   Write(Model.OrderList[0].Products[0].SubTotal);

#line default
#line hidden
            EndContext();
            BeginContext(2531, 139, true);
            WriteLiteral("\r\n                        </strong>\r\n                    </td>\r\n                </tr>\r\n\r\n                </tbody>\r\n\r\n            </table>\r\n");
            EndContext();
#line 83 "C:\Users\moham\OneDrive\Documenten\SEMESTER 2.3 HER\SOFTWARE\TestSkin\SkinShop\Views\Order\OrderList.cshtml"
        }

#line default
#line hidden
            BeginContext(2681, 18, true);
            WriteLiteral("    </div>\r\n</div>");
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
