#pragma checksum "C:\Users\BLACK PC\OneDrive - edu.unirio.br\Documentos\GitHub\C#\sistemaAcad\Views\Shared\_Mensagem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de6e7d5815d8aaf5781000041a15bb288fad164e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Mensagem), @"mvc.1.0.view", @"/Views/Shared/_Mensagem.cshtml")]
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
#line 1 "C:\Users\BLACK PC\OneDrive - edu.unirio.br\Documentos\GitHub\C#\sistemaAcad\Views\Shared\_Mensagem.cshtml"
using sistemaAcad.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de6e7d5815d8aaf5781000041a15bb288fad164e", @"/Views/Shared/_Mensagem.cshtml")]
    public class Views_Shared__Mensagem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\BLACK PC\OneDrive - edu.unirio.br\Documentos\GitHub\C#\sistemaAcad\Views\Shared\_Mensagem.cshtml"
 if(TempData.ContainsKey("mensagem")){
    var mensagem = MensagemModels.Desserializar(TempData["mensagem"].ToString());
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\BLACK PC\OneDrive - edu.unirio.br\Documentos\GitHub\C#\sistemaAcad\Views\Shared\_Mensagem.cshtml"
     if(mensagem.Tipo == TipoMensagem.Erro){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-waring mt-3 alert-dismissible fade show\" role=\"alert\">\r\n            ");
#nullable restore
#line 8 "C:\Users\BLACK PC\OneDrive - edu.unirio.br\Documentos\GitHub\C#\sistemaAcad\Views\Shared\_Mensagem.cshtml"
       Write(mensagem.Texto);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\"></button>\r\n        </div>\r\n");
#nullable restore
#line 11 "C:\Users\BLACK PC\OneDrive - edu.unirio.br\Documentos\GitHub\C#\sistemaAcad\Views\Shared\_Mensagem.cshtml"
    }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-sucess mt-3 alert-dismissible fade show\" role=\"alert\">\r\n            ");
#nullable restore
#line 13 "C:\Users\BLACK PC\OneDrive - edu.unirio.br\Documentos\GitHub\C#\sistemaAcad\Views\Shared\_Mensagem.cshtml"
       Write(mensagem.Texto);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\"></button>\r\n        </div>\r\n");
#nullable restore
#line 16 "C:\Users\BLACK PC\OneDrive - edu.unirio.br\Documentos\GitHub\C#\sistemaAcad\Views\Shared\_Mensagem.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\BLACK PC\OneDrive - edu.unirio.br\Documentos\GitHub\C#\sistemaAcad\Views\Shared\_Mensagem.cshtml"
     
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
