using noivaCiaApp.gerenciador;
using NoivaCiaApp.model;

class FestaController
{
    private readonly NewGerenciadorEspaco gEspaco;
    private readonly NewGerenciadorItems gItem;
    private readonly GerenciadorFesta gFesta;

    public Festa Festa { get; } = new Festa();

    public FestaController(
        NewGerenciadorEspaco gEspaco,
        NewGerenciadorItems gItem,
        GerenciadorFesta gFesta
    )
    {
        this.gEspaco = gEspaco;
        this.gItem = gItem;
        this.gFesta = gFesta;
    }

    public void FazerReserva()
    {
        gFesta.AgendarFesta(Festa);
    }

    public List<Item> GetItemsServicoBasico(
        CategoriaFesta categoria,
        TipoFesta tipo
    )
    {
        return gItem.GetItemsServicoBasico(ItemTipoEnum.BASICO, categoria, tipo);
    }

    public List<Item> GetItemsComida(TipoFesta tipo)
    {
        return gItem.GetItemsFestaPorTipo(ItemTipoEnum.COMIDA, tipo);
    }

    public List<Item> GetItemsBebida()
    {
        if (Festa.TipoFesta.HasValue)
        {
            return gItem.GetItemsFestaPorTipo(ItemTipoEnum.BEBIDA, Festa.TipoFesta.Value);
        }
        else
        {
            return new List<Item>();
        }
    }

    public void AtualizarQntPessoas(int qntPessoas)
    {
        Festa.QntConvidados = qntPessoas;
    }

    public void AtualizarTipoFesta(TipoFesta casamentoTipoEnum)
    {
        Festa.TipoFesta = casamentoTipoEnum;
    }

    public void AtualizarCategoria(CategoriaFesta categoriaFesta)
    {
        Festa.CategoriaFesta = categoriaFesta;
    }

    public void AtualizarBebidas(List<ItemComQuantidade> bebidas)
    {
        Festa.ItemsSelecionaveis = bebidas;
    }

    public void ConstruirFesta(){
        if(Festa.CategoriaFesta.HasValue && Festa.TipoFesta.HasValue){
            //Atualizando servico basico
            Festa.ItemsObrigatorios = gItem.GetItemsServicoBasico(
                ItemTipoEnum.BASICO,
                Festa.CategoriaFesta.Value, 
                Festa.TipoFesta.Value
            );

            //atualizando comida
            Festa.ItemsObrigatorios = Festa.ItemsObrigatorios.Concat(
                gItem.GetItemsFestaPorTipo(ItemTipoEnum.COMIDA, Festa.TipoFesta.Value)
            ).ToList();
        }

        Locacao locacao = gEspaco.SelecionarEspaco(Festa?.QntConvidados ?? 0);
        Festa!.Espaco = locacao.Espaco;
        Festa.Date = locacao.Date;
    }
}