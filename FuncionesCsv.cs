using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using EspacioPedido;
using EspacioCadete;

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

        public static List<Pedido> ConvertirPedido(List<string[]> Filas)
        {
            List<Pedido> misPedidos = new List<Pedido>();
            foreach (string[] fila in Filas)
            {
               Pedido ped = new Pedido(int.Parse(fila[0]), fila[1], fila[2], ulong.Parse(fila[3]), fila[4], fila[5], (EnumPedido)Enum.Parse(typeof(EnumPedido), fila[6]));
            }
            return misPedidos;
        }

        public static string[] CrearLineaDePedidos(Pedido pedido)
        {
            string[] linea = [];

            linea[0] = (pedido.Nro).ToString();
            linea[1] = pedido.Obs;
            linea[2] = pedido.Cliente.Nombre;
            linea[3] = pedido.Cliente.Telefono.ToString();
            linea[4] = pedido.Cliente.Direccion;
            linea[5] = pedido.Cliente.DatosReferenciaDireccion;
            linea[6] = pedido.Estado.ToString();

            return linea;
        }
    }
}