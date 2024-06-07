using NoivaPoo;

public class Casamento  {
    public Espaco EspacoCasamento {get; set;}
    public CasamentoTipoEnum TipoCasamento {get;set;}

    public List<ItemCasamento> ItemsDoCasamento {get; set;}

    public static float PrecoFinalCasamento {get;set;}

    public Casamento(Espaco EspacoCasamento, CasamentoTipoEnum TipoCasamento, List<ItemCasamento> lista){
        this.EspacoCasamento = EspacoCasamento;
        this.TipoCasamento = TipoCasamento;
        ItemsDoCasamento = lista;
        foreach(var i in ItemsDoCasamento){
            if(i.TipoItem == ItemTipoEnum.BASICO){
                 i.QuantidadeDoItem=EspacoCasamento.CapacidadeMax;
            }
            else if(i.TipoItem == ItemTipoEnum.COMIDA){
                 i.QuantidadeDoItem=EspacoCasamento.qntConvidados;
            }
            else if(i.TipoItem == ItemTipoEnum.BEBIDA){
                 Console.WriteLine("Escolha A quantidade dos seguintes items");
                 Console.WriteLine(i.Name);
                 i.QuantidadeDoItem=int.Parse(Console.ReadLine() ?? "0");
            }
        }
    }

    public double ValorTotalCasamento(){
        List<ItemCasamento> listaBasico = ItemsDoCasamento.FindAll(item =>item?.TipoItem == ItemTipoEnum.BASICO);
        foreach (var item in listaBasico){
             PrecoFinalCasamento += item.Price * EspacoCasamento.CapacidadeMax;
        } 
        List<ItemCasamento> listaBebidas = ItemsDoCasamento.FindAll(item =>item?.TipoItem == ItemTipoEnum.BEBIDA);
         foreach (var item in listaBebidas){
             PrecoFinalCasamento += item.Price * item.QuantidadeDoItem;
        }  
         List<ItemCasamento> listaComidas= ItemsDoCasamento.FindAll(item =>item?.TipoItem == ItemTipoEnum.COMIDA);
         foreach (var item in listaComidas){
             PrecoFinalCasamento += item.Price * EspacoCasamento.qntConvidados;
        }

        PrecoFinalCasamento += EspacoCasamento.Valor;
        return PrecoFinalCasamento;
    }
}