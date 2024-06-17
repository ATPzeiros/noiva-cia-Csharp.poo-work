using NoivaCiaApp.model;

namespace noivaCiaApp.gerenciador
{
    class GerenciadorFesta
    {

        private readonly FestaRepository repository;

        public GerenciadorFesta(FestaRepository repository){
            this.repository = repository;
        }

        public bool AgendarFesta(Festa festa)
        {
            return repository.SaveFesta(festa);
        }

        public List<Festa> ListarFestas()
        {
            return new List<Festa>();
        }

        public List<Festa> ListarFestas(DateTime date)
        {
            return new List<Festa>();
        }

        public List<Festa> ListarFestas(int qntConvidados)
        {
            return new List<Festa>();
        }

        public bool EscluirFesta(int id)
        {
            return repository.ExcluirFesta(id);
        }
    }
}
