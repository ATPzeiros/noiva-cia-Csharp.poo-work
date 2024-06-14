using NoivaCiaApp.mapper;
using NoivaCiaApp.repository;

static class RepositoryInjector{
    public static ItemCasamentoRepository CreateItemCasamentoRepository(){
        return new ItemCasamentoRepository(
            mapper: new ItemCasamentoMapper(),
            database: new IDatabaseImpl()
        );
    }
}