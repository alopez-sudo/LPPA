namespace BuyMotors.BE
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public TipoVehiculo Tipo { get; set; }
		public CategoriaVehiculo Categoria { get; set; }
		public Color Color { get; set; }
        public Modelo Modelo { get; set; }
        public int Precio { get; set; }
        public int AnioFabricacion { get; set; }
		public string ImagenNombre { get; set; }
		public string Descripcion
		{
			get
			{
				return string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6}", Patente, Tipo.Nombre, Categoria.Nombre, Modelo.Marca.Nombre, Modelo.Nombre, Color.Nombre, AnioFabricacion);
			}
		}
	}
}
