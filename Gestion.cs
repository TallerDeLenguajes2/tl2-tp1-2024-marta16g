using System;
using EspacioCadete;
using EspacioCadeteria;
using EspacioFuncionesCsv;
using EspacioPedido;

namespace EspacioGestion
{
    public class Gestion()
    {
        const string rutaPedidos = "csv/Pedidos.csv";
        const string rutaCadetes = "csv/Cadetes.csv";
        const string rutaCadeteria = "csv/Cadeteria.csv";
        // Cadeteria miCadeteria = FuncionesCsv.ConvertirCadeteria(FuncionesCsv.LeerArchivos(rutaCadeteria, ','));
        // List<Cadete> listaCadetes = FuncionesCsv.ConvertirCadete(FuncionesCsv.LeerArchivos(rutaCadetes, ','));

        // public void Inicializar()
        // {
        //     miCadeteria.ListaCadetes = listaCadetes;
        // }

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

        public static void DarDeAltaPedido()
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


            List<Pedido> pedidosCsv = FuncionesCsv.ConvertirPedidos(FuncionesCsv.LeerArchivos(rutaPedidos, ','));
            if (pedidosCsv == null || pedidosCsv.Count == 0)
            {
                Console.WriteLine("viene vacío");
            }
            else
            {
                int ultimoNum = pedidosCsv.Last().Nro;

                Pedido nuevoPedido = new Pedido(ultimoNum + 1, observacion, nombre, ulong.Parse(telefono), direccion, detalles, EnumPedido.Pendiente);

                FuncionesCsv.AgregarLinea(rutaPedidos, FuncionesCsv.CrearLineaDePedidos(nuevoPedido));
                Console.WriteLine("Pedido dado en alta exitosamente");
            }

        }

        public static void AsignarPedidoACadete(Cadeteria miCadeteria, List<Pedido> listaPedidos, List<Cadete> listaCadetes)
        {
            VerCadetes(listaCadetes);

            Console.WriteLine("Operación: Asignar pedido a cadete");
            Console.WriteLine("Ingrese el id del cadete");
            string idCadete = Console.ReadLine();
            Console.WriteLine("Ingrese el id del pedido");
            string idPedido = Console.ReadLine();

            Cadete cadeteEncontrado = miCadeteria.ListaCadetes.Find(cad => cad.Id == int.Parse(idCadete));
            if (cadeteEncontrado != null)
            {
                Pedido pedidoEncontrado = listaPedidos.Find(ped => ped.Nro == int.Parse(idPedido));
                if (pedidoEncontrado != null)
                {
                    cadeteEncontrado.ListadoDePedidos.Add(pedidoEncontrado);
                    Console.WriteLine($"Se le asignó a {cadeteEncontrado.Nombre} el pedido número {pedidoEncontrado.Nro} exitosamente");
                }
                else
                {
                    Console.WriteLine("Id de pedido no encotrado");
                }
            }
            else
            {
                Console.WriteLine("Id de cadete no encontrado");
            }
        }

        public static void ReasignarPedidoACadete(Cadeteria miCadeteria, List<Cadete> listaCadetes)
        {
            Console.WriteLine("Operación: Reasignar pedido a cadete");
            Console.WriteLine("MOSTRANDO CADETES Y SUS PEDIDOS");
            VerCadetes(listaCadetes);
            Console.WriteLine("Escriba el id del cadete cuyo pedido quiere mover");
            string idCadete1 = Console.ReadLine();
            Cadete cadete1 = miCadeteria.ListaCadetes.Find(cad => cad.Id == int.Parse(idCadete1));
            if (cadete1 != null)
            {
                Console.WriteLine("Ingrese el id del pedido");
                string idPedido = Console.ReadLine();
                Pedido pedidoEncontrado = cadete1.ListadoDePedidos.Find(ped => ped.Nro == int.Parse(idPedido));
                if (pedidoEncontrado != null)
                {
                    Console.WriteLine("Escriba el id del nuevo cadete");
                    string idCadete2 = Console.ReadLine();
                    Cadete cadete2 = miCadeteria.ListaCadetes.Find(cad => cad.Id == int.Parse(idCadete2));
                    if (cadete2 != null)
                    {
                        cadete2.ListadoDePedidos.Add(pedidoEncontrado);
                        cadete1.ListadoDePedidos.Remove(pedidoEncontrado);
                        Console.WriteLine("Reasignación exitosa");
                        Console.WriteLine($"Pedidos de {cadete1.Nombre}: ");
                        VerPedidos(cadete1.ListadoDePedidos);
                        Console.WriteLine($"Pedidos de {cadete2.Nombre}: ");
                        VerPedidos(cadete2.ListadoDePedidos);
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró el pedido che");
                }
            }
        }
        public static void CambiarEstadoAPedido()
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
                foreach (var ped in cad.ListadoDePedidos)
                {
                    if (ped.Estado == EnumPedido.Completado)
                    {
                        totalMonto += cad.JornalACobrar();
                        cantEnvios += 1;
                    }
                }
                Console.WriteLine($"Cantidad de envíos del cadete {cad.Nombre}: {cantEnvios}");
                cantEnvios = 0;
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
            }
        }
        public static void VerCadetes(List<Cadete> listaCadetes)
        {
            foreach (Cadete cad in listaCadetes)
            {
                Console.WriteLine($"--CADETE {cad.Id}--\n Nombre: {cad.Nombre} \n Teléfono: {cad.Telefono} \n Dirección: {cad.Direccion}");
                Console.WriteLine("--Lista de pedidos--");
                VerPedidos(cad.ListadoDePedidos);
                Console.WriteLine();
            }
        }

    }
}