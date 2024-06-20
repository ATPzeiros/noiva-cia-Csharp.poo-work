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
        public bool SaveFesta(Festa festa, float valorTotal){
            var entity = mapper.MapToEntity(festa);
            entity.Valor = valorTotal;
            entity.Data = festa.Espaco.Data;
            return database.SaveEntity(entity) > 0;
        }
    }
}
