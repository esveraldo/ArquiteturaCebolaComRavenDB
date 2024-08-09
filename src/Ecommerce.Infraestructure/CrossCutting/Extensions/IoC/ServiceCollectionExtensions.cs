using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services;

namespace Ecommerce.Infraestructure.CrossCutting.Extensions.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRavenDb(this IServiceCollection services)
        {
             
            services.TryAddSingleton<IDocumentStore>(ctx => {
                var ravenDbSettings = ctx.GetRequiredService<IOptions<RavenDbSettings>>().Value;
                var store = new DocumentStore
                {
                    Urls = new[] { ravenDbSettings.Url } ,
                    Database = ravenDbSettings.DatabaseName
                };

                store.Initialize(); 

                return store;
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.TryAddScoped<ICustumerRepository, CustumerRepository>();
            return services;
        }

        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            services.TryAddScoped<ICustumerService, CustumerService>();
            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.TryAddScoped<IMapper<Custumer, CustumerDto>, CustumerMapper>();
            services.TryAddScoped<IMapper<CustumerDto, Custumer>, CustumerMapper>();
            return services;
        }

        public static IServiceCollection AddAppService(this IServiceCollection services)
        {
            services.TryAddScoped<ICustumerAppService, CustumerAppSerivce>();
            return services;
        }
    }
}
