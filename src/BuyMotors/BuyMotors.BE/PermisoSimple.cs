using System;
using System.Collections.Generic;

namespace BuyMotors.BE
{
    public class PermisoSimple : Permiso
    {
        public override void AgregarPermisoHijo(Permiso permiso)
        {
            // Nunca debe llamarse a esto
            throw new NotImplementedException();
        }

        public override List<Permiso> DevolverPerfil()
        {
            return new List<Permiso>();
        }
    }
}
