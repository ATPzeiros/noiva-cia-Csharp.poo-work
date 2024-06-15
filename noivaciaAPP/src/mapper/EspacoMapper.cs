using noivaCiaApp.entity;
using NoivaCiaApp.entity;
using NoivaCiaApp.model;

namespace NoivaCiaApp.mapper
{
    public class EspacoMapper : IMapper<NewEspaco, EspacoEntity>
    {
        EspacoEntity IMapper<NewEspaco, EspacoEntity>.MapToEntity(NewEspaco item)
        {
            throw new NotImplementedException();
        }

        NewEspaco IMapper<NewEspaco, EspacoEntity>.MapToModel(EspacoEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
