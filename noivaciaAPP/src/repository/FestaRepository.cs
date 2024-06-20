using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

namespace NoivaCiaApp.repository
{
    public class FestaRepository
    {

        private readonly IMapper<Festa, FestaEntity> mapper;
        private readonly IDatabase database;

        public FestaRepository(
            IMapper<Festa, FestaEntity> mapper, 
            IDatabase database
        ) {
            this.mapper = mapper;
            this.database = database;
        }

        public List<Casamento> GetCasamentoPorTipo(TipoEventoEnum tipo)
        {
            try
            {
                return database
                    .GetEntities<FestaEntity>()
                    .Where(item => item.Categoria == (int)tipo)
                    .Select(item => mapper?.MapToModel(item))
                    .OfType<Casamento>()
                    .ToList();
            }
            catch
            {
                return new List<Casamento>();
            }
        }
        public bool SaveCasamento(Festa festa){
            return database.SaveEntity(mapper.MapToEntity(festa)) > 0;
        }
    }
}
