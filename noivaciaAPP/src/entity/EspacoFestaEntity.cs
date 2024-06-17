using SQLite;

namespace NoivaCiaApp.entity
{
    [Table("EspacoFestaEntity")]
    public class EspacoFestaEntity : Entity{
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public override int Id { get; set; }
        [Column("nome")]
        public string? nome { get; set; }
        [Column("capacidadeMax")]
        public int capacidadeMax { get; set; }
        [Column("valor")]
        public int valor { get; set; }
        [Column("tipo")]
        public int TipoItem { get; set; }
    }
}