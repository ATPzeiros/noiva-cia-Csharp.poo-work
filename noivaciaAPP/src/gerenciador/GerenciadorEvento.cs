using NoivaCiaApp.model;
using NoivaCiaApp.repository;
using SQLitePCL;

class GerenciadorEvento
{

    private readonly FestaRepository repository;
    private readonly IRelatorio relatorio;
    public GerenciadorEvento(FestaRepository repository, IRelatorio relatorio){
        this.repository = repository;
        this.relatorio = relatorio;
    }

    public bool MarcarEvento(Festa festa)
    {
        return repository.SaveCasamento(festa);

        
        // Espaco espacoEvento = ObterEspaço();
        // EventoTipoEnum tipoEvento = ObterTipoEvento();
        // var listaConformeTipoEvento = GetListaCasamento(tipoEvento);

        // Casamento casamento = new Casamento(espacoEvento, tipoEvento, listaConformeTipoEvento);
    }

    public void GerarResumo(
        Festa festa
    ){
        relatorio.GerarRelatorio(festa);
    }

    public float ValorTotalCasamento(Espaco? espaco, TipoCategoria categoria, TipoEventoEnum tipoEvento){
        float valorTotal = espaco.Valor;
        // valorTotal += 
        return 0f;
    }
    // public Espaco ObterEspaço(){
    //     GerenciadorEspaco gerenciadorEspaco = new GerenciadorEspaco();

    //     Console.Write("Quantidade de convidados: ");
    //     int quantidadeConvidados = int.Parse(Console.ReadLine() ?? "0");
    //     Espaco espaco = gerenciadorEspaco.ReservarEspaco(quantidadeConvidados);

    //     return espaco;
    // }

    public TipoEventoEnum ObterTipoEvento(){
        TipoEventoEnum tipoEventoEscolhido = TipoEventoEnum.STANDART;
        
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
                    tipoEventoEscolhido = TipoEventoEnum.STANDART;
                    break;
                case 2: 
                    tipoEventoEscolhido = TipoEventoEnum.LUXO;
                    break;
                case 3: 
                    tipoEventoEscolhido = TipoEventoEnum.PREMIER;
                    break;
            }
            return tipoEventoEscolhido;
        }
        while (opcao != 1 || opcao != 2 || opcao != 3);

    }
    
    // public List<ItemCasamento> GetListaCasamento(EventoTipoEnum TipoEvento){
    //     GerenciadorDeItem items = new GerenciadorDeItem();
    //     List<ItemCasamento> List = new List<ItemCasamento>();
    //     if(TipoEvento == EventoTipoEnum.STANDART){
    //         List = items.getStandartList();
    //     }
    //     else if(TipoEvento == EventoTipoEnum.LUXO){
    //          List = items.getLuxoList();
    //     }
    //     else if(TipoEvento == EventoTipoEnum.PREMIER){
    //          List = items.getPremierList();
    //     }
    //     return List;
    // }

    public void ExcluirEventoPorData(){

    }
}