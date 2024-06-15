using NoivaCiaApp.entity;
using SQLite;

namespace noivaCiaApp.entity{

    [Table("EspacoEntity")]
    class EspacoEntity : Entity
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public override int Id { get; set; }
    }
}