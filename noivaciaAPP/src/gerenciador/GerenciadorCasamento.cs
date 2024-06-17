using NoivaCiaApp.model;

class GerenciadorCasamento
{
    public static void MarcarCasamento(){
        Espaco espaco =pegarEspaco();
        TipoFesta tipoCasamento= PegarTipoFesta();
        List<Item> listaConformeTipoFesta = PegarListaCasamento(tipoCasamento);
        Casamento casamento= new Casamento(espaco, tipoCasamento, listaConformeTipoFesta);
    }
    public static Espaco pegarEspaco(){
        Console.WriteLine("Quantas Pessoas Vão ao seu Casamento?");
        int qtdPessoas = int.Parse(Console.ReadLine() ?? "0");
        GerenciadorEspaco gerenciadorEspaco= new GerenciadorEspaco();
        Espaco espaco = gerenciadorEspaco.ReservarEspaco(qtdPessoas);
        return espaco;
    }

    public static TipoFesta PegarTipoFesta(){
        TipoFesta Tipo;
        Console.WriteLine("Qual o tipo do seu Casamento?");
        int op = 0;
        do{
            op = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("1 - STANDART");
            Console.WriteLine("2 - LUXO");
            Console.WriteLine("3 - PREMIER");
            if(op == 1){
                Tipo = TipoFesta.STANDART;
                return Tipo;
            }
            else if(op == 2){
                Tipo = TipoFesta.LUXO;
                return Tipo;
            }
            else if(op == 3){
                Tipo = TipoFesta.PREMIER;
                return Tipo;
            }
        }while (op != 1 || op != 2 ||op != 3);
        return TipoFesta.STANDART;
    }
    
    public static List<Item> PegarListaCasamento(TipoFesta TipoFesta){
        GerenciadorDeItem items = new GerenciadorDeItem(RepositoryInjector.CreateItemRepository());
        List<Item> Lista = new List<Item>();
        if(TipoFesta == TipoFesta.STANDART){
            Lista = items.getStandartList();
        }
        else if(TipoFesta == TipoFesta.LUXO){
             Lista = items.getLuxoList();
        }
        else if(TipoFesta == TipoFesta.PREMIER){
             Lista = items.getPremierList();
        }
        return Lista;
    }
}