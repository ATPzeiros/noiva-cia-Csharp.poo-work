class RelatorioFesta : IRelatorio
{
    public void GerarRelatorio(Festa festa)
    {
        Console.WriteLine("ESpaco: " + festa.Espaco?.Nome);
        Console.WriteLine(festa.Categoria);
        Console.WriteLine(festa.Tipo);
        festa.Items.ForEach(item => {
            Console.WriteLine(item.Name);
            Console.WriteLine(item.QuantidadeDoItem);
        });

        Console.ReadKey();
    }
}