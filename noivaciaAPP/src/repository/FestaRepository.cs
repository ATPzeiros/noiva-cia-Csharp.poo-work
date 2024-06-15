using noivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

class FestaRepository{

    private readonly IMapper<Festa, FestaEntity> mapper;
    private readonly IDatabase database;

    public FestaRepository(IMapper<Festa, FestaEntity> mapper, IDatabase database){
        this.mapper = mapper;
        this.database = database;
    }

    public bool SaveFesta(Festa festa) => database.SaveEntity(mapper.MapToEntity(festa)) > 0;

    public List<Festa> GetFestas(DateTime date){
        return new List<Festa>();
    }

    public bool ExcluirFesta(int id) => database.DeleteById<FestaEntity>(id) > 0;
}