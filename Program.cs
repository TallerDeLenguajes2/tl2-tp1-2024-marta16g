using EspacioCadete;
using EspacioCadeteria;
using EspacioCliente;
using EspacioPedido;

class Program
{
    private static void Main(string[] args)
    {
        Cadeteria cadeteria = new Cadeteria();
        cadeteria.Nombre = "Pedidos Ya";
        cadeteria.Numero = 12345;
        Console.WriteLine("BIENVENIDO");
        Console.WriteLine(cadeteria.Nombre);


    }
}


