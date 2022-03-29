using Autofac;
using System.Web.Http;
using ProjetoIntegradorUlifeParaDevs.Controllers;
using Autofac.Integration.WebApi;
using ProjetoIntegradorUlifeParaDevs.Services.Autenticacao;
using ProjetoIntegradorUlifeParaDevs.Repositories;

namespace ProjetoIntegradorUlifeParaDevs.App_Start
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LoginController>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<TokenService>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<UsuarioRepository>()
                .AsSelf()
                .InstancePerLifetimeScope();


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}