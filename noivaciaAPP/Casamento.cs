public class Casamento  {
    public Espaco EspacoCasamento {get; set;}
    public CasamentoTipoEnum TipoCasamento {get;set;}

    public List<ItemCasamento> ItemsDoCasamento {get; set;}

    public static  double PrecoFinalCasamento {get;set;}
    public Casamento(Espaco EspacoCasamento, CasamentoTipoEnum TipoCasamento, List<ItemCasamento> lista){
        this.EspacoCasamento = EspacoCasamento;
        this.TipoCasamento = TipoCasamento;
        ItemsDoCasamento = lista;
    }

    public double ValorTotalCasamento(){
        List<ItemCasamento> listaBasico = ItemsDoCasamento.FindAll(item =>item?.TipoItem == ItemTipoEnum.BASICO);
        foreach (var item in listaBasico){
             PrecoFinalCasamento += item.Value * EspacoCasamento.CapacidadeMax;
        }   
        List<ItemCasamento> listaBebidas = ItemsDoCasamento.FindAll(item =>item?.TipoItem == ItemTipoEnum.BEBIDA);
         foreach (var item in listaBebidas){
             PrecoFinalCasamento += item.Value * EspacoCasamento.qntConvidados;
        }  
        PrecoFinalCasamento += EspacoCasamento.Valor;
        return PrecoFinalCasamento;
    }
}