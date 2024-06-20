using SQLitePCL;

interface IRelatorio
{
    public void GerarRelatorio(Festa festa);

    public float CalcularValorTotal(Festa festa);
}