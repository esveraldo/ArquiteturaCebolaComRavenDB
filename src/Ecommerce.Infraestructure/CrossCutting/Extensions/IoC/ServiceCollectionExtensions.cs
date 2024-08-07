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
    }
}
