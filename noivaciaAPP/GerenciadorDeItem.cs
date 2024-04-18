using System.Security.Cryptography.X509Certificates;

class GerenciadorDeItem{
    private List<ItemCasamento> ListaDeItemsStandart { get; set; }
    private List<ItemCasamento> ListaDeItemsLuxo { get; set; }
    private List<ItemCasamento> ListaDeItemsPremier { get; set; }
    public GerenciadorDeItem()
    {
         ListaDeItemsStandart = new List<ItemCasamento>(){
            new ItemCasamento("Itens de Mesa", 50, CasamentoTipoEnum.STANDART, ItemTipoEnum.BASICO ),
            new ItemCasamento("Decoração", 50, CasamentoTipoEnum.STANDART, ItemTipoEnum.BASICO),
            new ItemCasamento("BoloCasamento", 10, CasamentoTipoEnum.STANDART, ItemTipoEnum.BASICO),
            new ItemCasamento("Música", 20, CasamentoTipoEnum.STANDART, ItemTipoEnum.BASICO),
            new ItemCasamento("Coxinha", 40, CasamentoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemCasamento("Kibe", 40, CasamentoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemCasamento("Empadinha", 40, CasamentoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemCasamento("Pão de Queijo", 40, CasamentoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemCasamento("Água Sem Gás (1.5 L)", 5, CasamentoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Suco(1 L)", 7, CasamentoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Refrigerante (2 L)", 8, CasamentoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Cerveja Comum (600 ml)", 20, CasamentoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Espumante Nacional (750 ml)", 80, CasamentoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
        };
        ListaDeItemsLuxo = new List<ItemCasamento>(){
            new ItemCasamento("Itens de Mesa", 75, CasamentoTipoEnum.LUXO, ItemTipoEnum.BASICO ),
            new ItemCasamento("Decoração", 75, CasamentoTipoEnum.LUXO, ItemTipoEnum.BASICO),
            new ItemCasamento("BoloCasamento", 15, CasamentoTipoEnum.LUXO, ItemTipoEnum.BASICO),
            new ItemCasamento("Música", 25, CasamentoTipoEnum.LUXO, ItemTipoEnum.BASICO),
            new ItemCasamento("Croquete de Carne Seca", 48, CasamentoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemCasamento("Barquetes Legumes", 48, CasamentoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemCasamento("Empadinha Gourmet", 48, CasamentoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemCasamento("Cestinha Bacalhau", 48, CasamentoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemCasamento("Água Sem Gás (1.5 L)", 5, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Suco(1 L)", 7, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Refrigerante (2 L)", 8, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Cerveja Comum (600 ml)", 20, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Cerveja Artesanal (600 ml)", 30, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Espumante Nacional (750 ml)", 80, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Espumante Importado (750 ml)", 140, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
        };
         ListaDeItemsPremier = new List<ItemCasamento>(){
            new ItemCasamento("Itens de Mesa", 100, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BASICO ),
            new ItemCasamento("Decoração", 100, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BASICO),
            new ItemCasamento("BoloCasamento", 20, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BASICO),
            new ItemCasamento("Música", 30, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BASICO),
            new ItemCasamento("Canapé", 60, CasamentoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemCasamento("Tartine", 60, CasamentoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemCasamento("Bruschetta", 60, CasamentoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemCasamento("Espetinho carprese", 60, CasamentoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemCasamento("Água Sem Gás (1.5 L)", 5, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Suco(1 L)", 7, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Refrigerante (2 L)", 8, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Cerveja Comum (600 ml)", 20, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Cerveja Artesanal (600 ml)", 30, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Espumante Nacional (750 ml)", 80, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemCasamento("Espumante Importado (750 ml)", 140, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
        };
    }
    public List<ItemCasamento> getStandartList(){
            return ListaDeItemsStandart;
        }
}