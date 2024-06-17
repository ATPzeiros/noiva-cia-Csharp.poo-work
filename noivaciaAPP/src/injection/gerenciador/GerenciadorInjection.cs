using noivaCiaApp.gerenciador;

static class GerenciadorInjection
{
    public static NewGerenciadorItems GerenciadorDeItem() => new(
        repository: RepositoryInjector.CreateItemRepository()
    );

    public static GerenciadorFesta GerenciadorDeFesta() => new(
        repository: RepositoryInjector.CreateFestaRepository()
    );

    public static NewGerenciadorEspaco GerenciadorEspaco() => new(
        repository: RepositoryInjector.CreateEspacoRepository(),
        calendario: new Calendario()
    );
}