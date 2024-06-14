namespace NoivaCiaApp.model
{
  public class EspacoBase: Model
  {
    public string? Nome { get; set; }
    public int CapacidadeMax { get; set; }
    public int Valor { get; set; }
    public EspacoTipoEnum Tipo { get; set; }
  }
}