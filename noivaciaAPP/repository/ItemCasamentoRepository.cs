using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

namespace NoivaCiaApp.repository
{
    public class ItemCasamentoRepository
    {

        private readonly IMapper<ItemCasamento, ItemFestaEntity> mapper;
        private readonly IDatabase database;

        public ItemCasamentoRepository(
            IMapper<ItemCasamento, ItemFestaEntity> mapper, 
            IDatabase database
        ) {
            this.mapper = mapper;
            this.database = database;
        }

        public List<ItemCasamento> GetItemCasamentoPorTipo(CasamentoTipoEnum tipo)
        {
            try
            {
                return database
                    .GetEntities<ItemFestaEntity>()
                    .Where(item => item.TipoCasamento == (int)tipo)
                    .Select(item => mapper?.MapToModel(item))
                    .OfType<ItemCasamento>()
                    .ToList();
            }
            catch
            {
                return new List<ItemCasamento>();
            }
        }
    }
}
