using NoivaCiaApp.model;

public class ItemComQuantidade: Item{

    public int Quantidade {get;set;}

    public ItemComQuantidade(Item Item, int Quantidade): base(Item){
        this.Quantidade = Quantidade;
    }
}