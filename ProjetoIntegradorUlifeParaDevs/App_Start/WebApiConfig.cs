using ProjetoIntegradorUlifeParaDevs.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace ProjetoIntegradorUlifeParaDevs
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuração e serviços de API Web

            AutofacConfig.Register(config);

            // Rotas de API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            System.Web.Http.GlobalConfiguration.Configure((httpConfig) =>
            {
                httpConfig.Filters.Add(new AuthorizeAttribute());
            });
        }
    }
}
