using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

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
                    while((linea = lector.ReadLine()) != null)
                    {
                        String[] fila = linea.Split(caracter);
                        archivoLeido.Add(fila);
                    }
                }
            }
            return archivoLeido;
        }
    }
}