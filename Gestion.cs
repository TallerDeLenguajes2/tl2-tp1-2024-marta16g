using System;
using EspacioFuncionesCsv;
using EspacioPedido;

namespace EspacioGestion
{
    public class Gestion()
    {

        public int MostrarMenu()
        {
            Console.WriteLine("MENÚ");
            Console.WriteLine("1) Ver Pedidos");
            Console.WriteLine("2) Ver lista de cadetes");
            Console.WriteLine("3) Asignar pedido a cadete");
            Console.WriteLine("4) Cambiar estado de pedido");
            return 6;
        }
        public void VerPedidos()
        {
            List<string[]> listaPedidos = new();
            listaPedidos = FuncionesCsv.LeerArchivos("Pedido.csv", ',');
            for (int i = 0; i < listaPedidos.Count; i++)
            {
                for (int j = 0; j < listaPedidos[i].Length; j++)
                {
                    Console.WriteLine(listaPedidos[i][j]);
                }
            }
        }
    }
}