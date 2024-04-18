using System.Diagnostics;

class GerenciadorEspaco {
    private List<Espaco> Lista_espacos {get; set;}
    private Calendario Calendario;
    public GerenciadorEspaco() {
        Lista_espacos = new List<Espaco>(){
            new Espaco("g", 50,  8000  , EspacoTipoEnum.MAX50 ),
            new Espaco("a", 100, 10000 , EspacoTipoEnum.MAX100),
            new Espaco("b", 100, 10000 , EspacoTipoEnum.MAX100),
            new Espaco("c", 100, 10000 , EspacoTipoEnum.MAX100),
            new Espaco("d", 100, 10000 , EspacoTipoEnum.MAX100),
            new Espaco("e", 200, 17000 , EspacoTipoEnum.MAX200),
            new Espaco("f", 200, 17000 , EspacoTipoEnum.MAX200),
            new Espaco("h", 500, 35000 , EspacoTipoEnum.MAX500),
        };

        Lista_espacos[1].Datas_Locadas.Add(DateTime.Today.AddDays(30));
        Lista_espacos[2].Datas_Locadas.Add(DateTime.Today.AddDays(30));
        Calendario = new Calendario(); 
    }

    private List<Espaco> EncontrarEspacos(int qntConvidados) {
        Espaco? espacoComCapacidade = Lista_espacos.Find(espaco => espaco.CapacidadeMax >= qntConvidados && qntConvidados > 0);
        return Lista_espacos.FindAll(espaco => espacoComCapacidade?.Tipo == espaco.Tipo);
    }

    public Espaco ReservarEspaco(int qntConvidados){
        List<Espaco> espacosComCapacidade = EncontrarEspacos(qntConvidados);
        DateTime possivelData = Calendario.Prox_date();
        int i=0;

        while(true) {
            var espaco = espacosComCapacidade[i % espacosComCapacidade.Count];
            bool espacoLocado = espaco.Datas_Locadas.Any(data => data == possivelData);

            if(!espacoLocado){
                espaco.Datas_Locadas.Add(possivelData);
                espaco.qntConvidados =qntConvidados;
                return espaco;
            } else {
                if(i % espacosComCapacidade.Count == 0 && i != 0){
                    possivelData = Calendario.Prox_date(possivelData); 
                }
                i++;
            }
        }
    }
}