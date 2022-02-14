using CsIO.Business.Models.Fornecedores.Enums;
using System;
using System.Web;
using System.Web.Mvc;

namespace CsIO.AppMvc.Extensions
{
    public static class RazorExtensions
    {
        public static bool PermitirExibicao(this WebViewPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(claimName, claimValue);
        }

        public static MvcHtmlString PermitirExibicao(this MvcHtmlString value, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static string ActionComPermissao(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(claimName, claimValue) ? urlHelper.Action(actionName, controllerName, routeValues) : "";
        }

        public static string FormatarDocumento(this WebViewPage page, ETipoFornecedor tipoPessoa, string documento)
        {
            return tipoPessoa == ETipoFornecedor.PessoaFisica
                ? Convert.ToInt64(documento).ToString(@"000\.000\.000\-00")
                : Convert.ToInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }

        public static bool ExibirNaUrl(this WebViewPage value, Guid id)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var urlTarget = urlHelper.Action("Edit", "Fornecedores", new { id = id });
            var urlTarget2 = urlHelper.Action("ObterEndereco", "Fornecedores", new { id = id });

            var urlEmUso = HttpContext.Current.Request.Path;

            return urlTarget.Equals(urlEmUso) || urlTarget2.Equals(urlEmUso);
        }
    }
}