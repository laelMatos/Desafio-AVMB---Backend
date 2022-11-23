using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DesafioBackEnvelope.Infra.Data;

namespace DesafioBackEnvelope.Test
{
    public class EnvelopeApiApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(Services=> {
                Services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));

                Services.AddDbContext<ApplicationDbContext>(op =>
                op.UseInMemoryDatabase("BaseTeste", root));
            });

            return base.CreateHost(builder);
        }
    }
}
