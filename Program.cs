using EspacioCadete;
using EspacioCadeteria;
using EspacioCliente;
using EspacioPedido;
using EspacioFuncionesCsv;
using EspacioGestion;

class Program
{
    private static void Main(string[] args)
    {
        Cadeteria miCadeteria = FuncionesCsv.ConvertirCadeteria(FuncionesCsv.LeerArchivos("csv/Cadeteria.csv", ','));
        List<Cadete> listaCadetes = FuncionesCsv.ConvertirCadete(FuncionesCsv.LeerArchivos("csv/Cadetes.csv", ','));
        List<Pedido> listaPedidos = FuncionesCsv.ConvertirPedidos(FuncionesCsv.LeerArchivos("csv/Pedidos.csv", ','));

        miCadeteria.ListaCadetes = listaCadetes;

        Console.WriteLine("BIENVENIDO");
        Console.WriteLine($"----Cadetería: {miCadeteria.Nombre}, {miCadeteria.Numero}----");

        int operacion;
        while (true)
        {

            do
            {
                Gestion.MostrarMenu();
                Console.WriteLine("Elija la operación:");
                string input = Console.ReadLine();
                operacion = Gestion.ValidarEntrada(input, 0, 7);
            } while (operacion == 0);

            switch (operacion)
            {
                case 1:
                    Gestion.DarDeAltaPedido();
                    break;
                case 2:
                    Gestion.AsignarPedidoACadete(miCadeteria, listaPedidos, listaCadetes);
                    break;
                case 3:
                    Gestion.ReasignarPedidoACadete(miCadeteria, listaCadetes);
                    break;
                case 4:
                    Gestion.CambiarEstadoAPedido();
                    break;
                case 5: Gestion.MostrarInforme(miCadeteria, listaPedidos);
                break;
                case 6:
                    Console.WriteLine("Nos vemos!");
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }
}


