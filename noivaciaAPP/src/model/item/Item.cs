namespace NoivaCiaApp.model
{
    public class Item: Model
    {
        public override int Id { get;set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public TipoFesta TipoFesta { get; set; }
        public ItemTipoEnum TipoItem { get; set; }
        public TipoServico? TipoServico { get; set; } = null;

        public int QuantidadeDoItem { get; set; }

        public Item(string Name, float Value, TipoFesta TipoFesta, ItemTipoEnum TipoItem)
        {
            this.Name = Name;
            this.Price = Value;
            this.TipoFesta = TipoFesta;
            this.TipoItem = TipoItem;
        }

        public Item(int Id, string Name, float Value, TipoFesta TipoFesta, ItemTipoEnum TipoItem, TipoServico? TipoServico)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Value;
            this.TipoFesta = TipoFesta;
            this.TipoItem = TipoItem;
            this.TipoServico = TipoServico;
        }

        public Item(string Name, float Value, TipoFesta TipoFesta, ItemTipoEnum TipoItem, TipoServico TipoServico)
        {
            this.Name = Name;
            this.Price = Value;
            this.TipoFesta = TipoFesta;
            this.TipoItem = TipoItem;
            this.TipoServico = TipoServico;
        }

        public Item(Item Item)
        {
            this.Id = Item.Id;
            this.Name = Item.Name;
            this.Price = Item.Price;
            this.TipoFesta = Item.TipoFesta;
            this.TipoItem = Item.TipoItem;
            this.TipoServico = Item.TipoServico;
        }
    }
}
