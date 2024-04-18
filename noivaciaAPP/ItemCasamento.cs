public class ItemCasamento{

    public string Name {get;set;}
    public double Value {get;set;}
    public CasamentoTipoEnum TipoCasamento  {get;set;}
    public ItemTipoEnum TipoItem{get;set;}

    public ItemCasamento(string Name, double Value, CasamentoTipoEnum TipoCasamento, ItemTipoEnum TipoItem ){
        this.Name = Name;
        this.Value = Value;
        this.TipoCasamento = TipoCasamento;
        this.TipoItem = TipoItem;
    }

}