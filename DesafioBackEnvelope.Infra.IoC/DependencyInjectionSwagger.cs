using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace DesafioBackEnvelope.Infra.IoC
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchMvc.API", Version = "v1" });

                //options.SchemaFilter<EnumSchemaFilter>();

                //Adiciona autenticação para usar dento do Swagger
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    //definir configuracoes
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Autorização JWT usando o esquema Bearer. " +
                    "\r\n\r\n Digite 'Bearer' [espaço] e, em seguida, seu token na entrada de texto abaixo." +
                    "\r\n\r\nExemplo: \"Bearer 12345abcdef\"",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                      {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
                //Usar documentação no swagger
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "DesafioBackEnvelope.API.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "DesafioBackEnvelope.Application.xml"));
            });
            return services;
        }
    }
}
