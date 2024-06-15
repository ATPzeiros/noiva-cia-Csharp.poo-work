using NoivaCiaApp.model;

namespace NoivaCiaApp.repository
{
    public class EspacoRepository
    {
        public bool EspacoLocado(DateTime date){
            return false;
        }

        public bool SalvarLocacao(Locacao locacao){
            return true;
        }

        public List<NewEspaco> GetEspacos()
        {
            return new List<NewEspaco>(){
                new("g", 50,  8000  , EspacoTipoEnum.MAX50 ),
                new("a", 100, 10000 , EspacoTipoEnum.MAX100),
                new("b", 100, 10000 , EspacoTipoEnum.MAX100),
                new("c", 100, 10000 , EspacoTipoEnum.MAX100),
                new("d", 100, 10000 , EspacoTipoEnum.MAX100),
                new("e", 200, 17000 , EspacoTipoEnum.MAX200),
                new("f", 200, 17000 , EspacoTipoEnum.MAX200),
                new("h", 500, 35000 , EspacoTipoEnum.MAX500),
            };
        }
    }
}