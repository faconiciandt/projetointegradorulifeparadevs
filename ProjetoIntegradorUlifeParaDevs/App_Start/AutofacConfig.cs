using Autofac;
using System.Web.Http;
using ProjetoIntegradorUlifeParaDevs.Controllers;
using Autofac.Integration.WebApi;
using ProjetoIntegradorUlifeParaDevs.Services.Autenticacao;
using ProjetoIntegradorUlifeParaDevs.Repositories;
using ProjetoIntegradorUlifeParaDevs.Services;
using System.Reflection;

namespace ProjetoIntegradorUlifeParaDevs.App_Start
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Repository"))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Service"))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Controller"))
                .InstancePerLifetimeScope();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}