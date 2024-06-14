using NoivaCiaApp.model;
using NoivaPoo;

class GerenciadorCasamento
{
    public static void MarcarCasamento(){
        Espaco espaco =pegarEspaco();
        CasamentoTipoEnum tipoCasamento= PegarTipoCasamento();
        List<ItemCasamento> listaConformeTipoCasamento = PegarListaCasamento(tipoCasamento);
        Casamento casamento= new Casamento(espaco, tipoCasamento, listaConformeTipoCasamento);
    }
    public static Espaco pegarEspaco(){
        Console.WriteLine("Quantas Pessoas Vão ao seu Casamento?");
        int qtdPessoas = int.Parse(Console.ReadLine() ?? "0");
        GerenciadorEspaco gerenciadorEspaco= new GerenciadorEspaco();
        Espaco espaco = gerenciadorEspaco.ReservarEspaco(qtdPessoas);
        return espaco;
    }

    public static CasamentoTipoEnum PegarTipoCasamento(){
        CasamentoTipoEnum Tipo;
        Console.WriteLine("Qual o tipo do seu Casamento?");
        int op = 0;
        do{
            op = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("1 - STANDART");
            Console.WriteLine("2 - LUXO");
            Console.WriteLine("3 - PREMIER");
            if(op == 1){
                Tipo = CasamentoTipoEnum.STANDART;
                return Tipo;
            }
            else if(op == 2){
                Tipo = CasamentoTipoEnum.LUXO;
                return Tipo;
            }
            else if(op == 3){
                Tipo = CasamentoTipoEnum.PREMIER;
                return Tipo;
            }
        }while (op != 1 || op != 2 ||op != 3);
        return CasamentoTipoEnum.STANDART;
    }
    
    public static List<ItemCasamento> PegarListaCasamento(CasamentoTipoEnum TipoCasamento){
        GerenciadorDeItem items = new GerenciadorDeItem();
        List<ItemCasamento> Lista = new List<ItemCasamento>();
        if(TipoCasamento == CasamentoTipoEnum.STANDART){
            Lista = items.getStandartList();
        }
        else if(TipoCasamento == CasamentoTipoEnum.LUXO){
             Lista = items.getLuxoList();
        }
        else if(TipoCasamento == CasamentoTipoEnum.PREMIER){
             Lista = items.getPremierList();
        }
        return Lista;
    }
}