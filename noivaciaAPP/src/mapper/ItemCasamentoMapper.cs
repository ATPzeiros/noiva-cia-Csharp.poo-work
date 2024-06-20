using NoivaCiaApp.entity;
using NoivaCiaApp.model;

namespace NoivaCiaApp.mapper
{
    public class ItemCasamentoMapper : IMapper<ItemFesta, ItemFestaEntity>
    {
        public ItemFesta MapToModel(ItemFestaEntity entity)
        {
            return new ItemFesta(
                Id: entity.Id,
                Name: entity.Name ?? "",
                Value: entity.Value,
                TipoCasamento: (TipoEventoEnum)entity.TipoCasamento,
                TipoItem: (ItemTipoEnum)entity.TipoItem
            );
        }

        public ItemFestaEntity MapToEntity(ItemFesta itemCasamento)
        {
            return new()
            {
                Id = itemCasamento.Id,
                Name = itemCasamento.Name,
                Value = itemCasamento.Price,
                TipoCasamento = (int)itemCasamento.TipoCasamento,
                TipoItem = (int)itemCasamento.TipoItem
            };
        }
    }
}

