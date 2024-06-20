using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

namespace NoivaCiaApp.repository
{
    public class EspacoEventoRepository
    {
        private readonly IMapper<Espaco, EspacoFestaEntity> mapper;
        private readonly IDatabase database;

        public EspacoEventoRepository(
            IMapper<Espaco, EspacoFestaEntity> mapper, 
            IDatabase database
        ) {
            this.mapper = mapper;
            this.database = database;
        }

        public List<Espaco> GetEspacoEventoPorConvidados(int quantidadeConvidados)
        {
            try
            {
                return database
                    .GetEntities<EspacoFestaEntity>()
                    .Where(espaco => espaco.capacidadeMax >= quantidadeConvidados)
                    .Select(espaco => mapper?.MapToModel(espaco))
                    .OfType<Espaco>()
                    .ToList();
            }
            catch
            {
                return new List<Espaco>();
            }
        }
    }
}