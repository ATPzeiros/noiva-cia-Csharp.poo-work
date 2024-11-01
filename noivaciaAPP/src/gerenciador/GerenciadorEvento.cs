using NoivaCiaApp.entity;
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

    public void GerarResumoDetalhado(Festa festa){
        festa.Items = repository.GetItemsDaFesta(festa.Id);
        relatorio.GerarRelatorio(festa);
    }

    public bool ExcluirEventoPorId(int idFesta) => repository.DeleteFesta(idFesta);

    public List<Festa> ListaDeFestas(){
        return repository.GetAllFestas().ToList();
    }
}