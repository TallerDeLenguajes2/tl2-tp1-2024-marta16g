using System;
using EspacioCadete;

namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private string? nombre;
        private ulong numero;
        private List<Cadete>? listaCadetes;
        public string? Nombre { get => nombre; set => nombre = value; }
        public ulong Numero { get => numero; set => numero = value; }
        public List<Cadete>? ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public Cadeteria(){}
        public Cadeteria(string nombre, ulong numero, List<Cadete> listaCadetes)
        {
            this.nombre = nombre;
            this.numero = numero;
            this.listaCadetes = listaCadetes;
        }
    }
}