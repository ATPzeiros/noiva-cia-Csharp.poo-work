namespace NoivaCiaApp.model
{
    public class ItemCasamento: Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public EventoTipoEnum TipoCasamento { get; set; }
        public ItemTipoEnum TipoItem { get; set; }

        public int QuantidadeDoItem { get; set; }

        public ItemCasamento(string Name, float Value, EventoTipoEnum TipoCasamento, ItemTipoEnum TipoItem)
        {
            this.Name = Name;
            this.Price = Value;
            this.TipoCasamento = TipoCasamento;
            this.TipoItem = TipoItem;
        }

        public ItemCasamento(int Id, string Name, float Value, EventoTipoEnum TipoCasamento, ItemTipoEnum TipoItem)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Value;
            this.TipoCasamento = TipoCasamento;
            this.TipoItem = TipoItem;
        }

    }
}
