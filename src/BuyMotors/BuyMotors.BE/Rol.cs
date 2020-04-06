using System.Collections.Generic;

namespace BuyMotors.BE
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Permiso> Permisos { get; set; }
    }
}
