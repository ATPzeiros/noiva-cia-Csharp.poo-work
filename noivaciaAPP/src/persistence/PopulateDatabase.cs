using System.Data.Entity.Core.Common.CommandTrees;
using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

class PopulateDatabase
{
    private readonly IDatabase database;
    private readonly IMapper<ItemCasamento, ItemFestaEntity> mapper;
    private readonly IMapper<Espaco, EspacoEntity> espacoMapper;

    public PopulateDatabase(
        IDatabase database, 
        IMapper<ItemCasamento, ItemFestaEntity> mapper,
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
        List<ItemCasamento> items = new(){
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
            new ItemCasamento("Espumante Importado (750 ml)", 140, EventoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA)
        };


        database.SaveEntities(items.Select(mapper.MapToEntity).ToList());
    }
}