using NoivaCiaApp.model;
using NoivaCiaApp.repository;

class GerenciadorEvento
{
    static FestaRepository repository = RepositoryInjector.CreateFestaRepository();
    
    public static void MarcarEvento(){
        Espaco espacoEvento = ObterEspaço();
        EventoTipoEnum tipoEvento = ObterTipoEvento();
        Casamento casamento = new Casamento(espacoEvento, tipoEvento);
        repository.SaveCasamento(casamento);
    }
    public static Espaco ObterEspaço(){
        GerenciadorEspaco gerenciadorEspaco = new GerenciadorEspaco();

        Console.Write("Quantidade de convidados: ");
        int quantidadeConvidados = int.Parse(Console.ReadLine() ?? "0");
        Espaco espaco = gerenciadorEspaco.ReservarEspaco(quantidadeConvidados);

        return espaco;
    }

    public static EventoTipoEnum ObterTipoEvento(){
        EventoTipoEnum tipoEventoEscolhido = EventoTipoEnum.STANDART;
        
        int opcao = 0;
        do
        {
            Console.Write("Tipos evento: ");
            Console.WriteLine("1 - STANDART");
            Console.WriteLine("\t      2 - LUXO");
            Console.WriteLine("\t      3 - PREMIER");
            Console.Write("-> ");
            opcao = int.Parse(Console.ReadLine() ?? "0");

            switch (opcao) {
                case 1: 
                    tipoEventoEscolhido = EventoTipoEnum.STANDART;
                    break;
                case 2: 
                    tipoEventoEscolhido = EventoTipoEnum.LUXO;
                    break;
                case 3: 
                    tipoEventoEscolhido = EventoTipoEnum.PREMIER;
                    break;
            }
            return tipoEventoEscolhido;
        }
        while (opcao != 1 || opcao != 2 || opcao != 3);

    }
    
    public static List<ItemCasamento> GetListaCasamento(EventoTipoEnum TipoEvento){
        GerenciadorDeItem items = new GerenciadorDeItem();
        List<ItemCasamento> List = new List<ItemCasamento>();
        if(TipoEvento == EventoTipoEnum.STANDART){
            List = items.getStandartList();
        }
        else if(TipoEvento == EventoTipoEnum.LUXO){
             List = items.getLuxoList();
        }
        else if(TipoEvento == EventoTipoEnum.PREMIER){
             List = items.getPremierList();
        }
        return List;
    }
}