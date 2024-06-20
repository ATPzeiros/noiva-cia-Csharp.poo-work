class RelatorioFesta : IRelatorio
{
    public float CalcularValorTotal(Festa festa)
    {
        float valotTotal = festa.Espaco.Valor;
        valotTotal += festa.Items.Where(item => item.TipoItem != ItemTipoEnum.BEBIDA).Select( item => item.Price ).Sum();
        valotTotal += festa.Items.Where(item => item.TipoItem == ItemTipoEnum.BEBIDA).Select( item => item.Price * item.QuantidadeDoItem ).Sum();
        return valotTotal;
    }

    public void GerarRelatorio(Festa festa)
    {
        Console.WriteLine("Espaco: " + festa.Espaco?.Nome);
        Console.WriteLine("Espaco id: " + festa.Espaco?.Id);
        Console.WriteLine("Data: " + festa.Espaco?.Nome);
        Console.WriteLine(festa.Categoria);
        Console.WriteLine(festa.Tipo);
        festa.Items.ForEach(item => {
            Console.WriteLine(item.Name);
            Console.WriteLine(item.QuantidadeDoItem);
        });

        Console.WriteLine("Valor total: " + CalcularValorTotal(festa));

        Console.ReadKey();
    }
}