using NoivaCiaApp.model;
using NoivaCiaApp.repository;

namespace noivaCiaApp.gerenciador
{
    class NewGerenciadorEspaco {
        private readonly EspacoRepository repository;
        private readonly Calendario calendario;

        public NewGerenciadorEspaco(
            EspacoRepository repository,
            Calendario calendario
        )
        {
            this.repository = repository;
            this.calendario = calendario;
        }

        public Locacao SelecionarEspaco(int qntConvidados){
            List<NewEspaco> possiveisEspacos = PossiveisEspacos(qntConvidados);
            Locacao locacao = EncontrarLocacao(possiveisEspacos, qntConvidados);
            repository.SalvarLocacao(locacao);
            return locacao;
        }

        private List<NewEspaco> PossiveisEspacos(int qntConvidados){
            List<NewEspaco> espacos = repository.GetEspacos();
            NewEspaco? espacoComCapacidade = espacos.Find(espaco => espaco.CapacidadeMax >= qntConvidados && qntConvidados > 0);
            return espacos.FindAll(espaco => espacoComCapacidade?.Tipo == espaco.Tipo);
        }

        private Locacao EncontrarLocacao(List<NewEspaco> espacos, int qntConvidados){
            DateTime possivelData = calendario.Prox_date();
            int i=0;

            while(true) {
                var espaco = espacos[i % espacos.Count];
                bool espacoLocado = repository.EspacoLocado(espaco.Id, possivelData);
                Console.WriteLine($"espaco locado? {espaco.Nome} - {espacoLocado}");

                if(!espacoLocado){
                    return new Locacao(espaco, possivelData, qntConvidados);
                } else {
                    if(i % espacos.Count == 0 && i != 0){
                        possivelData = calendario.Prox_date(possivelData); 
                        Console.WriteLine($"Tentando proxima data: {possivelData}");
                        Console.ReadKey();
                    }
                    i++;
                }
            }
        }
    }
}