using NoivaCiaApp.model;

class MarcarFestaView : IView
{
    public static void MostrarView()
    {
        GerenciadorDeItem gITem = new(
                                repository: RepositoryInjector.CreateItemCasamentoRepository()
                            );
        GerenciadorEspaco gEspaco = new(
            repository: RepositoryInjector.CreateEspacoRepository()
        );
        GerenciadorEvento gEvento = new(
            repository: RepositoryInjector.CreateFestaRepository(),
            relatorio: RelatorioInjection.GenerateFestaRelatorio()
        );

        int qntPessoas = InputReader.LerIntZeroOuMaiorTeclado(text: "Informe a quantidade de pessoas: ");

        Espaco? espaco = gEspaco.EncontrarEspaco(qntPessoas);
        Console.WriteLine("Espaco: " + espaco?.Nome);

        Console.WriteLine("Informe a categoria da festa: ");
        TipoCategoria categoria = InputReader.SelecionarDaLista("Selecione a categoria: ", Enum.GetValues<TipoCategoria>().ToList());
        Console.WriteLine(categoria);
        TipoEventoEnum tipoEvento = InputReader.SelecionarDaLista("Selecione o tipo de evento: ", Enum.GetValues<TipoEventoEnum>().ToList());
        Console.WriteLine(tipoEvento);
        Console.ReadKey();

        List<ItemFesta> bebidas = gITem
        .GetItems(tipoEvento, ItemTipoEnum.BEBIDA)
        .Select(bebida =>
        {
            int qnt = InputReader.LerIntZeroOuMaiorTeclado($"Informe a quantidade de {bebida.Name}: ");
            bebida.QuantidadeDoItem = qnt;
            return bebida;
        }).ToList();

        List<ItemFesta> itemsObrigatorios = gITem.GetItemsObrigatorios(categoria, tipoEvento);

        Festa festa = new(
            espaco,
            tipoEvento,
            categoria,
            qntPessoas,
            itemsObrigatorios.Concat(bebidas).ToList()
        );
        gEvento.GerarResumo(festa);
        bool confirm = InputReader.SelecionarDaLista("Confirmar reserva?", new List<bool>() { true, false });
        if (confirm)
        {
            gEvento.MarcarEvento(festa);
            Console.WriteLine("Festa salva com sucesso. Pressione qualquer tecla para prosseguir...");
            Console.ReadKey();
        }
    }
}