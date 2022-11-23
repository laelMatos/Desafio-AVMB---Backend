using DesafioBackEnvelope.Domain;
using Microsoft.EntityFrameworkCore;


namespace DesafioBackEnvelope.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DadosEnvelope> Envelopes { get; set; }

    }   
}
