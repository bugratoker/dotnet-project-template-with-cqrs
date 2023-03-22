using Microsoft.Extensions.DependencyInjection;


namespace SoftwareLab.Core.DI
{
    public static class ServiceRegistration
    {

        public static void AddApplicationCore(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            { cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly);
            });



        }

    }
}
