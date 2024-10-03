using System;
using EspacioCadete;
using EspacioCadeteria;
// using EspacioAccesoCSV;
using EspacioPedido;
using EspacioAccesoADatos;

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
        public static string MostrarMenu()
        {
            return ("MENÚ \n 1) Dar de alta pedidos \n 2) Asignar pedido a cadete \n 3) Reasignar pedido a cadete \n 4) Cambiar estado de pedido \n 5) Ver informe \n 6) Salir del sistema \n");
        }

        public static bool DarDeAltaPedido(List<Pedido> listaPedidos, string rutaPedidos)
        {
            Console.WriteLine("Operación: Dar de alta un pedido");
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


            if (listaPedidos == null || listaPedidos.Count == 0)
            {
                return false;

            }
            else
            {
                int ultimoNum = listaPedidos.Last().Nro;

                Pedido nuevoPedido = new Pedido(ultimoNum + 1, observacion, nombre, ulong.Parse(telefono), direccion, detalles, EnumPedido.Pendiente);

                AccesoCSV.AgregarLinea(rutaPedidos, AccesoCSV.CrearLineaDePedidos(nuevoPedido));
                return true;

            }

        }



        public static bool CambiarEstadoAPedido(string rutaPedidos)
        {
            AccesoCSV accesoCsv = new AccesoCSV();
            Console.WriteLine("Operación: Cambiar estado del pedido");
            Console.WriteLine("Ingrese id del pedido");
            string id = Console.ReadLine();

            List<Pedido> listaPedidos = accesoCsv.ConvertirPedidos(rutaPedidos);
            Pedido pedidoEncontrado = listaPedidos.Find(ped => ped.Nro == int.Parse(id));
            if (pedidoEncontrado == null)
            {
                return false;

            }
            else
            {
                int estadoNum = 0;
                do
                {
                    Console.WriteLine("Elija el nuevo estado: 1) Pendiente, 2) En proceso, 3) Completado, 4) Cancelado");
                    string estado = Console.ReadLine();
                    estadoNum = int.Parse(estado);
                } while (estadoNum < 1 || estadoNum > 4);
                pedidoEncontrado.Estado = (EnumPedido)estadoNum;

                AccesoCSV.ReescribirArchivoCsv(listaPedidos, rutaPedidos);
                return true;

            }
        }
        public void MostrarInforme(Cadeteria miCadeteria, List<Pedido> listaPedidos)
        {
            Console.WriteLine("Lista de pedidos:");
            List<string> listaTextualDePedidos = VerPedidos(listaPedidos);
            foreach(string pedido in listaTextualDePedidos)
            {
                Console.WriteLine(pedido);
            }
            Console.WriteLine("Pedidos entregados:");

            List<string> pedidosCompletados = VerPedidos(listaPedidos.FindAll(p => p.Estado == EnumPedido.Completado));
            foreach(string pedido in pedidosCompletados)
            {
                Console.WriteLine(pedido);
            }
            float totalMonto = 0;
            int cantEnvios = 0;
            foreach (var cad in miCadeteria.ListaCadetes)
            {
                float jornalCadete = miCadeteria.JornalACobrar(cad.Id, listaPedidos);
                Console.WriteLine($"Jornal del cadete {cad.Nombre}: ${totalMonto}");
                totalMonto += jornalCadete;
            }

            Console.WriteLine($"Monto total ganado: ${totalMonto}");
        }
        public List<string> VerPedidos(List<Pedido> listaPedidos)
        {
            List<string> listaTextualDePedidos = new();
            for (int i = 0; i < listaPedidos.Count; i++)
            {
                string lineaPedidoCadete = "";
                if (listaPedidos[i].Cadete != null)
                {
                    lineaPedidoCadete = $"Pedido a cargo de: {listaPedidos[i].Cadete.Nombre} de id {listaPedidos[i].Cadete.Id}";
                }else{
                    lineaPedidoCadete = "Sin cadete a cargo";
                }
                string lineai = $"PEDIDO NÚMERO {i + 1}/n ID: {listaPedidos[i].Nro}\n Cliente: {listaPedidos[i].Cliente.Nombre}, {listaPedidos[i].Cliente.Direccion} \n {lineaPedidoCadete}";
                listaTextualDePedidos.Add(lineai);
            }

            return listaTextualDePedidos;
        }
        public static List<string> VerCadetes(List<Cadete> listaCadetes)
        {
            List<string> listaTextualInfoCadetes = new();
            foreach (Cadete cad in listaCadetes)
            {
                string linea = $"--CADETE {cad.Id}--\n Nombre: {cad.Nombre} \n Teléfono: {cad.Telefono} \n Dirección: {cad.Direccion}\n";
                listaTextualInfoCadetes.Add(linea);
            }

            return listaTextualInfoCadetes;
        }

    }
}