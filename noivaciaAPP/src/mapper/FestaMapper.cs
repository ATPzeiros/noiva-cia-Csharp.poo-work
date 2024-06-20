using System.CodeDom;
using NoivaCiaApp.mapper;

class FestaMapper : IMapper<Festa, FestaEntity>
{

    public FestaEntity MapToEntity(Festa festa)
    {
        return new FestaEntity(){
            Id = festa.Id,
            FkEspaco  = festa.Espaco.Id,
            Categoria = (int)festa.Categoria,
            TipoEvento  = (int)festa.Tipo,
            Valor = 0f,
            Data = new DateTime(),
        };
    }

    public Festa MapToModel(FestaEntity casamento)
    {
        throw new NotImplementedException();
    }
}