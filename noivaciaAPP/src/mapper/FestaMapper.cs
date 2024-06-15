using noivaCiaApp.entity;
using NoivaCiaApp.entity;
using NoivaCiaApp.model;

namespace NoivaCiaApp.mapper
{
    public class FestaMapper : IMapper<Festa, FestaEntity>
    {
        FestaEntity IMapper<Festa, FestaEntity>.MapToEntity(Festa item)
        {
            return new(){
                Tipo = (int)item.Locacao.Espaco.Tipo,
                EspacoId = item.Locacao.Espaco.Id,
                Day = item.Locacao.Date.Day,
                Month = item.Locacao.Date.Month,
                Year = item.Locacao.Date.Year
            };
        }

        Festa IMapper<Festa, FestaEntity>.MapToModel(FestaEntity item)
        {
            throw new NotImplementedException();
        }
    }
}