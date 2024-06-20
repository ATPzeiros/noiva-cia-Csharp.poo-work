using NoivaCiaApp.model;
using NoivaCiaApp.repository;
using SQLitePCL;

class GerenciadorEvento
{

    private readonly FestaRepository repository;
    private readonly IRelatorio relatorio;
    public GerenciadorEvento(FestaRepository repository, IRelatorio relatorio){
        this.repository = repository;
        this.relatorio = relatorio;
    }

    public bool MarcarEvento(Festa festa)
    {
        return repository.SaveFesta(festa, relatorio.CalcularValorTotal(festa));
    }

    public void GerarResumo(
        Festa festa
    ){
        relatorio.GerarRelatorio(festa);
    }

    public void ExcluirEventoPorData(){

    }
}