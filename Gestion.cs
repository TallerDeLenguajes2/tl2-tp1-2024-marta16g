using System;
using EspacioFuncionesCsv;
using EspacioPedido;

namespace EspacioGestion
{
    public class Gestion()
    {

        public bool ValidarEntrada(string input, int min, int max)
        {
            if(int.TryParse(input, out int operacion) && operacion < max && operacion > min)
            {
                return true;
            }else{
                return false;
            }
            
        }
        public void MostrarMenu()
        {
            Console.WriteLine("MENÚ");
            Console.WriteLine("1) Ver Pedidos");
            Console.WriteLine("2) Ver lista de cadetes");
            Console.WriteLine("3) Asignar pedido a cadete");
            Console.WriteLine("4) Cambiar estado de pedido");
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