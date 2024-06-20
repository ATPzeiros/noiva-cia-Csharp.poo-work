using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

namespace NoivaCiaApp.repository
{
    public class FestaRepository
    {

        private readonly IMapper<Casamento, FestaEntity> mapper;
        private readonly IDatabase database;

        public FestaRepository(
            IMapper<Casamento, FestaEntity> mapper, 
            IDatabase database
        ) {
            this.mapper = mapper;
            this.database = database;
        }

        public List<Casamento> GetCasamentoPorTipo(EventoTipoEnum tipo)
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
        public bool SaveCasamento(Casamento casamento){
            List<Casamento> a = new List<Casamento>
            {
                casamento
            };
            database.SaveEntities(a.Select(mapper.MapToEntity).ToList());
            return true;
        }
    }
}
