using NoivaCiaApp.mapper;
using NoivaCiaApp.persistence;

class EspacoRepository
{
    private readonly IMapper<Espaco, EspacoEntity> mapper;
    private readonly IDatabase database;

    public EspacoRepository(
        IDatabase database,
        IMapper<Espaco, EspacoEntity> mapper
    )
    {
        this.database = database;
        this.mapper = mapper;
    }

    public List<Espaco> GetEspacos()
    {
        return database.GetEntities<EspacoEntity>().Select(mapper.MapToModel).ToList();
    }

    public List<Espaco> EncontrarMenorEspaco(int qntConvidados)
    {
            List<Espaco> espacos = database.GetEntities<EspacoEntity>().Select(mapper.MapToModel).ToList();

            if (qntConvidados > espacos?.MaxBy(espaco => espaco.CapacidadeMax)?.CapacidadeMax)
            {
                throw new CapacidadeMaximaExeption();
            }

            EspacoTipoEnum? tipo = espacos?.Find(espaco => espaco.CapacidadeMax >= qntConvidados && qntConvidados > 0)?.Tipo;
            return espacos
                ?.FindAll(espaco => tipo == espaco.Tipo)
                .OfType<Espaco>()
                .ToList() ?? new List<Espaco>();
    }

    public bool FestaLocadaParaDia(int EspacoId, DateTime date){
        return database.GetEntities<FestaEntity>().Where(item => item.FkEspaco == EspacoId && item.Data == date).Any();
    }
}