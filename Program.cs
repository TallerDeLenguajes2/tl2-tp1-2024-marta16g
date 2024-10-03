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
        const string rutaCadeteriaCsv = "csv/Cadeteria.csv";
        const string rutaCadetesCsv = "csv/Cadetes.csv";
        const string rutaPedidosCsv = "csv/Pedidos.csv";
        const string rutaCadeteriaJson = "json/Cadeteria.json";
        const string rutaCadetesJson = "json/Cadetes.json";
        const string rutaPedidosJson = "json/Pedidos.json";



        Cadeteria cadeteria = new();
        List<Cadete> listaCadetes = new();
        List<Pedido> listaPedidos = new();

        Gestion gestion = new();

        Console.WriteLine("Elija que tipo de archivo utilizar para traer los datos: 1) CSV, 2) JSON");
        int tipoArchivo = int.Parse(Console.ReadLine());
        AsignarArchivos();
        void AsignarCsv()
        {
            AccesoCSV accesoCsv = new();
            cadeteria = accesoCsv.ConvertirCadeteria(rutaCadeteriaCsv, rutaCadetesCsv, rutaPedidosCsv);
            listaCadetes = accesoCsv.ConvertirCadetes(rutaCadetesCsv);
            listaPedidos = accesoCsv.ConvertirPedidos(rutaPedidosCsv);
        }

        void AsignarJson()
        {
            AccesoJSON accesoJson = new();
            cadeteria = accesoJson.ConvertirCadeteria(rutaCadeteriaJson, rutaCadetesJson, rutaPedidosJson);
            listaCadetes = accesoJson.ConvertirCadetes(rutaCadetesJson);
            listaPedidos = accesoJson.ConvertirPedidos(rutaPedidosJson);
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
                    bool estado = Gestion.DarDeAltaPedido(listaPedidos, rutaPedidosCsv);
                    if(estado)
                    {
                        Console.WriteLine("Alta de pedido exitosa");
                    }else
                    {
                        Console.WriteLine("¡Oh no! Algo ocurrió mal");
                    }
                    break;
                case 2:
                    Console.WriteLine("Ingrese el id del cadete");
                    int idCadete = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el id del pedido");
                    int idPedido = int.Parse(Console.ReadLine());
                    AsignarArchivos(); //Para actualizar datos que fueron reescritos en los archivos
                    estado = cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
                    if(estado)
                    {
                        Console.WriteLine("Asignación exitosa");
                    }else
                    {
                        Console.WriteLine("¡Oh no! Algo ocurrió mal");
                    }
                    break;
                case 3:
                    estado = cadeteria.ReasignarCadeteAPedido();
                    if(estado)
                    {
                        Console.WriteLine("Reasignación exitosa");
                    }else
                    {
                        Console.WriteLine("¡Oh no! Algo ocurrió mal");
                    }
                    break;
                case 4:
                    estado = Gestion.CambiarEstadoAPedido(rutaPedidosCsv);
                    if(estado)
                    {
                        Console.WriteLine("Cambio de estado exitoso");
                    }else
                    {
                        Console.WriteLine("¡Oh no! Algo ocurrió mal");
                    }
                    break;
                case 5:
                    AsignarArchivos(); //Para actualizar datos que fueron reescritos en los archivos
                    gestion.MostrarInforme(cadeteria, listaPedidos);
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


