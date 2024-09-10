
using System;
using System.Collections.Generic;
using System.IO;

namespace EspacioDatos
{
    public class GestorCsv
    {
        // metodo para cargar los cadetes desde un archivo CSV
        public List<Cadete> CargarCadetesDesdeCsv(string archivoCsv)
        {
            List<Cadete> cadetes = new List<Cadete>();

            try
            {
                using (StreamReader sr = new StreamReader(archivoCsv))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] campos = linea.Split(',');

                        int id = int.Parse(campos[0]); // sigue siendo int
                        string nombre = campos[1];
                        string direccion = campos[2];

                        // asignar el telefono directamente como string
                        string telefono = campos[3].Trim();

                        Cadete cadete = new Cadete(id, nombre, direccion, telefono);
                        cadetes.Add(cadete);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar cadetes: {ex.Message}");
            }

            return cadetes;
        }

        // metodo para cargar la cadetería desde un archivo CSV
        public Cadeteria CargarCadeteriaDesdeCsv(string archivoCsv)
        {
            Cadeteria cadeteria = null;

            try
            {
                using (StreamReader sr = new StreamReader(archivoCsv))
                {
                    string linea = sr.ReadLine();  // Solo lee la primera linea  que contiene los datos de la cadeteria

                    if (linea != null)
                    {
                        string[] campos = linea.Split(',');

                        // llamo al constructor, tiene 2 campos
                        string nombre = campos[0].Trim();
                        // asignar el telefono directamente como string
                        string telefono = campos[1].Trim();

                        cadeteria = new Cadeteria(nombre, telefono);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar cadetería: {ex.Message}");
            }

            return cadeteria;
        }
    }
}
