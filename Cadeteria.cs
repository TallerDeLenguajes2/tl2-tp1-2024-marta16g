using System;
using EspacioCadete;
using EspacioPedido;

namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private string? nombre;
        private ulong numero;
        private List<Cadete>? listaCadetes;
        private List<Pedido>? listaPedidos;
        public string? Nombre { get => nombre; set => nombre = value; }
        public ulong Numero { get => numero; set => numero = value; }
        public List<Cadete>? ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public List<Pedido>? ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
        public Cadeteria(){}
        public Cadeteria(string nombre, ulong numero)
        {
            this.nombre = nombre;
            this.numero = numero;
            this.listaCadetes = new();
            this.listaPedidos = new();
        }

        public float JornalACobrar(int idCadete)
        {
            List<Pedido> pedidosEntregados = listaPedidos.FindAll(p => p.Estado == EnumPedido.Completado);
            List<Pedido> pedidosDelCadete = pedidosEntregados.FindAll(p => p.Cadete.Id == idCadete);
            return 500 * pedidosDelCadete.Count;
        }
    }
}