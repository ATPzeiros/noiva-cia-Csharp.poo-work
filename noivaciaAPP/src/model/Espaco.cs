using NoivaCiaApp.model;

public class Espaco: EspacoBase {
    public int qntConvidados {get; set;}
    public List<DateTime> Datas_Locadas {get; set;}

    public Espaco( string Nome, int CapacidadeMax, int Valor, EspacoTipoEnum Tipo){
        this.Nome = Nome;
        this.CapacidadeMax = CapacidadeMax;
        this.Valor = Valor;
        this.Tipo = Tipo;
        Datas_Locadas = new List<DateTime>();
    }
}
