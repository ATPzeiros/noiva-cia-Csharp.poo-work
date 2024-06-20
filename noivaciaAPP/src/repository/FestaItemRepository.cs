using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

class FestaItemRepository
{
    private readonly IMapper<ItemFesta, ItemFestaEntity> mapper;
    private readonly IDatabase database;

    public FestaItemRepository(IMapper<ItemFesta, ItemFestaEntity> mapper, IDatabase database)
    {
        this.mapper = mapper;
        this.database = database;
    }

    public List<ItemFesta> GetItemsDaFesta(int IdFesta)
    {
        try
        {
            return database
        .GetEntities<ItemsFestaEntity>()
        .Where(item => item.Fk_Festa == IdFesta)
        .Select(item =>
        {
            var i = database.GetEntity<ItemFestaEntity>();
            return mapper.MapToModel(i);
        }).ToList();
        }
        catch
        {
            return new List<ItemFesta>();
        }

    }
}