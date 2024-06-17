using noivaCiaApp.entity;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

namespace NoivaCiaApp.repository
{
    public class EspacoRepository
    {

        private readonly IDatabase database;

        public EspacoRepository(IDatabase database){
            this.database = database;
        }

        public bool EspacoLocado(int espacoId, DateTime date){
            return database.GetEntities<FestaEntity>().Where(festa =>
                festa.EspacoId == espacoId &&
                date.Day == festa?.Day &&
                date.Month == festa?.Month &&
                date.Year == festa?.Year
            ).Any();
        }

        public bool SalvarLocacao(Locacao locacao){
            return true;
        }

        public List<NewEspaco> GetEspacos()
        {
            return new List<NewEspaco>(){
                new(1, "g", 50,  8000  , EspacoTipoEnum.MAX50 ),
                new(2, "a", 100, 10000 , EspacoTipoEnum.MAX100),
                new(3, "b", 100, 10000 , EspacoTipoEnum.MAX100),
                new(4, "c", 100, 10000 , EspacoTipoEnum.MAX100),
                new(5, "d", 100, 10000 , EspacoTipoEnum.MAX100),
                new(6, "e", 200, 17000 , EspacoTipoEnum.MAX200),
                new(7, "f", 200, 17000 , EspacoTipoEnum.MAX200),
                new(8, "h", 500, 35000 , EspacoTipoEnum.MAX500),
            };
        }
    }
}