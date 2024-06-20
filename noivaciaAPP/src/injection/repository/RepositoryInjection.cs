using NoivaCiaApp.mapper;
using NoivaCiaApp.repository;

static class RepositoryInjector{
    public static ItemCasamentoRepository CreateItemCasamentoRepository(){
        return new ItemCasamentoRepository(
            mapper: new ItemCasamentoMapper(),
            database: new IDatabaseImpl()
        );
    }
    public static EspacoEventoRepository CreateEspacoEventoRepository(){
        return new EspacoEventoRepository(
            mapper: new EspacoEventoMapper(),
            database: new IDatabaseImpl()
        );
    }
}