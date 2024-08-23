using System;

namespace EspacioCliente
{
    public class EspacioCliente
    {
        private string nombre;
        private ulong telefono;
        private string direccion;
        private string DatosReferenciaDireccion;

        public string Nombre { get => nombre; set => nombre = value; }
        public ulong Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string DatosReferenciaDireccion1 { get => DatosReferenciaDireccion; set => DatosReferenciaDireccion = value; }
    }
}