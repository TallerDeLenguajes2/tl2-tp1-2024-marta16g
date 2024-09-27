using EspacioCadete;
using EspacioCadeteria;
using EspacioCliente;
using EspacioPedido;
using EspacioGestion;
using EspacioAccesoADatos;

class Program
{
    private static void Main(string[] args)
    {
        const string rutaCadeteria = "csv/Cadeteria.csv";
        const string rutaCadetes = "csv/Cadetes.csv";
        const string rutaPedidos = "csv/Pedidos.csv";

        Cadeteria cadeteria = new();
        List<Cadete> listaCadetes = new();
        List<Pedido> listaPedidos = new();

        Console.WriteLine("Elija que tipo de archivo utilizar para traer los datos: 1) CSV, 2) JSON");
        int tipoArchivo = int.Parse(Console.ReadLine());
        AsignarArchivos();
        void AsignarCsv()
        {
            AccesoCSV accesoCsv = new();
            cadeteria = accesoCsv.ConvertirCadeteria(rutaCadeteria, rutaCadetes, rutaPedidos);
            listaCadetes = accesoCsv.ConvertirCadetes(rutaCadetes);
            listaPedidos = accesoCsv.ConvertirPedidos(rutaPedidos);
        }

        void AsignarJson()
        {
            AccesoJSON accesoJson = new();
            cadeteria = accesoJson.ConvertirCadeteria(rutaCadeteria, rutaCadetes, rutaPedidos);
            listaCadetes = accesoJson.ConvertirCadetes(rutaCadetes);
            listaPedidos = accesoJson.ConvertirPedidos(rutaPedidos);
        }

        void AsignarArchivos()
        {

            if (tipoArchivo == 1)
            {
                AsignarCsv();
            }
            else
            {
                if (tipoArchivo == 2)
                {
                    AsignarJson();
                }
                else
                {
                    Console.WriteLine("El tipo de archivo elegido no existe");
                }

            }
        }

        Console.WriteLine("BIENVENIDO");
        Console.WriteLine($"----Cadetería: {cadeteria.Nombre}, {cadeteria.Numero}----");

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
                    AsignarArchivos(); //Para actualizar datos que fueron reescritos en los archivos
                    Gestion.DarDeAltaPedido(listaPedidos, rutaPedidos);
                    break;
                case 2:
                    Console.WriteLine("Ingrese el id del cadete");
                    int idCadete = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el id del pedido");
                    int idPedido = int.Parse(Console.ReadLine());
                    AsignarArchivos(); //Para actualizar datos que fueron reescritos en los archivos
                    cadeteria.AsignarCadeteAPedido(idCadete, idPedido, listaPedidos);
                    break;
                case 3:
                    cadeteria.ReasignarCadeteAPedido(cadeteria);
                    break;
                case 4:
                    Gestion.CambiarEstadoAPedido(rutaPedidos);
                    break;
                case 5:
                    AsignarArchivos(); //Para actualizar datos que fueron reescritos en los archivos
                    Gestion.MostrarInforme(cadeteria, listaPedidos);
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


