using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Mappings;

namespace Movies.Application
{
    public static class ApplicationExtensions
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Mediatr config and DI
            services.AddMediatR(cf => { cf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); });



            // Mapster configuration and DI

            MappingConfig.Configure();
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            return services;
        }
    }
}
