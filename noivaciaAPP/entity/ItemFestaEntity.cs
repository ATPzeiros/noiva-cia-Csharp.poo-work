using SQLite;

[Table("ItemFestaEntity")]
class ItemFestaEntity {

    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id {get;set;}
    [Column("name")]
    public string? Name {get;set;}
    [Column("value")]
    public float Value {get;set;}
    [Column("tipoCasamento")]
    public int TipoCasamento{get;set;}
    [Column("tipoItem")]
    public int TipoItem{get;set;}
}