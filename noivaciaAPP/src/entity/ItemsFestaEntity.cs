using NoivaCiaApp.entity;
using SQLite;

[Table("ItemsFestaEntity")]
class ItemsFestaEntity : Entity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public override int Id { get; set; }
    [Column("fk_festa")]
    public int Fk_Festa { get; set; }
    [Column("fk_item")]
    public int Fk_Item { get; set; }
    public int Quantidade { get; set; }
}