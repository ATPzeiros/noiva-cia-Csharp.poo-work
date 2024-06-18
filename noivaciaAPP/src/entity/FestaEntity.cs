using NoivaCiaApp.entity;
using SQLite;

class FestaEntity : Entity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public override int Id { get; set; }

    [Column("fk_espaco")]
    int FkEspaco { get; set; }
    [Column("categoria")]
    int Categoria { get; set; }
    [Column("tipo_evento")]
    int TipoEvento { get; set; }
    [Column("qnt_convidados")]
    int QuantidadeConvidados { get; set; }
}