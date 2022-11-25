using DesafioBackEnvelope.Domain;
using DesafioBackEnvelope.Domain.Interfaces;


namespace DesafioBackEnvelope.Infra.Data.Repositories
{
    public sealed class EnvelopeRepository : BaseRepository<DadosEnvelope>, IEnvelopeRepository
    {
        public EnvelopeRepository(ApplicationDbContext dbContext)
        {
            _Db = dbContext;
        }

    }
}
