#pragma checksum "C:\Users\47218167829\Desktop\PontoDigital\Views\Depoimentos\BuscarDepoimentos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "576eb7f196b6e999d85f85d5edf212bee195a028"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Depoimentos_BuscarDepoimentos), @"mvc.1.0.view", @"/Views/Depoimentos/BuscarDepoimentos.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Depoimentos/BuscarDepoimentos.cshtml", typeof(AspNetCore.Views_Depoimentos_BuscarDepoimentos))]
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
#line 1 "C:\Users\47218167829\Desktop\PontoDigital\Views\_ViewImports.cshtml"
using PontoDigital;

#line default
#line hidden
#line 2 "C:\Users\47218167829\Desktop\PontoDigital\Views\_ViewImports.cshtml"
using PontoDigital.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"576eb7f196b6e999d85f85d5edf212bee195a028", @"/Views/Depoimentos/BuscarDepoimentos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b910b3ba7e7adee03aca8981fb32aa0bb2060f4", @"/Views/_ViewImports.cshtml")]
    public class Views_Depoimentos_BuscarDepoimentos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PontoDigital.ViewModels.HomeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\47218167829\Desktop\PontoDigital\Views\Depoimentos\BuscarDepoimentos.cshtml"
  
    Layout="_Layout";

#line default
#line hidden
            BeginContext(76, 18, true);
            WriteLiteral("<p>Pesquisa:</p>\r\n");
            EndContext();
            BeginContext(94, 197, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ccc851b16cc4b4eac4381c91061b65b", async() => {
                BeginContext(163, 121, true);
                WriteLiteral("\r\n    <label for=\"data\">Data:</label>\r\n    <input type=\"date\" name=\"data\">\r\n\r\n    <input type=\"submit\" value=\"Filtrar\">\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
#line 6 "C:\Users\47218167829\Desktop\PontoDigital\Views\Depoimentos\BuscarDepoimentos.cshtml"
AddHtmlAttributeValue("", 108, Url.Action("BuscarDepoimentos","Home"), 108, 39, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(291, 273, true);
            WriteLiteral(@"

<h2>Registro de Depoimentos</h2>

<table>
    <thead>
        <tr>
            <th>Nome</th>
            <th>Sobrenome</th>
            <th>Email</th>
            <th>Mensagem</th>
            <th>Data e Horário</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 26 "C:\Users\47218167829\Desktop\PontoDigital\Views\Depoimentos\BuscarDepoimentos.cshtml"
         foreach(var item in Model.Depoimentos){
            

#line default
#line hidden
#line 27 "C:\Users\47218167829\Desktop\PontoDigital\Views\Depoimentos\BuscarDepoimentos.cshtml"
             if(item == null){
                continue;
            }

#line default
#line hidden
            BeginContext(688, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(719, 9, false);
#line 31 "C:\Users\47218167829\Desktop\PontoDigital\Views\Depoimentos\BuscarDepoimentos.cshtml"
           Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(728, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(752, 14, false);
#line 32 "C:\Users\47218167829\Desktop\PontoDigital\Views\Depoimentos\BuscarDepoimentos.cshtml"
           Write(item.Sobrenome);

#line default
#line hidden
            EndContext();
            BeginContext(766, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(790, 10, false);
#line 33 "C:\Users\47218167829\Desktop\PontoDigital\Views\Depoimentos\BuscarDepoimentos.cshtml"
           Write(item.Email);

#line default
#line hidden
            EndContext();
            BeginContext(800, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(824, 13, false);
#line 34 "C:\Users\47218167829\Desktop\PontoDigital\Views\Depoimentos\BuscarDepoimentos.cshtml"
           Write(item.Mensagem);

#line default
#line hidden
            EndContext();
            BeginContext(837, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(861, 16, false);
#line 35 "C:\Users\47218167829\Desktop\PontoDigital\Views\Depoimentos\BuscarDepoimentos.cshtml"
           Write(item.DataEntrada);

#line default
#line hidden
            EndContext();
            BeginContext(877, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 37 "C:\Users\47218167829\Desktop\PontoDigital\Views\Depoimentos\BuscarDepoimentos.cshtml"
        }

#line default
#line hidden
            BeginContext(910, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PontoDigital.ViewModels.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
