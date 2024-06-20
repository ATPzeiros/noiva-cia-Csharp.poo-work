using System.Data.Entity.Core.Common.CommandTrees;
using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

class PopulateDatabase
{
    private readonly IDatabase database;
    private readonly IMapper<ItemFesta, ItemFestaEntity> mapper;
    private readonly IMapper<Espaco, EspacoEntity> espacoMapper;

    public PopulateDatabase(
        IDatabase database, 
        IMapper<ItemFesta, ItemFestaEntity> mapper,
        IMapper<Espaco, EspacoEntity> espacoMapper
    ){
        this.database = database;
        this.mapper = mapper;
        this.espacoMapper = espacoMapper;

        var hasItems = database.GetEntities<ItemFestaEntity>().Count > 0;
        var hasEspacos = database.GetEntities<EspacoEntity>().Count > 0;
        if(!hasItems){
            PopulateItems();
        }

        if(!hasEspacos){
            PopulateEspaco();
        }
    }

    private void PopulateEspaco(){
        List<Espaco> espacos = new List<Espaco>(){
            new Espaco("g", 50,  8000  , EspacoTipoEnum.MAX50 ),
            new Espaco("a", 100, 10000 , EspacoTipoEnum.MAX100),
            new Espaco("b", 100, 10000 , EspacoTipoEnum.MAX100),
            new Espaco("c", 100, 10000 , EspacoTipoEnum.MAX100),
            new Espaco("d", 100, 10000 , EspacoTipoEnum.MAX100),
            new Espaco("e", 200, 17000 , EspacoTipoEnum.MAX200),
            new Espaco("f", 200, 17000 , EspacoTipoEnum.MAX200),
            new Espaco("h", 500, 35000 , EspacoTipoEnum.MAX500),
        };

        database.SaveEntities(espacos.Select(espacoMapper.MapToEntity).ToList());
    }

    private void PopulateItems(){
        List<ItemFesta> items = new(){
            new ItemFesta("Itens de Mesa", 50, TipoEventoEnum.STANDART, ItemTipoEnum.BASICO),
            new ItemFesta("Decoração", 50, TipoEventoEnum.STANDART, ItemTipoEnum.BASICO),
            new ItemFesta("BoloCasamento", 10, TipoEventoEnum.STANDART, ItemTipoEnum.BASICO),
            new ItemFesta("Música", 20, TipoEventoEnum.STANDART, ItemTipoEnum.BASICO),
            new ItemFesta("Coxinha", 40, TipoEventoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemFesta("Kibe", 40, TipoEventoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemFesta("Empadinha", 40, TipoEventoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemFesta("Pão de Queijo", 40, TipoEventoEnum.STANDART, ItemTipoEnum.COMIDA),
            new ItemFesta("Água Sem Gás (1.5 L)", 5, TipoEventoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemFesta("Suco(1 L)", 7, TipoEventoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemFesta("Refrigerante (2 L)", 8, TipoEventoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemFesta("Cerveja Comum (600 ml)", 20, TipoEventoEnum.STANDART, ItemTipoEnum.BEBIDA),
            new ItemFesta("Espumante Nacional (750 ml)", 80, TipoEventoEnum.STANDART, ItemTipoEnum.BEBIDA),
        
            new ItemFesta("Itens de Mesa", 75, TipoEventoEnum.LUXO, ItemTipoEnum.BASICO),
            new ItemFesta("Decoração", 75, TipoEventoEnum.LUXO, ItemTipoEnum.BASICO),
            new ItemFesta("BoloCasamento", 15, TipoEventoEnum.LUXO, ItemTipoEnum.BASICO),
            new ItemFesta("Música", 25, TipoEventoEnum.LUXO, ItemTipoEnum.BASICO),
            new ItemFesta("Croquete de Carne Seca", 48, TipoEventoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemFesta("Barquetes Legumes", 48, TipoEventoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemFesta("Empadinha Gourmet", 48, TipoEventoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemFesta("Cestinha Bacalhau", 48, TipoEventoEnum.LUXO, ItemTipoEnum.COMIDA),
            new ItemFesta("Água Sem Gás (1.5 L)", 5, TipoEventoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemFesta("Suco(1 L)", 7, TipoEventoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemFesta("Refrigerante (2 L)", 8, TipoEventoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemFesta("Cerveja Comum (600 ml)", 20, TipoEventoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemFesta("Cerveja Artesanal (600 ml)", 30, TipoEventoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemFesta("Espumante Nacional (750 ml)", 80, TipoEventoEnum.LUXO, ItemTipoEnum.BEBIDA),
            new ItemFesta("Espumante Importado (750 ml)", 140, TipoEventoEnum.LUXO, ItemTipoEnum.BEBIDA),
        
            new ItemFesta("Itens de Mesa", 100, TipoEventoEnum.PREMIER, ItemTipoEnum.BASICO),
            new ItemFesta("Decoração", 100, TipoEventoEnum.PREMIER, ItemTipoEnum.BASICO),
            new ItemFesta("BoloCasamento", 20, TipoEventoEnum.PREMIER, ItemTipoEnum.BASICO),
            new ItemFesta("Música", 30, TipoEventoEnum.PREMIER, ItemTipoEnum.BASICO),
            new ItemFesta("Canapé", 60, TipoEventoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemFesta("Tartine", 60, TipoEventoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemFesta("Bruschetta", 60, TipoEventoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemFesta("Espetinho carprese", 60, TipoEventoEnum.PREMIER, ItemTipoEnum.COMIDA),
            new ItemFesta("Água Sem Gás (1.5 L)", 5, TipoEventoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemFesta("Suco(1 L)", 7, TipoEventoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemFesta("Refrigerante (2 L)", 8, TipoEventoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemFesta("Cerveja Comum (600 ml)", 20, TipoEventoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemFesta("Cerveja Artesanal (600 ml)", 30, TipoEventoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemFesta("Espumante Nacional (750 ml)", 80, TipoEventoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            new ItemFesta("Espumante Importado (750 ml)", 140, TipoEventoEnum.PREMIER, ItemTipoEnum.BEBIDA)
        };


        database.SaveEntities(items.Select(mapper.MapToEntity).ToList());
    }
}