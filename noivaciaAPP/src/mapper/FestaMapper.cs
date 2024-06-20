using System.CodeDom;
using NoivaCiaApp.mapper;

class FestaMapper : IMapper<Festa, FestaEntity>
{

    public FestaEntity MapToEntity(Festa festa)
    {
        return new FestaEntity(){
            Id = festa.Id,
            FkEspaco  = festa?.Espaco?.Id ?? 0,
            Categoria = (int)(festa?.Categoria ?? 0),
            TipoEvento  = (int)(festa?.Tipo ?? 0),
            Valor = 0f,
            QntConvidados = festa?.QuantidadeConvidados ?? 0,
            Data = festa?.Espaco?.Data,
        };
    }

    public Festa MapToModel(FestaEntity festa)
    {
        return new Festa(
            Id: festa.Id,
            Tipo: (TipoEventoEnum)festa.TipoEvento,
            Categoria: (TipoCategoria)festa.Categoria,
            QuantidadeConvidados: festa.QntConvidados,
            Date: festa.Data ?? DateTime.Now
        );
    }
}