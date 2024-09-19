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
        // Gestion gestion = new Gestion();
        // gestion.Inicializar();
        Cadeteria miCadeteria = FuncionesCsv.ConvertirCadeteria(FuncionesCsv.LeerArchivos("csv/Cadeteria.csv", ','));
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
                operacion = Gestion.ValidarEntrada(input, 0, 6);
            } while (operacion == 0);

            switch (operacion)
            {
                case 1:
                    Gestion.DarDeAltaPedido();
                    break;
                case 2:
                    Gestion.AsignarPedidoACadete(miCadeteria);
                    break;
                case 3:
                    Gestion.ReasignarPedidoACadete(miCadeteria);
                    break;
                case 4:
                    Gestion.CambiarEstadoAPedido();
                    break;
                case 5:
                    Console.WriteLine("Nos vemos!");
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }

        }
    }
}


