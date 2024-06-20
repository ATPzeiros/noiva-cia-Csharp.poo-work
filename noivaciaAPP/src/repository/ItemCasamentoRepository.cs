using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

namespace NoivaCiaApp.repository
{
    public class ItemCasamentoRepository
    {

        private readonly IMapper<ItemFesta, ItemFestaEntity> mapper;
        private readonly IDatabase database;

        public ItemCasamentoRepository(
            IMapper<ItemFesta, ItemFestaEntity> mapper, 
            IDatabase database
        ) {
            this.mapper = mapper;
            this.database = database;
        }

        public List<ItemFesta> GetItemCasamentoPorTipo(TipoEventoEnum tipo)
        {
            try
            {
                return database
                    .GetEntities<ItemFestaEntity>()
                    .Where(item => item.TipoCasamento == (int)tipo)
                    .Select(item => mapper?.MapToModel(item))
                    .OfType<ItemFesta>()
                    .ToList();
            }
            catch
            {
                return new List<ItemFesta>();
            }
        }
    }
}
