using NoivaCiaApp.entity;
using NoivaCiaApp.model;

namespace NoivaCiaApp.mapper
{
    public class ItemMapper : IMapper<Item, ItemEntity>
    {
        public Item MapToModel(ItemEntity entity)
        {
            return new Item(
                Id: entity.Id,
                Name: entity.Name ?? "",
                Value: entity.Value,
                TipoFesta: (TipoFesta)entity.TipoFesta,
                TipoItem: (ItemTipoEnum)entity.TipoItem,
                TipoServico: (TipoServico?)entity?.TipoServico
            );
        }

        public ItemEntity MapToEntity(Item itemCasamento)
        {
            return new()
            {
                Id = itemCasamento.Id,
                Name = itemCasamento.Name,
                Value = itemCasamento.Price,
                TipoFesta = (int)itemCasamento.TipoFesta,
                TipoItem = (int)itemCasamento.TipoItem,
                TipoServico = (int?)itemCasamento?.TipoServico
            };
        }
    }
}

