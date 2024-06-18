namespace NoivaCiaApp.model
{
  public class EspacoBase: Model
  {
    public int Id { get; set;}
    public string? Nome { get; set; }
    public int CapacidadeMax { get; set; }
    public int Valor { get; set; }
    public EspacoTipoEnum Tipo { get; set; }
  }
}