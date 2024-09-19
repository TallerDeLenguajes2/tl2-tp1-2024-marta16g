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
        
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public ulong Telefono { get => telefono; set => telefono = value; }
        

        

        public Cadete(int id, string nombre, string direccion, ulong telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        public Cadete(int id, string nombre, string direccion, ulong telefono, List<Pedido> listadoDePedidos)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }
    }
}