using NoivaCiaApp.entity;
using SQLite;

public class EspacoEntity : Entity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public override int Id {get;set;}

    [Column("name")]
    public string Nome { get; set; } = "";
    [Column("capacidade")]
    public int CapacidadeMax { get; set; }
    [Column("valor")]
    public int Valor { get; set; }
    [Column("tipo")]
    public int Tipo {get;set;}

}