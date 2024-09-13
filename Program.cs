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
        int opcion = gestion.MostrarMenu();
        if(opcion == 1)
        {
            gestion.VerPedidos();
        }
    }
}


