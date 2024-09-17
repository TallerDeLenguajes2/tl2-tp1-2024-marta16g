using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using EspacioPedido;
using EspacioCadete;
using EspacioCadeteria;

namespace EspacioFuncionesCsv
{
    public class FuncionesCsv
    {
        public static List<string[]> LeerArchivos(string nombreArchivo, char caracter)
        {
            List<string[]> archivoLeido = new();
            string? linea = "";
            using (FileStream miArchivo = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (StreamReader lector = new StreamReader(miArchivo))
                {
                    while ((linea = lector.ReadLine()) != null)
                    {
                        String[] fila = linea.Split(caracter);
                        archivoLeido.Add(fila);
                    }
                }
            }
            return archivoLeido;
        }

        public static void AgregarLinea(string nombreArchivo, string linea)
        {
            using (FileStream miArchivo = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter escritor = new StreamWriter(miArchivo))
                {
                    escritor.WriteLine(linea);
                }
            }
        }
        public static Cadeteria ConvertirCadeteria(string[]Fila)
        {
            Cadeteria miCadeteria = new Cadeteria();

            miCadeteria.Nombre = Fila[0];
            miCadeteria.Numero = ulong.Parse(Fila[0]);

            return miCadeteria;

        }

        public static List<Cadete> ConvertirCadete(List<string[]> Filas)
        {
            List<Cadete> misCadetes = new List<Cadete>();
            foreach (string[] fila in Filas)
            {
                Cadete cad = new Cadete(int.Parse(fila[0]), fila[1], fila[2], ulong.Parse(fila[3]));
                misCadetes.Add(cad);
            }
            return misCadetes;
        }

        public static List<Pedido> ConvertirPedidos(List<string[]> Filas)
        {
            List<Pedido> misPedidos = new List<Pedido>();
            foreach (string[] fila in Filas)
            {
                Pedido ped = new Pedido(int.Parse(fila[0]), fila[1], fila[2], ulong.Parse(fila[3]), fila[4], fila[5], (EnumPedido)Enum.Parse(typeof(EnumPedido), fila[6]));
                misPedidos.Add(ped);
            }
            return misPedidos;
        }

        public static string CrearLineaDePedidos(Pedido pedido)
        {
            string linea = $"{pedido.Nro.ToString()},{pedido.Obs},{pedido.Cliente.Nombre},{pedido.Cliente.Telefono.ToString()},{pedido.Cliente.Direccion},{pedido.Cliente.DatosReferenciaDireccion},{pedido.Estado.ToString()}";
            return linea;
        }
        public static void ReescribirArchivoCsv(List<Pedido> pedidos, string nombreArchivo)
        {
            using (StreamWriter sw = new StreamWriter(nombreArchivo, false))
            {
                foreach (var pedido in pedidos)
                {
                    string linea = FuncionesCsv.CrearLineaDePedidos(pedido);
                    sw.WriteLine(linea);
                }
            }
        }
    }
}