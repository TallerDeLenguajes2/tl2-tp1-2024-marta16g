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

        public void AsignarCadeteAPedido(int idCadete, int idPedido)
        {
            List<Pedido> pedidosPendientes = listaPedidos.FindAll(p => p.Estado == EnumPedido.Pendiente);
            Cadete cadeteEncontrando = listaCadetes.Find(c => c.Id == idCadete);
            Pedido pedidoEncontrado = pedidosPendientes.Find(p => p.Nro == idPedido);
            if(cadeteEncontrando != null)
            {
                if(pedidoEncontrado != null)
                {
                    pedidoEncontrado.Cadete = cadeteEncontrando;
                    Console.WriteLine("Asignación exitosa");
                }else{
                    Console.WriteLine("El pedido no fue encontrado");
                }
            }else
            {
                Console.WriteLine("El cadete no fue encontrado");
            }
        }
    }
}