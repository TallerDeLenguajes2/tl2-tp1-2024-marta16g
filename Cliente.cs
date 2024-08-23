using System;

namespace EspacioCliente
{
    public class Cliente
    {
        private string nombre;
        private ulong telefono;
        private string direccion;
        private string datosReferenciaDireccion;

        public string Nombre { get => nombre; set => nombre = value; }
        public ulong Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

        public Cliente(string nombre, ulong telefono, string direccion, string referencia)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            this.datosReferenciaDireccion = referencia;
        }
    }
}