using SQLite;

namespace NoivaCiaApp.entity
{
    [Table("ItemEntity")]
    public class ItemFestaEntity : Entity
    {

        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public override int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("value")]
        public float Value { get; set; }
        [Column("tipoCasamento")]
        public int TipoCasamento { get; set; }
        [Column("tipoItem")]
        public int TipoItem { get; set; }
    }
}
