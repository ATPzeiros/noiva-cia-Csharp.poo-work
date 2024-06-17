using NoivaCiaApp.model;

public class Locacao{
    public NewEspaco Espaco { get; set; }
    public DateTime Date{ get; set; }
    public int QuantidadeConvidados {get;set;}

    public Locacao(NewEspaco espaco, DateTime date, int quantidadeConvidados){
        Espaco = espaco;
        Date = date;
        QuantidadeConvidados = quantidadeConvidados;
    }
}