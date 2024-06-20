using NoivaCiaApp.model;

public class Casamento : Model {
    public int Id { get; set;}
    public Espaco EspacoCasamento {get; set;}
    public TipoEventoEnum TipoCasamento {get;set;}

    public List<ItemFesta> ItemsDoCasamento {get; set;}

    public float PrecoFinalCasamento {get;set;}

    public Casamento(Espaco EspacoCasamento, TipoEventoEnum TipoCasamento, List<ItemFesta> lista){
        this.EspacoCasamento = EspacoCasamento;
        this.TipoCasamento = TipoCasamento;
        preencherListaCasamento(TipoCasamento);
    }

    public double ValorTotalCasamento(){
        List<ItemFesta> listaBasico = ItemsDoCasamento.FindAll(item =>item?.TipoItem == ItemTipoEnum.BASICO);
        foreach (var item in listaBasico){
             PrecoFinalCasamento += item.Price * EspacoCasamento.CapacidadeMax;
        } 
        List<ItemFesta> listaBebidas = ItemsDoCasamento.FindAll(item =>item?.TipoItem == ItemTipoEnum.BEBIDA);
         foreach (var item in listaBebidas){
             PrecoFinalCasamento += item.Price * item.QuantidadeDoItem;
        }  
         List<ItemFesta> listaComidas= ItemsDoCasamento.FindAll(item =>item?.TipoItem == ItemTipoEnum.COMIDA);
         foreach (var item in listaComidas){
             PrecoFinalCasamento += item.Price * EspacoCasamento.qntConvidados;
        }

        PrecoFinalCasamento += EspacoCasamento.Valor;
        return PrecoFinalCasamento;
    }
    private void preencherListaCasamento(TipoEventoEnum tipo){
        // ItemsDoCasamento = GerenciadorEvento.GetListaCasamento(tipo);

        // foreach(var i in ItemsDoCasamento){
        //     if(i.TipoItem == ItemTipoEnum.BASICO){
        //          i.QuantidadeDoItem=EspacoCasamento.CapacidadeMax;
        //     }
        //     else if(i.TipoItem == ItemTipoEnum.COMIDA){
        //          i.QuantidadeDoItem=EspacoCasamento.qntConvidados;
        //     }
        //     else if(i.TipoItem == ItemTipoEnum.BEBIDA){
        //          Console.WriteLine("Escolha A quantidade dos seguintes items");
        //          Console.WriteLine(i.Name);
        //          i.QuantidadeDoItem=int.Parse(Console.ReadLine() ?? "0");
        //     }
        // }
    }

    // public double ValorTotalCasamento(){
        // List<ItemCasamento> listaBasico = ItemsDoCasamento.FindAll(item =>item?.TipoItem == ItemTipoEnum.BASICO);
        // foreach (var item in listaBasico){
        //      PrecoFinalCasamento += item.Price * EspacoCasamento.CapacidadeMax;
        // } 
        // List<ItemFesta> listaBebidas = ItemsDoCasamento.FindAll(item =>item?.TipoItem == ItemTipoEnum.BEBIDA);
        //  foreach (var item in listaBebidas){
        //      PrecoFinalCasamento += item.Price * item.QuantidadeDoItem;
        // }  
        //  List<ItemFesta> listaComidas= ItemsDoCasamento.FindAll(item =>item?.TipoItem == ItemTipoEnum.COMIDA);
        //  foreach (var item in listaComidas){
        //      PrecoFinalCasamento += item.Price * EspacoCasamento.qntConvidados;
        // }

        // PrecoFinalCasamento += EspacoCasamento.Valor;
        // return 0.0;
    // }
}