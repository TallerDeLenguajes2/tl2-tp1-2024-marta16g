using System;
using EspacioPedido;

namespace EspacioCadete
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private ulong telefono;
        private List<Pedido> listadoDePedidos;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public ulong Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoDePedidos { get => listadoDePedidos; set => listadoDePedidos = value; }

        public int JornalACobrar()
        {
            return listadoDePedidos.Count() * 500;
        }

        public Cadete(int id, string nombre, string direccion, ulong telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.listadoDePedidos = new();
        }
        public Cadete(int id, string nombre, string direccion, ulong telefono, List<Pedido> listadoDePedidos)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.listadoDePedidos = listadoDePedidos;
        }
    }
}