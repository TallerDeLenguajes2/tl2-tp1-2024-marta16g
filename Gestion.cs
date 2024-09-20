using System;
using EspacioCadete;
using EspacioCadeteria;
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
        public static void MostrarMenu()
        {
            Console.WriteLine("MENÚ");
            Console.WriteLine("1) Dar de alta pedidos");
            Console.WriteLine("2) Asignar pedido a cadete");
            Console.WriteLine("3) Reasignar pedido a cadete");
            Console.WriteLine("4) Cambiar estado de pedido");
            Console.WriteLine("5) Ver informe");
            Console.WriteLine("6) Salir del sistema");
        }

        public static void DarDeAltaPedido(List<Pedido> listaPedidos, string rutaPedidos)
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


            // List<Pedido> pedidosCsv = FuncionesCsv.ConvertirPedidos(FuncionesCsv.LeerArchivos(rutaPedidos, ','));
            if (listaPedidos == null || listaPedidos.Count == 0)
            {
                Console.WriteLine("viene vacío");
            }
            else
            {
                int ultimoNum = listaPedidos.Last().Nro;

                Pedido nuevoPedido = new Pedido(ultimoNum + 1, observacion, nombre, ulong.Parse(telefono), direccion, detalles, EnumPedido.Pendiente);

                FuncionesCsv.AgregarLinea(rutaPedidos, FuncionesCsv.CrearLineaDePedidos(nuevoPedido));
                Console.WriteLine("Pedido dado en alta exitosamente");
            }

        }



        public static void CambiarEstadoAPedido(string rutaPedidos)
        {
            Console.WriteLine("Operación: Cambiar estado del pedido");
            Console.WriteLine("Ingrese id del pedido");
            string id = Console.ReadLine();

            List<Pedido> listaPedidos = FuncionesCsv.ConvertirPedidos(FuncionesCsv.LeerArchivos(rutaPedidos, ','));
            Pedido pedidoEncontrado = listaPedidos.Find(ped => ped.Nro == int.Parse(id));
            if (pedidoEncontrado == null)
            {
                Console.WriteLine("No se pudo encontrar el pedido");
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

                FuncionesCsv.ReescribirArchivoCsv(listaPedidos, rutaPedidos);
                Console.WriteLine("Estado modificado exitosamente");

            }
        }
        public static void MostrarInforme(Cadeteria miCadeteria, List<Pedido> listaPedidos)
        {
            Console.WriteLine("Lista de pedidos:");
            VerPedidos(listaPedidos);
            Console.WriteLine();
            Console.WriteLine("Pedidos entregados:");
            VerPedidos(listaPedidos.FindAll(p => p.Estado == EnumPedido.Completado));

            float totalMonto = 0;
            int cantEnvios = 0;
            foreach (var cad in miCadeteria.ListaCadetes)
            {
                float jornalCadete = miCadeteria.JornalACobrar(cad.Id);
                Console.WriteLine($"Jornal del cadete {cad.Nombre}: ${totalMonto}");
                // Console.WriteLine($"Cantidad de envíos del cadete {cad.Nombre}: {cantEnvios}");
                // cantEnvios = 0;
                totalMonto += jornalCadete;
            }

            Console.WriteLine($"Monto total ganado: ${totalMonto}");
        }
        public static void VerPedidos(List<Pedido> listaPedidos)
        {
            for (int i = 0; i < listaPedidos.Count; i++)
            {
                Console.WriteLine($"PEDIDO NÚMERO {i + 1}");
                Console.WriteLine($"ID: {listaPedidos[i].Nro}");
                Console.WriteLine($"Cliente: {listaPedidos[i].Cliente.Nombre}, {listaPedidos[i].Cliente.Direccion}");
                if (listaPedidos[i].Cadete != null)
                {
                    Console.WriteLine($"Pedido del cadete: {listaPedidos[i].Cadete.Nombre} de id {listaPedidos[i].Cadete.Id}");
                }
            }
        }
        public static void VerCadetes(List<Cadete> listaCadetes)
        {
            foreach (Cadete cad in listaCadetes)
            {
                Console.WriteLine($"--CADETE {cad.Id}--\n Nombre: {cad.Nombre} \n Teléfono: {cad.Telefono} \n Dirección: {cad.Direccion}");
                Console.WriteLine();
            }
        }

    }
}