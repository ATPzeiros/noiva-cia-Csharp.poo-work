using NoivaCiaApp.model;

public class ItemComQuantidade: ItemCasamento{

    public int Quantidade {get;set;}

    public ItemComQuantidade(ItemCasamento Item, int Quantidade): base(Item){
        this.Quantidade = Quantidade;
    }
}