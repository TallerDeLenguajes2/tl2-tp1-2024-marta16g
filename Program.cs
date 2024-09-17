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
        Gestion gestion = new Gestion();
        gestion.Inicializar();
        Console.WriteLine("BIENVENIDO");

        int operacion;
        do
        {
            gestion.MostrarMenu();
            Console.WriteLine("Elija la operación:");
            string input = Console.ReadLine();
            operacion = Gestion.ValidarEntrada(input, 0, 5);
        } while (operacion == 0);

        gestion.ManejoDeOperaciones(operacion);
        
    }
}


