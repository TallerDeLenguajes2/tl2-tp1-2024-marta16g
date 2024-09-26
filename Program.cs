using EspacioCadete;
using EspacioCadeteria;
using EspacioCliente;
using EspacioPedido;
using EspacioAccesoCSV;
using EspacioGestion;

class Program
{
    private static void Main(string[] args)
    {
        const string rutaCadeteria = "csv/Cadeteria.csv";
        const string rutaCadetes = "csv/Cadetes.csv";
        const string rutaPedidos = "csv/Pedidos.csv";

        Cadeteria miCadeteria = AccesoCSV.ConvertirCadeteria(AccesoCSV.LeerArchivos(rutaCadeteria, ','));
        List<Cadete> listaCadetes = AccesoCSV.ConvertirCadete(AccesoCSV.LeerArchivos(rutaCadetes, ','));
        List<Pedido> listaPedidos = AccesoCSV.ConvertirPedidos(AccesoCSV.LeerArchivos(rutaPedidos, ','));

        miCadeteria.ListaCadetes = listaCadetes;
        miCadeteria.ListaPedidos = listaPedidos;

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
                    Gestion.DarDeAltaPedido(listaPedidos, rutaPedidos);
                    break;
                case 2:
                    Console.WriteLine("Ingrese el id del cadete");
                    int idCadete = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el id del pedido");
                    int idPedido = int.Parse(Console.ReadLine());
                    miCadeteria.AsignarCadeteAPedido(idCadete, idPedido);
                    break;
                case 3:
                    miCadeteria.ReasignarCadeteAPedido(miCadeteria);
                    break;
                case 4:
                    Gestion.CambiarEstadoAPedido(rutaPedidos);
                    break;
                case 5:
                    Gestion.MostrarInforme(miCadeteria, listaPedidos);
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


