using NoivaCiaApp.mapper;
using NoivaCiaApp.repository;

static class RepositoryInjector{
    public static ItemRepository CreateItemRepository(){
        return new ItemRepository(
            mapper: new ItemMapper(),
            database: new IDatabaseImpl()
        );
    }

    public static EspacoRepository CreateEspacoRepository() => new(
        database: new IDatabaseImpl()
    );

    public static FestaRepository CreateFestaRepository() => new(
        mapper: new FestaMapper(),
        database: new IDatabaseImpl()
    );
}