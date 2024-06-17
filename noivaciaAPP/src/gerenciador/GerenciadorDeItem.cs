using NoivaCiaApp.model;
using NoivaCiaApp.repository;

class GerenciadorDeItem {
    private List<Item> ListaDeItemsStandart { get; set; }
    private List<Item> ListaDeItemsLuxo { get; set; }
    private List<Item> ListaDeItemsPremier { get; set; }

    private readonly ItemRepository repository;

    public GerenciadorDeItem(ItemRepository repository)
    {
         ListaDeItemsStandart = new List<Item>(){
            new Item("Itens de Mesa", 50, TipoFesta.STANDART, ItemTipoEnum.BASICO ),
            new Item("Decoração", 50, TipoFesta.STANDART, ItemTipoEnum.BASICO),
            new Item("BoloCasamento", 10, TipoFesta.STANDART, ItemTipoEnum.BASICO),
            new Item("Música", 20, TipoFesta.STANDART, ItemTipoEnum.BASICO),
            new Item("Coxinha", 40, TipoFesta.STANDART, ItemTipoEnum.COMIDA),
            new Item("Kibe", 40, TipoFesta.STANDART, ItemTipoEnum.COMIDA),
            new Item("Empadinha", 40, TipoFesta.STANDART, ItemTipoEnum.COMIDA),
            new Item("Pão de Queijo", 40, TipoFesta.STANDART, ItemTipoEnum.COMIDA),
            new Item("Água Sem Gás (1.5 L)", 5, TipoFesta.STANDART, ItemTipoEnum.BEBIDA),
            new Item("Suco(1 L)", 7, TipoFesta.STANDART, ItemTipoEnum.BEBIDA),
            new Item("Refrigerante (2 L)", 8, TipoFesta.STANDART, ItemTipoEnum.BEBIDA),
            new Item("Cerveja Comum (600 ml)", 20, TipoFesta.STANDART, ItemTipoEnum.BEBIDA),
            new Item("Espumante Nacional (750 ml)", 80, TipoFesta.STANDART, ItemTipoEnum.BEBIDA),
        };
        ListaDeItemsLuxo = new List<Item>(){
            new Item("Itens de Mesa", 75, TipoFesta.LUXO, ItemTipoEnum.BASICO ),
            new Item("Decoração", 75, TipoFesta.LUXO, ItemTipoEnum.BASICO),
            new Item("BoloCasamento", 15, TipoFesta.LUXO, ItemTipoEnum.BASICO),
            new Item("Música", 25, TipoFesta.LUXO, ItemTipoEnum.BASICO),
            new Item("Croquete de Carne Seca", 48, TipoFesta.LUXO, ItemTipoEnum.COMIDA),
            new Item("Barquetes Legumes", 48, TipoFesta.LUXO, ItemTipoEnum.COMIDA),
            new Item("Empadinha Gourmet", 48, TipoFesta.LUXO, ItemTipoEnum.COMIDA),
            new Item("Cestinha Bacalhau", 48, TipoFesta.LUXO, ItemTipoEnum.COMIDA),
            new Item("Água Sem Gás (1.5 L)", 5, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
            new Item("Suco(1 L)", 7, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
            new Item("Refrigerante (2 L)", 8, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
            new Item("Cerveja Comum (600 ml)", 20, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
            new Item("Cerveja Artesanal (600 ml)", 30, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
            new Item("Espumante Nacional (750 ml)", 80, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
            new Item("Espumante Importado (750 ml)", 140, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
        };
         ListaDeItemsPremier = new List<Item>(){
            new Item("Itens de Mesa", 100, TipoFesta.PREMIER, ItemTipoEnum.BASICO ),
            new Item("Decoração", 100, TipoFesta.PREMIER, ItemTipoEnum.BASICO),
            new Item("BoloCasamento", 20, TipoFesta.PREMIER, ItemTipoEnum.BASICO),
            new Item("Música", 30, TipoFesta.PREMIER, ItemTipoEnum.BASICO),
            new Item("Canapé", 60, TipoFesta.PREMIER, ItemTipoEnum.COMIDA),
            new Item("Tartine", 60, TipoFesta.PREMIER, ItemTipoEnum.COMIDA),
            new Item("Bruschetta", 60, TipoFesta.PREMIER, ItemTipoEnum.COMIDA),
            new Item("Espetinho carprese", 60, TipoFesta.PREMIER, ItemTipoEnum.COMIDA),
            new Item("Água Sem Gás (1.5 L)", 5, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
            new Item("Suco(1 L)", 7, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
            new Item("Refrigerante (2 L)", 8, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
            new Item("Cerveja Comum (600 ml)", 20, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
            new Item("Cerveja Artesanal (600 ml)", 30, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
            new Item("Espumante Nacional (750 ml)", 80, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
            new Item("Espumante Importado (750 ml)", 140, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
        };

        this.repository = repository;
    }
    public List<Item> getStandartList(){
            return ListaDeItemsStandart;
    }
    public List<Item> getLuxoList(){
            return ListaDeItemsLuxo;
    }
    public List<Item> getPremierList(){
            return ListaDeItemsPremier;
    }
}
