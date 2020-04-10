using System.Collections.Generic;

namespace BuyMotors.BE
{
    public abstract class Permiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public abstract void AgregarPermisoHijo(Permiso permiso);

        public abstract List<Permiso> DevolverPerfil();

        public class Comparador : IEqualityComparer<Permiso>
        {
            public bool Equals(Permiso x, Permiso y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode(Permiso obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
