class Espaco {
    public string Nome {get; set;}
    public int Capacidade {get; set;}
    public bool Locado {get; set;}
    public List<DateTime> Datas_Locadas {get; set;}

    public EspacoTipoEnum Tipo {get;set;}

    public Espaco(string nome, int capacit, EspacoTipoEnum tipo){
        Nome = nome;
        Capacidade = capacit;
        Locado = false;
        Datas_Locadas = new List<DateTime>();
        Tipo = tipo;
    }
}
