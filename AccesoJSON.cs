using System;
using EspacioAccesoADatos;

namespace EspacioAccesoJSON
{
    public class AccesoJson : AccesoADatos
    {
        public abstract override void LeerArchivos(string nombreArchivo)
        {
            base.LeerArchivos(nombreArchivo);
        }
    }
}