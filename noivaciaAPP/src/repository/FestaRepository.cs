using noivaCiaApp.entity;
using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

class FestaRepository {

    private readonly IMapper<Festa, FestaEntity> mapper;
    private readonly IDatabase database;

    public FestaRepository(IMapper<Festa, FestaEntity> mapper, IDatabase database){
        this.mapper = mapper;
        this.database = database;
    }

    public bool SaveFesta(Festa festa) {
        //database.SaveEntity<FestaItemsEntity>(festa.ItemsSelecionaveis);
        var festaEntity = mapper.MapToEntity(festa);
        database.SaveEntity(festaEntity);

        var itemsEntity = festa.ItemsSelecionaveis.Select(item => 
            new FestaItemsEntity(){
                Fk_festa = festaEntity.Id,
                Fk_item = item.Id,
                Quantidade = item.Quantidade,
                
            }
        ).Concat(
            festa.ItemsObrigatorios.Select(item => 
                new FestaItemsEntity(){
                Fk_festa = festaEntity.Id,
                Fk_item = item.Id,
                Quantidade = 1
            })
        );
        database.SaveAllEntities(itemsEntity.ToList());

        return true;
    }

    public List<Festa> GetFestas(){
        return database
        .GetEntities<FestaEntity>()
        .Select(festa => 
            new Festa(){
                Id = festa.Id,
                CategoriaFesta = (CategoriaFesta)festa.Categoria,
                TipoFesta = (TipoFesta) festa.Tipo,
                Date = new DateTime(festa.Year, festa.Month, festa.Day),
                QntConvidados = 0,
            }
        )
        .ToList();
    }

    public bool ExcluirFesta(int id) => database.DeleteById<FestaEntity>(id) > 0;
}