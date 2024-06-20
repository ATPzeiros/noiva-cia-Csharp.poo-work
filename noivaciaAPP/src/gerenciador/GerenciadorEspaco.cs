class GerenciadorEspaco
{
    private readonly Calendario Calendario;
    private readonly EspacoRepository repository;

    public GerenciadorEspaco(
        EspacoRepository repository
    )
    {
        this.repository = repository;
        Calendario = new Calendario();
    }

    public Espaco? EncontrarEspaco(int qntConvidados)
    {
        try
        {
            List<Espaco> espacosComCapacidade = repository.EncontrarMenorEspaco(qntConvidados);
            DateTime possivelData = Calendario.Prox_date();
            int i = 0;

            while (true)
            {
                var espaco = espacosComCapacidade[i % espacosComCapacidade.Count];
                bool espacoLocado = espaco.Datas_Locadas.Any(data => data == possivelData);

                if (!espacoLocado)
                {
                    espaco.Datas_Locadas.Add(possivelData);
                    espaco.qntConvidados = qntConvidados;
                    espaco.Data=  possivelData;
                    return espaco;
                }
                else
                {
                    if (i % espacosComCapacidade.Count == 0 && i != 0)
                    {
                        possivelData = Calendario.Prox_date(possivelData);
                    }
                    i++;
                }
            }
        }
        catch (CapacidadeMaximaExeption)
        {
            Console.WriteLine($"Nao temos local para comportar {qntConvidados} convidados.");
            Console.ReadKey();
            return null;
        }
        catch (DesconhecidaException)
        {
            Console.WriteLine("Ocorreu um erro desconhecido. Tente novamente mais tarde.");
            Console.ReadKey();
            return null;
        }
    }
}