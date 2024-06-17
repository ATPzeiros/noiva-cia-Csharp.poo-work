namespace NoivaCiaApp.model
{
    public class Festa : Model
    {
        public override int Id {get;set;}
        public TipoFesta? TipoFesta { get; set; } = null;
        public CategoriaFesta? CategoriaFesta { get; set; } = null;
        public NewEspaco? Espaco { get; set; } = null;
        public DateTime? Date { get; set; } = null;
        public List<Item> ItemsObrigatorios { get; set; } = new List<Item>();
        public List<ItemComQuantidade> ItemsSelecionaveis { get; set; } = new List<ItemComQuantidade>();
        public int? QntConvidados { get; set; } = 0;

        public Festa(
            TipoFesta TipoFesta,
            List<Item> ItemsObrigatorios,
            List<ItemComQuantidade> ItemsSelecionaveis
        )
        {
            this.TipoFesta = TipoFesta;
            this.ItemsObrigatorios = ItemsObrigatorios;
            this.ItemsSelecionaveis = ItemsSelecionaveis;
        }

        public Festa(){}

        public override string ToString()
        {
            return $"ID: {Id}\t";
        }
    }

}