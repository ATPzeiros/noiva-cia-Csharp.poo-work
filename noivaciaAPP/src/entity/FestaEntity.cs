using NoivaCiaApp.entity;
using SQLite;

namespace noivaCiaApp.entity
{

    [Table("FestaEntity")]
    class FestaEntity : Entity
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public override int Id { get; set; }

        [Column("tipo")]
        public int Tipo { get; set; }

        [Column("fk_espaco")]
        public int EspacoId { get; set; }

        [Column("day")]
        public int Day { get; set; }

        [Column("month")]
        public int Month { get; set; }

        [Column("year")]
        public int Year { get; set; }
    }
}