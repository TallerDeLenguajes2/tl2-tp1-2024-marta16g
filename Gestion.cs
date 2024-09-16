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
            Console.WriteLine("Escriba el nombre del cliente");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escriba el teléfono del cliente");
            string telefono = Console.ReadLine();
            Console.WriteLine("Escriba la dirección del cliente");
            string direccion = Console.ReadLine();
            Console.WriteLine("Escriba detalles de la dirección");
            string detalles = Console.ReadLine();
            Console.WriteLine("Escriba la observacion");
            string observacion = Console.ReadLine();
            

            List<Pedido> pedidosCsv = FuncionesCsv.ConvertirPedido(FuncionesCsv.LeerArchivos("csv/Pedidos.csv", ','));
            int ultimoNum = pedidosCsv.Last().Nro;

            Pedido nuevoPedido = new Pedido(ultimoNum++, observacion, nombre, ulong.Parse(telefono), direccion, detalles, (EnumPedido)1);

            FuncionesCsv.AgregarLinea("csv/Pedidos.csv", FuncionesCsv.CrearLineaDePedidos(nuevoPedido));
            Console.WriteLine("Pedido dado en alta exitósamente");
            
        }

        public void AsignarPedidoACadete(int id, Pedido pedido)
        {
            List<Cadete> listaCadetes = FuncionesCsv.ConvertirCadete(FuncionesCsv.LeerArchivos("csv/Cadete.csv", ','));
            Cadete cadeteEncontrado = listaCadetes.Find(cad => cad.Id == id);
            if (cadeteEncontrado != null)
            {
                cadeteEncontrado.ListadoDePedidos.Add(pedido);
            }
        }
        public void VerPedidos()
        {
            List<string[]> listaPedidos = new();
            listaPedidos = FuncionesCsv.LeerArchivos("csv/Pedido.csv", ',');
            for (int i = 0; i < listaPedidos.Count; i++)
            {
                for (int j = 0; j < listaPedidos[i].Length; j++)
                {
                    Console.WriteLine(listaPedidos[i][j]);
                }
            }
        }
        public void VerCadetes()
        {
            List<Cadete> listaCadetes = new();
            listaCadetes = FuncionesCsv.ConvertirCadete(FuncionesCsv.LeerArchivos("csv/Cadete.csv", ','));
            foreach (Cadete cad in listaCadetes)
            {
                Console.WriteLine($"--CADETE--\n Id: {cad.Id} \n Nombre: {cad.Nombre} \n Teléfono: {cad.Telefono} \n Dirección: {cad.Direccion}");
            }
        }
    }
}