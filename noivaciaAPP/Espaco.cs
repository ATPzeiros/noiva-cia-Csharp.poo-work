class Espaco{
    private string Nome {get; set;}
    private int Capacidade {get; set;}
    private bool Locado {get; set;}
    private List<DateTime> Datas_Locadas {get; set;}

    public Espaco(string nome, int capacit){
        this.Nome = nome;
        this.Capacidade = capacit;
        this.Locado = false;
        this.Datas_Locadas = new List<DateTime>();
    }
}