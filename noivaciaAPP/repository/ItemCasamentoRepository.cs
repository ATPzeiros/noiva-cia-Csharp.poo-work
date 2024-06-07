using NoivaPoo;
using SQLite;

class ItemCasamentoRepository
{

    private readonly IMapper<ItemCasamento, ItemFestaEntity> mapper;
    private readonly SQLiteConnection database;

    public ItemCasamentoRepository(IMapper<ItemCasamento, ItemFestaEntity> mapper, SQLiteConnection database)
    {
        this.mapper = mapper;
        this.database = database;
    }

    public bool SaveItemCasamento(ItemCasamento item)
    {
        var entity = mapper?.MapToEntity(item);
        database.CreateTable<ItemFestaEntity>();
        return database?.Insert(entity) > 0;
    }

    public List<ItemCasamento> GetItemCasamentoPorTipo(CasamentoTipoEnum tipo)
    {
        try
        {
            return database
                .Table<ItemFestaEntity>()
                .Where(item => item.TipoCasamento == (int)tipo)
                .Select(item => mapper?.MapToModel(item))
                .OfType<ItemCasamento>()
                .ToList();
        }
        catch
        {
            return new List<ItemCasamento>();
        }
    }
}
