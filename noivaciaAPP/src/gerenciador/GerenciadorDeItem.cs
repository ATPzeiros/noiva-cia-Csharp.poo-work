using NoivaCiaApp.model;
using NoivaCiaApp.repository;

class GerenciadorDeItem {

    private readonly ItemCasamentoRepository repository;

    public GerenciadorDeItem(ItemCasamentoRepository repository)
    {
        this.repository = repository;
    }

    public List<ItemFesta> GetItemsObrigatorios(TipoCategoria categoria, TipoEventoEnum tipoEvento){
        var basico = repository.GetItemCasamentoPorTipo(tipoEvento).Where(item => item.TipoItem == ItemTipoEnum.BASICO);
        var comida = repository.GetItemCasamentoPorTipo(tipoEvento).Where(item => item.TipoItem == ItemTipoEnum.COMIDA);
        return basico.Concat(comida).Select(item => { item.QuantidadeDoItem = 1; return item; }).ToList();
    }

    public List<ItemFesta> GetItems(TipoCategoria categoria, TipoEventoEnum tipoEvento){
        return repository.GetItemCasamentoPorTipo(tipoEvento);
    }

    public List<ItemFesta> GetItems(TipoEventoEnum tipoEvento, ItemTipoEnum tipoItem){
        return repository.GetItemCasamentoPorTipo(tipoEvento).Where(item => item.TipoItem == tipoItem).ToList();
    }

    public List<ItemFesta> getStandartList(){
        return repository.GetItemCasamentoPorTipo(TipoEventoEnum.STANDART);
    }
    public List<ItemFesta> getLuxoList(){
            return repository.GetItemCasamentoPorTipo(TipoEventoEnum.LUXO);
    }
    public List<ItemFesta> getPremierList(){
            return repository.GetItemCasamentoPorTipo(TipoEventoEnum.PREMIER);
    }

    public List<ItemFesta> GetItemCasamentoLuxo(){
        return repository.GetItemCasamentoPorTipo(TipoEventoEnum.LUXO);
    }
}
