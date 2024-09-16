using System;
using EspacioCadete;
using EspacioFuncionesCsv;
using EspacioPedido;

namespace EspacioGestion
{
    public class Gestion()
    {

        public static int ValidarEntrada(string input, int min, int max)
        {
            if (int.TryParse(input, out int operacion) && operacion < max && operacion > min)
            {
                return operacion;
            }
            else
            {
                return 0;
            }

        }
        public void MostrarMenu()
        {
            Console.WriteLine("MENÚ");
            Console.WriteLine("1) Dar de alta pedidos");
            Console.WriteLine("2) Asignar pedido a cadete");
            Console.WriteLine("3) Reasignar pedido a cadete");
            Console.WriteLine("4) Cambiar estado de pedido");
        }

        public void ManejoDeOperaciones(int operacion)
        {
            switch (operacion)
            {
                case 1:
                    DarDeAltaPedido();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        public void DarDeAltaPedido()
        {
            VerPedidos();
            Console.WriteLine("Escriba");
        }

        public void AsignarPedidoACadete(int id, Pedido pedido)
        {
            List<Cadete> listaCadetes = FuncionesCsv.ConvertirCadete(FuncionesCsv.LeerArchivos("Cadete.csv", ','));
            Cadete cadeteEncontrado = listaCadetes.Find(cad => cad.Id == id);
            if (cadeteEncontrado != null)
            {
                cadeteEncontrado.ListadoDePedidos.Add(pedido);
            }
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
        public void verCadetes()
        {
            List<string[]> listaCadetes = new();
            listaCadetes = FuncionesCsv.LeerArchivos("Cadetes.csv", ',');
            for (int i = 0; i < listaCadetes.Count; i++)
            {
                for (int j = 0; j < listaCadetes[i].Length; j++)
                {
                    Console.WriteLine(listaCadetes[i][j]);
                }
            }
        }
    }
}