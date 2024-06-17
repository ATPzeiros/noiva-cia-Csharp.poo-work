using SQLite;

namespace NoivaCiaApp.entity
{
    [Table("ItemEntity")]
    public class ItemEntity : Entity
    {

        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public override int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("value")]
        public float Value { get; set; }
        [Column("tipoFesta")]
        public int TipoFesta { get; set; }
        [Column("tipoItem")]
        public int TipoItem { get; set; }
        [Column("tipoServico")]
        public int? TipoServico { get; set; } = null;
    }
}
