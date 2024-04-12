class Espaco {
    public string Nome {get; set;}
    public int Capacidade {get; set;}
    public bool Locado {get; set;}
    public List<DateTime> Datas_Locadas {get; set;}

    public EspacoTipoEnum Tipo {get;set;}

    public Espaco(string Nome, int Capacidade, EspacoTipoEnum Tipo){
        this.Nome = Nome;
        this.Capacidade = Capacidade;
        this.Tipo = Tipo;
        Locado = false;
        Datas_Locadas = new List<DateTime>();
    }
}
