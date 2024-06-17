namespace NoivaCiaApp.model
{
    public class NewEspaco : Model
    {
        public override int Id { get;set;}
        public string? Nome { get; set; }
        public int CapacidadeMax { get; set; }
        public int Valor { get; set; }
        public EspacoTipoEnum Tipo { get; set; }

        public NewEspaco(
            int id,
            string Nome,
            int CapacidadeMax,
            int Valor,
            EspacoTipoEnum Tipo
        )
        {
            this.Id = id;
            this.Nome = Nome;
            this.CapacidadeMax = CapacidadeMax;
            this.Valor = Valor;
            this.Tipo = Tipo;
        }
    }
}