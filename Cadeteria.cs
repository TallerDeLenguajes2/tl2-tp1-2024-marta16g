using System;

namespace EspacioCadeteria
{
    public class Cadeteria 
    {
        private string nombre;
        private ulong numero;

        public string Nombre { get => nombre; set => nombre = value; }
        public ulong Numero { get => numero; set => numero = value; }
    }
}