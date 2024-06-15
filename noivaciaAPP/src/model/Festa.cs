namespace NoivaCiaApp.model
{
    public class Festa : Model
    {
        public CasamentoTipoEnum TipoFesta { get; set; }
        public Locacao Locacao { get; set; }
        public List<ItemCasamento> ItemsObrigatorios { get; set; }
        public List<ItemComQuantidade> ItemsSelecionaveis { get; set; }

        public Festa(
            CasamentoTipoEnum TipoFesta,
            Locacao Locacao,
            List<ItemCasamento> ItemsObrigatorios,
            List<ItemComQuantidade> ItemsSelecionaveis
        )
        {
            this.TipoFesta = TipoFesta;
            this.Locacao = Locacao;
            this.ItemsObrigatorios = ItemsObrigatorios;
            this.ItemsSelecionaveis = ItemsSelecionaveis;
        }
    }
}