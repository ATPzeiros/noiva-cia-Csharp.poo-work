using NoivaCiaApp.mapper;
using NoivaCiaApp.repository;

static class RepositoryInjector{
    public static ItemCasamentoRepository CreateItemCasamentoRepository(){
        return new ItemCasamentoRepository(
            mapper: new ItemCasamentoMapper(),
            database: new IDatabaseImpl()
        );
    }

    public static EspacoRepository CreateEspacoRepository(){
        return new EspacoRepository(
            mapper: new EspacoMapper(),
            database: new IDatabaseImpl()
        );
    }

    public static FestaRepository CreateFestaRepository(){
        return new FestaRepository(
            mapper: new FestaMapper(),
            espacoMapper: new EspacoMapper(),
            itemMapper: new ItemCasamentoMapper(),
            database: new IDatabaseImpl()
        );
    }
    
}