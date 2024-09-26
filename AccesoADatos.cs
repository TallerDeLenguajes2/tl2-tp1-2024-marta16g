using System;
using System.Text.Json;
using EspacioCadete;
using EspacioCadeteria;
using EspacioPedido;

namespace EspacioAccesoADatos
{
    public abstract class AccesoADatos
    {
        public abstract List<Cadete> ConvertirCadetes(string nombreArchivo);
        public abstract Cadeteria ConvertirCadeteria(string nombreArchivo);
        public abstract List<Pedido> ConvertirPedidos(string nombreArchivo);
    }
    public class AccesoCSV : AccesoADatos
    {
        public static List<string[]> LeerCsv(string nombreArchivo, char caracter)
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


        public override Cadeteria ConvertirCadeteria(string nombreArchivo)
        {
            Cadeteria miCadeteria = new Cadeteria();
            List<string[]> fila = LeerCsv(nombreArchivo, ',');
            foreach (string[] i in fila)
            {
                miCadeteria.Nombre = i[0];
                miCadeteria.Numero = ulong.Parse(i[1]);
            }
            miCadeteria.ListaCadetes = ConvertirCadetes(nombreArchivo);
            miCadeteria.ListaPedidos = ConvertirPedidos(nombreArchivo);
            return miCadeteria;
        }
        public override List<Cadete> ConvertirCadetes(string nombreArchivo)
        {
            List<Cadete> misCadetes = new List<Cadete>();
            List<string[]> filas = LeerCsv(nombreArchivo, ',');
            foreach (string[] fila in filas)
            {
                Cadete cad = new Cadete(int.Parse(fila[0]), fila[1], fila[2], ulong.Parse(fila[3]));
                misCadetes.Add(cad);
            }
            return misCadetes;
        }
        public override List<Pedido> ConvertirPedidos(string nombreArchivo)
        {
            List<Pedido> misPedidos = new List<Pedido>();
            List<string[]> filas = LeerCsv(nombreArchivo, ',');
            foreach (string[] fila in filas)
            {
                Pedido ped = new Pedido(int.Parse(fila[0]), fila[1], fila[2], ulong.Parse(fila[3]), fila[4], fila[5], (EnumPedido)Enum.Parse(typeof(EnumPedido), fila[6]));
                misPedidos.Add(ped);
            }

            return misPedidos;
        }
    }

    public class AccesoJSON : AccesoADatos
    {
        public static string LeerJson(string nombreArchivo)
        {
            string documento;
            using (FileStream miArchivo = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (StreamReader lector = new StreamReader(miArchivo))
                {
                    documento = lector.ReadToEnd();
                }
            }
            return documento;
        }
        public override Cadeteria ConvertirCadeteria(string nombreArchivo)
        {
            Cadeteria miCadeteria = new Cadeteria();
            string documentoJson = LeerJson(nombreArchivo);
            miCadeteria = JsonSerializer.Deserialize<Cadeteria>(documentoJson);
            miCadeteria.ListaCadetes = ConvertirCadetes(nombreArchivo);
            miCadeteria.ListaPedidos = ConvertirPedidos(nombreArchivo);
            
            return miCadeteria;
        }
        public override List<Cadete> ConvertirCadetes(string nombreArchivo)
        {
            List<Cadete> misCadetes = new List<Cadete>();
            string documentoJson = LeerJson(nombreArchivo);
            misCadetes = JsonSerializer.Deserialize<List<Cadete>>(documentoJson);

            return misCadetes;
        }

        public override List<Pedido> ConvertirPedidos(string nombreArchivo)
        {
            List<Pedido> misPedidos = new List<Pedido>();
            string documentoJson = LeerJson(nombreArchivo);
            misPedidos = JsonSerializer.Deserialize<List<Pedido>>(documentoJson);

            return misPedidos;
        }

    }


}
