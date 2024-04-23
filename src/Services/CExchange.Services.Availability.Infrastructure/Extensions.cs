using CExchange.Services.Availability.Core.Repositories;
using CExchange.Services.Availability.Infrastructure.Mongo.Documents;
using CExchange.Services.Availability.Infrastructure.Mongo.Repositories;
using Convey;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace CExchange.Services.Availability.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<IResourcesRepository, ResourcesMongoRepository>();
            builder.AddMongo();
            builder.AddMongoRepository<ResourceDocument, Guid>("resources");
            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler();
            app.UseConvey();

            return app;
        }
    }   
}
