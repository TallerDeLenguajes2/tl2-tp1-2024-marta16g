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
        int operacion = 0;
        Gestion gestion = new Gestion();

        Console.WriteLine("BIENVENIDO");
 
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


