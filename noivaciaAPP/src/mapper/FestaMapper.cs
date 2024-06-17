using System.Security.AccessControl;
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
                Tipo = (int)(item?.Espaco?.Tipo ?? 0),
                EspacoId = item?.Espaco?.Id ?? 0,
                Categoria = (int)(item?.CategoriaFesta ?? 0),
                QntConvidados = item?.QntConvidados ?? 0,
                Day = item?.Date?.Day ?? 0,
                Month = item?.Date?.Month ?? 0,
                Year = item?.Date?.Year ?? 0
            };
        }

        Festa IMapper<Festa, FestaEntity>.MapToModel(FestaEntity item)
        {
            throw new NotImplementedException();
        }
    }
}