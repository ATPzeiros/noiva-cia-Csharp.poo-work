using System.Runtime.CompilerServices;
using NoivaCiaApp.model;

class VerFestaController
{
    private readonly FestaRepository repository;

    public VerFestaController(FestaRepository repository){
        this.repository = repository;
    }

    public Dictionary<DateTime, List<Festa>> BuscarFestas() => 
        repository
        .GetFestas()
        .Where(f => f.Date != null)
        .GroupBy(f => f.Date)
        .ToList()
        .ToDictionary(g => g.Key ?? new DateTime(), g => g.ToList());
}
