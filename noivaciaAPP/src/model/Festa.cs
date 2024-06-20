using NoivaCiaApp.model;

public class Festa: Model
{
    public int Id {get;set;}
    public Espaco? Espaco {get;set;}

    public TipoEventoEnum Tipo {get;set;}

    public TipoCategoria Categoria {get;set;}

    public int QuantidadeConvidados {get;set;}

    public List<ItemFesta> Items {get;set;} = new List<ItemFesta>();

    public DateTime Date {get;set;} = DateTime.Now;

    public Festa(Espaco? Espaco, TipoEventoEnum Tipo, TipoCategoria Categoria, int QuantidadeConvidados, List<ItemFesta> Items){
        this.Espaco = Espaco;
        this.Tipo = Tipo;
        this.Categoria = Categoria;
        this.QuantidadeConvidados = QuantidadeConvidados;
        this.Items = Items;
    }

    public Festa(int Id, TipoEventoEnum Tipo, TipoCategoria Categoria, int QuantidadeConvidados, DateTime Date){
        this.Id = Id;
        this.Tipo = Tipo;
        this.Categoria = Categoria;
        this.QuantidadeConvidados = QuantidadeConvidados;
        this.Date = Date;
    }
}