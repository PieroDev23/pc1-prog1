namespace bolsaApp.Models;

public class OperacionBolsa
{
    public required string Nombre { get; set; }
    public required string Correo { get; set; }
    public DateTime FechaOperacion { get; set; }
    public bool SP500 { get; set; }
    public bool DowJones { get; set; }
    public bool BonosUS { get; set; }
    public decimal MontoAbonar { get; set; }

    // Campos calculados
    public decimal IGV { get; set; }
    public decimal Comision { get; set; }
    public decimal Total { get; set; }
}