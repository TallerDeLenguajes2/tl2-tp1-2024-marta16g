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
        Console.WriteLine("BIENVENIDO");
        gestion.MostrarMenu();
        Console.WriteLine("Elija la operación:");
        string input = Console.ReadLine();
        if(gestion.ValidarEntrada(input, 0, 5))
        {

        }else{
            
        }
    }
}


