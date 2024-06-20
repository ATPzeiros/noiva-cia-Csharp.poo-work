using NoivaCiaApp.entity;
using SQLite;

[Table("FestaEntity")]
public class FestaEntity : Entity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public override int Id { get; set; }

    [Column("fk_espaco")]
    public int FkEspaco { get; set; }
    [Column("categoria")]
    public int Categoria { get; set; }
    [Column("tipo_evento")]
    public int TipoEvento { get; set; }
    [Column("valor")]
    public float Valor { get; set; }
    [Column("data")]
    public DateTime ? Data{get; set;}
}