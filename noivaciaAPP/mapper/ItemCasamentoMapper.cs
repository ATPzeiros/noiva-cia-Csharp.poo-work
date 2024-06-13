using NoivaPoo;

class ItemCasamentoMapper : IMapper<ItemCasamento, ItemFestaEntity>
{
    public ItemCasamento MapToModel(ItemFestaEntity entity)
    {
        return new ItemCasamento(
            Id: entity.Id,
            Name: entity.Name ?? "",
            Value: entity.Value,
            TipoCasamento: (CasamentoTipoEnum)entity.TipoCasamento,
            TipoItem: (ItemTipoEnum)entity.TipoItem
        );
    }

    public ItemFestaEntity MapToEntity(ItemCasamento itemCasamento)
    {
        return new()
        {
            Name = itemCasamento.Name,
            Value = itemCasamento.Price,
            TipoCasamento = (int)itemCasamento.TipoCasamento,
            TipoItem = (int)itemCasamento.TipoItem
        };
    }
}
