using Microsoft.Extensions.DependencyInjection;
using SoftwareLab.Infrastructure.Services;
using SoftwareLab.Core.Services;
using SoftwareLab.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using SoftwareLab.Core.Repositories;
using SoftwareLab.Infrastructure.Repositories;

namespace SoftwareLab.Infrastructure.DI
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services) {


            services.AddScoped<IEmailService,EmailService>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("SoftwareLab0320"));
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient(typeof(IGenericRepository<>)
                                 , typeof(GenericRepository<>));

        }
    }
}
