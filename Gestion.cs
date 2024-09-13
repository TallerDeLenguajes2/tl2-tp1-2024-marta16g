using System;
using EspacioFuncionesCsv;
using EspacioPedido;

namespace EspacioGestion
{
    public class Gestion()
    {
        public void Comienzo()
        {
            Console.WriteLine("Probando csv");
            List<string[]> listaFilas = new();
            listaFilas = FuncionesCsv.LeerArchivos("Pedido.csv", ',');
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < listaFilas[i].Length; j++)
                {
                Console.WriteLine(listaFilas[i][j]);
                    
                }
            }
        }
    }
}