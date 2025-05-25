using ShortMyUrl.Data.Repositories;
using ShortMyUrl.Domain.Interfaces.Repositories;
using ShortMyUrl.Domain.Interfaces.Services;
using ShortMyUrl.Domain.Services;

namespace ShortMyUrl.API.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar as injeções de dependência
    /// das interfaces e classes do projeto
    /// </summary>
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            #region Serviços de domínio

            services.AddScoped<IUrlDomainService, UrlDomainService>();

            #endregion

            #region Repositórios

            services.AddScoped<IUrlRepository, UrlRepository>();
            #endregion

            return services;
        }
    }
}
