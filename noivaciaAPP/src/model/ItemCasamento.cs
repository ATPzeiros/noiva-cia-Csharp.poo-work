namespace NoivaCiaApp.model
{
    public class ItemCasamento: Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public CasamentoTipoEnum TipoCasamento { get; set; }
        public ItemTipoEnum TipoItem { get; set; }
        public TipoServico? TipoServico { get; set; } = null;

        public int QuantidadeDoItem { get; set; }

        public ItemCasamento(string Name, float Value, CasamentoTipoEnum TipoCasamento, ItemTipoEnum TipoItem)
        {
            this.Name = Name;
            this.Price = Value;
            this.TipoCasamento = TipoCasamento;
            this.TipoItem = TipoItem;
        }

        public ItemCasamento(int Id, string Name, float Value, CasamentoTipoEnum TipoCasamento, ItemTipoEnum TipoItem, TipoServico? TipoServico)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Value;
            this.TipoCasamento = TipoCasamento;
            this.TipoItem = TipoItem;
            this.TipoServico = TipoServico;
        }

        public ItemCasamento(string Name, float Value, CasamentoTipoEnum TipoCasamento, ItemTipoEnum TipoItem, TipoServico TipoServico)
        {
            this.Name = Name;
            this.Price = Value;
            this.TipoCasamento = TipoCasamento;
            this.TipoItem = TipoItem;
            this.TipoServico = TipoServico;
        }

        public ItemCasamento(ItemCasamento Item)
        {
            this.Name = Item.Name;
            this.Price = Item.Price;
            this.TipoCasamento = Item.TipoCasamento;
            this.TipoItem = Item.TipoItem;
            this.TipoServico = Item.TipoServico;
        }
    }
}
