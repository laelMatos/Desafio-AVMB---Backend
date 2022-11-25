using DesafioBackEnvelope.Application.Interfaces;
using DesafioBackEnvelope.Application.Services;
using DesafioBackEnvelope.Domain.Interfaces;
using DesafioBackEnvelope.Infra.Data;
using DesafioBackEnvelope.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DesafioBackEnvelope.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddControllersWithViews(options => {
                //Define o modelo de retorno para o filtro de validações
                options.Filters.Add<ValidateModelStateFilter>(int.MinValue);
            });

            //Serviço de notificações
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();

            #region Repositories

            // Envelopes                      
            services.AddScoped<IEnvelopeRepository, EnvelopeRepository>();

            #endregion


            #region Services

            // Envelopes      
            services.AddScoped<IEnvelopeService, EnvelopeService>();
        
            #endregion

            return services;
        }
    }
}
