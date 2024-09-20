using System;
using EspacioCadete;
using EspacioGestion;
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
        public Cadeteria() { }
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
            List<Pedido> pedidosDelCadete = pedidosEntregados.FindAll(p => (p.Cadete != null && p.Cadete.Id == idCadete));
            if (pedidosDelCadete != null && pedidosEntregados != null)
            {
                return 500 * pedidosDelCadete.Count;
            }else
            {
                return 0;
            }
        }

        public void AsignarCadeteAPedido(int idCadete, int idPedido)
        {
            List<Pedido> pedidosPendientes = listaPedidos.FindAll(p => p.Estado == EnumPedido.Pendiente && p.Cadete == null);
            Cadete cadeteEncontrado = listaCadetes.Find(c => c.Id == idCadete);
            Pedido pedidoEncontrado = pedidosPendientes.Find(p => p.Nro == idPedido);
            if (cadeteEncontrado != null)
            {
                if (pedidoEncontrado != null)
                {
                    pedidoEncontrado.Cadete = cadeteEncontrado;
                    Console.WriteLine("Asignación exitosa");
                    Console.WriteLine($"Se asignó el pedido de {pedidoEncontrado.Cliente.Nombre} al cadete {cadeteEncontrado.Nombre}");
                }
                else
                {
                    Console.WriteLine("El pedido no fue encontrado");
                }
            }
            else
            {
                Console.WriteLine("El cadete no fue encontrado");
            }
        }

        public void ReasignarCadeteAPedido(Cadeteria miCadeteria)
        {
            Console.WriteLine("Operación: Reasignar pedido a cadete");
            Console.WriteLine("MOSTRANDO CADETES Y SUS PEDIDOS");
            Gestion.VerCadetes(ListaCadetes);
            Console.WriteLine("Escriba el id del cadete cuyo pedido quiere mover");
            string idCadete1 = Console.ReadLine();
            Cadete cadete1 = ListaCadetes.Find(cad => cad.Id == int.Parse(idCadete1));
            if (cadete1 != null)
            {
                Console.WriteLine("Ingrese el id del pedido");
                string idPedido = Console.ReadLine();
                Pedido pedidoEncontrado = ListaPedidos.Find(ped => ped.Nro == int.Parse(idPedido) && ped.Estado != EnumPedido.Completado && ped.Estado != EnumPedido.Cancelado);
                if (pedidoEncontrado != null)
                {
                    Console.WriteLine("Escriba el id del nuevo cadete");
                    string idCadete2 = Console.ReadLine();
                    Cadete cadete2 = ListaCadetes.Find(cad => cad.Id == int.Parse(idCadete2));
                    if (cadete2 != null)
                    {
                        pedidoEncontrado.Cadete = cadete2;
                        Console.WriteLine($"Reasignación exitosa. El cadete del pedido número {pedidoEncontrado.Nro} es {pedidoEncontrado.Cadete.Nombre}");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el segundo cadete");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró el pedido che");
                }
            }
            else
            {
                Console.WriteLine("No se encontró el cadete");
            }
        }
    }
}