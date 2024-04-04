class Espaco{
    private string Nome {get; set;}
    private int Capacidade {get; set;}
    private bool Locado {get; set;}
    private List<DateTime> Datas_Locadas {get; set;}

    public Espaco(string nome, int capacit){
        Nome = nome;
        Capacidade = capacit;
        Locado = false;
        Datas_Locadas = new List<DateTime>();
    }
}