
using NoivaCiaApp.entity;
using SQLite;

[Table("FestaItemEntity")]
class FestaItemsEntity: Entity
{

    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public override int Id { get; set; }
    
    [Column("fk_festa")]
    public int Fk_festa {get;set;}

    [Column("fk_item")]
    public int Fk_item {get;set;}
    
    [Column("quantidade")]
    public int Quantidade {get;set;}
}