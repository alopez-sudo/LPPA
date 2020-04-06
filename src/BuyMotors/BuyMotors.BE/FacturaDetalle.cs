namespace BuyMotors.BE
{
    public class FacturaDetalle
    {
        public int Id { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
