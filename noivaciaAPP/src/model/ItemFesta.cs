namespace NoivaCiaApp.model
{
    public class ItemFesta: Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public TipoEventoEnum TipoCasamento { get; set; }
        public ItemTipoEnum TipoItem { get; set; }
        public int QuantidadeDoItem { get; set; }

        public ItemFesta(string Name, float Value, TipoEventoEnum TipoCasamento, ItemTipoEnum TipoItem)
        {
            this.Name = Name;
            this.Price = Value;
            this.TipoCasamento = TipoCasamento;
            this.TipoItem = TipoItem;
        }

        public ItemFesta(int Id, string Name, float Value, TipoEventoEnum TipoCasamento, ItemTipoEnum TipoItem)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Value;
            this.TipoCasamento = TipoCasamento;
            this.TipoItem = TipoItem;
        }

    }
}
