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

        public float ResumoDaFesta(Festa festa){
            float precoEspaco = festa.Locacao.Espaco.Valor;
            float precoServicoBasico = festa.ItemsObrigatorios.Where(item => item.TipoServico != null).Sum(item => item.Price);
            float precoServicoComida = festa.ItemsObrigatorios.Where(item => item.TipoItem == ItemTipoEnum.COMIDA).Sum(item => item.Price);
            float precoServicoBebida = festa.ItemsSelecionaveis.Where(item => item.TipoItem == ItemTipoEnum.BEBIDA).Sum(item => item.Price * item.Quantidade);
            float valorFinal = precoEspaco + precoServicoBasico + precoServicoComida + precoServicoBebida;

            PrintHeaderFormatado("DATA & ESPAÇO");
            Console.WriteLine($"Espaco reservado: \"{festa.Locacao.Espaco.Nome}\"");
            Console.WriteLine($"Capacidade maxima: \"{festa.Locacao.Espaco.CapacidadeMax}\"");
            Console.WriteLine($"Quantidade de convidados: \"{festa.Locacao.QuantidadeConvidados}\"");
            Console.WriteLine($"{festa.Locacao.Date.ToShortDateString()} ({festa.Locacao.Date.DayOfWeek}).");
            PrintFormatado("Total", precoEspaco);

            Console.WriteLine("\n");

            PrintHeaderFormatado("SERVICOS BASICOS");
            festa
                .ItemsObrigatorios
                .Where(item => item.TipoServico != null)
                .ToList()
                .ForEach(item => PrintItemFormatado($"- {item.Name}", item.Price));
            PrintFormatado("Total", precoServicoBasico);

            Console.WriteLine("\n");
            PrintHeaderFormatado("SERVICOS DE COMIDA");
            festa
                .ItemsObrigatorios
                .Where(item => item.TipoItem == ItemTipoEnum.COMIDA)
                .ToList()
                .ForEach(item => PrintItemFormatado($"- {item.Name}", item.Price));
            
            PrintFormatado("Total", precoServicoComida);

            Console.WriteLine("\n");
            PrintHeaderFormatado("SERVICOS DE BEBIDA");
            festa
                .ItemsSelecionaveis
                .ToList()
                .ForEach(item => PrintItemQuantidadeFormatado($"- x{item.Quantidade} {item.Name}", item.Quantidade, item.Price));
            PrintFormatado("Total", precoServicoBebida);
            
            Console.WriteLine("\n\n");
            PrintFormatado("Total", valorFinal);
            return valorFinal;
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

        public void PrintFormatado(string text, float price){
            Console.WriteLine($"{text}{new string('-', 50-text.Length)}R$ {price}");
        }
        
        public void PrintItemFormatado(string text, float price){
            Console.WriteLine($"{text}{new string(' ', 50-text.Length)}R$ {price}");
        }

        public void PrintItemQuantidadeFormatado(string text, int quantidade, float price){
            Console.WriteLine($"{text}{new string(' ', 50-text.Length)}R$ {quantidade*price} (R$ {price} x {quantidade})");
        }

        public void PrintHeaderFormatado(string text){
            int gap = (int)Math.Ceiling((double)(50 - text.Length)/2);
            Console.WriteLine($"{new string('=', gap)}{text}{new string('=', gap)}");
        }
    }
}
