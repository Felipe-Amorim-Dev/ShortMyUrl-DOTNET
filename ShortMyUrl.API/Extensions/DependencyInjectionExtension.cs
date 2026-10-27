using ShortMyUrl.Data.Repositories;
using ShortMyUrl.Domain.Interfaces.Repositories;
using ShortMyUrl.Domain.Interfaces.Services;
using ShortMyUrl.Domain.Services;

namespace ShortMyUrl.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUrlRepository, UrlRepository>();
            services.AddScoped<IUrlDomainService>(provider =>
            {
                var repository = provider.GetRequiredService<IUrlRepository>();
                var publicBaseUrl = configuration["ShortUrl:BaseUrl"];

                if (string.IsNullOrWhiteSpace(publicBaseUrl))
                {
                    throw new InvalidOperationException("Configure ShortUrl:BaseUrl antes de iniciar o encurtador.");
                }

                return new UrlDomainService(repository, publicBaseUrl);
            });

            return services;
        }
    }
}
