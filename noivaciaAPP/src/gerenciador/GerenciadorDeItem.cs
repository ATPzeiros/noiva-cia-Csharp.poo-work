using NoivaCiaApp.model;
using NoivaCiaApp.repository;

class GerenciadorDeItem {
    private List<ItemCasamento> ListaDeItemsStandart { get; set; }
    private List<ItemCasamento> ListaDeItemsLuxo { get; set; }
    private List<ItemCasamento> ListaDeItemsPremier { get; set; }

    private ItemCasamentoRepository repository;

    public GerenciadorDeItem()
    {
         ListaDeItemsStandart = new List<ItemCasamento>(){
            new ItemCasamento("Itens de Mesa", 50, EventoTipoEnum.STANDART, ItemTipoEnum.BASICO ),
            new ItemCasamento("Decoração", 50, EventoTipoEnum.STANDART, ItemTipoEnum.BASICO),
            new ItemCasamento("BoloCasamento", 10, EventoTipoEnum.STANDART, ItemTipoEnum.BASICO),
            new ItemCasamento("Música", 20, EventoTipoEnum.STANDART, ItemTipoEnum.BASICO),
            new ItemCasamento("Coxinha", 40, EventoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemCasamento("Kibe", 40, EventoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemCasamento("Empadinha", 40, EventoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemCasamento("Pão de Queijo", 40, EventoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemCasamento("Água Sem Gás (1.5 L)", 5, EventoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Suco(1 L)", 7, EventoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Refrigerante (2 L)", 8, EventoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Cerveja Comum (600 ml)", 20, EventoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Espumante Nacional (750 ml)", 80, EventoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
        };
        ListaDeItemsLuxo = new List<ItemCasamento>(){
            new ItemCasamento("Itens de Mesa", 75, EventoTipoEnum.LUXO, ItemTipoEnum.BASICO ),
            new ItemCasamento("Decoração", 75, EventoTipoEnum.LUXO, ItemTipoEnum.BASICO),
            new ItemCasamento("BoloCasamento", 15, EventoTipoEnum.LUXO, ItemTipoEnum.BASICO),
            new ItemCasamento("Música", 25, EventoTipoEnum.LUXO, ItemTipoEnum.BASICO),
            new ItemCasamento("Croquete de Carne Seca", 48, EventoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemCasamento("Barquetes Legumes", 48, EventoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemCasamento("Empadinha Gourmet", 48, EventoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemCasamento("Cestinha Bacalhau", 48, EventoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemCasamento("Água Sem Gás (1.5 L)", 5, EventoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Suco(1 L)", 7, EventoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Refrigerante (2 L)", 8, EventoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Cerveja Comum (600 ml)", 20, EventoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Cerveja Artesanal (600 ml)", 30, EventoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Espumante Nacional (750 ml)", 80, EventoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Espumante Importado (750 ml)", 140, EventoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
        };
         ListaDeItemsPremier = new List<ItemCasamento>(){
            new ItemCasamento("Itens de Mesa", 100, EventoTipoEnum.PREMIER, ItemTipoEnum.BASICO ),
            new ItemCasamento("Decoração", 100, EventoTipoEnum.PREMIER, ItemTipoEnum.BASICO),
            new ItemCasamento("BoloCasamento", 20, EventoTipoEnum.PREMIER, ItemTipoEnum.BASICO),
            new ItemCasamento("Música", 30, EventoTipoEnum.PREMIER, ItemTipoEnum.BASICO),
            new ItemCasamento("Canapé", 60, EventoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemCasamento("Tartine", 60, EventoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemCasamento("Bruschetta", 60, EventoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemCasamento("Espetinho carprese", 60, EventoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemCasamento("Água Sem Gás (1.5 L)", 5, EventoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Suco(1 L)", 7, EventoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Refrigerante (2 L)", 8, EventoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Cerveja Comum (600 ml)", 20, EventoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Cerveja Artesanal (600 ml)", 30, EventoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Espumante Nacional (750 ml)", 80, EventoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Espumante Importado (750 ml)", 140, EventoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
        };

        repository = RepositoryInjector.CreateItemCasamentoRepository();
    }
    public List<ItemCasamento> getStandartList(){
            return ListaDeItemsStandart;
    }
    public List<ItemCasamento> getLuxoList(){
            return ListaDeItemsLuxo;
    }
    public List<ItemCasamento> getPremierList(){
            return ListaDeItemsPremier;
    }

    public List<ItemCasamento> GetItemCasamentoLuxo(){
        return repository.GetItemCasamentoPorTipo(EventoTipoEnum.LUXO);
    }

    public List<ItemCasamento> GetItemPorTipo(EventoTipoEnum tipo){
        return repository.GetItemCasamentoPorTipo(tipo);
    } 
}
