using NoivaCiaApp.mapper;

class EspacoMapper : IMapper<Espaco, EspacoEntity>
{
    public EspacoEntity MapToEntity(Espaco item)
    {
        return new EspacoEntity(){
            Id = item.Id,
            Nome = item.Nome ?? "",
            CapacidadeMax = item.CapacidadeMax,
            Valor = item.Valor,
            Tipo = (int)item.Tipo,
        };
    }

    public Espaco MapToModel(EspacoEntity item)
    {
        return new Espaco(
            item.Id,
            item.Nome,
            item.CapacidadeMax,
            item.Valor,
            (EspacoTipoEnum)item.Tipo
        );
    }
}