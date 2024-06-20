class RelatorioFesta : IRelatorio
{
    public float CalcularValorTotal(Festa festa)
    {
        float valotTotal = festa?.Espaco?.Valor ?? 0;
        valotTotal += festa?.Items.Where(item => item.TipoItem != ItemTipoEnum.BEBIDA).Select( item => item.Price ).Sum() ?? 0;
        valotTotal += festa?.Items.Where(item => item.TipoItem == ItemTipoEnum.BEBIDA).Select( item => item.Price * item.QuantidadeDoItem ).Sum() ?? 0;
        return valotTotal;
    }

    public void GerarRelatorio(Festa festa)
    {
        Console.WriteLine(" ");
        Console.WriteLine("-------------------XX-------------------");
        Console.WriteLine(festa.Categoria + " " + festa.Tipo);
        Console.WriteLine($"R$ {festa?.Espaco?.Valor}\t"+"| Espaco: " + festa?.Espaco?.Nome + " | Espaco id: " + festa?.Espaco?.Id + " | Data: " + festa?.Espaco?.Data.ToShortDateString());
        Console.WriteLine(" ");
        festa?.Items.ForEach(item => {
            Console.WriteLine($"{item.QuantidadeDoItem} x R${item.Price} = R${item.QuantidadeDoItem*item.Price}\t" + item.Name + ":" + item.QuantidadeDoItem);
        });
        Console.WriteLine("Valor total: R$" + CalcularValorTotal(festa));
        Console.WriteLine("-------------------XX-------------------");
        Console.WriteLine(" ");
        Console.ReadKey();
    }
}