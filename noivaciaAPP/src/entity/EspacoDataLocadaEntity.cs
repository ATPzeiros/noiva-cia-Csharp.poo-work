using NoivaCiaApp.entity;
using SQLite;


class EspacoDataLocadaEntity : Entity
{

    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public override int Id { get; set; }

    [Column("fk_festa")]
    int FkFesta { get; set; }

    [Column("day")]
    int Day { get; set; }

    [Column("month")]
    int Month { get; set; }
    
    [Column("year")]
    int Year { get; set; }
}