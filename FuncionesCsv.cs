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
            List<Cadete> MisCadetes = new List<Cadete>();
            foreach (string[] filas in Filas)
            {
                Cadete cad = new Cadete(int.Parse(filas[0]), filas[1], filas[2], ulong.Parse(filas[3]));
                MisCadetes.Add(cad);
            }
            return MisCadetes;
        }
    }
}