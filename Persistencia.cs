using System;
using System.IO;
using System.Collections.Generic;
using EspacioPersonajes;
using EspacioEquipos;
using System.Text.Json;

namespace EspacioPersistenciaDeDatos
{
    class PersonajesJSON
    {
        public void GuardarPersonajes(List<Equipos> equipos, string rutaArchivo){
            FileStream archivo = new FileStream(rutaArchivo,FileMode.OpenOrCreate);
            var serializado = JsonSerializer.Serialize(equipos);
            using (var strWriter = new StreamWriter(archivo))
            {
                strWriter.WriteLine("{0}",serializado);
                strWriter.Close();
            }
        }
        public List<Equipos> LeerPersonajes(string rutaArchivo){
            FileStream archivo = new FileStream(rutaArchivo,FileMode.Open);
            string? archivosLeidos;
            using (var strReader = new StreamReader(archivo))
            {
                archivosLeidos = strReader.ReadToEnd();
                strReader.Close();
            }
            var listadoEquipos = JsonSerializer.Deserialize<List<Equipos>>(archivosLeidos);
            return(listadoEquipos);
        }
        public bool Existe(string nombreArchivo){
            if (File.Exists(nombreArchivo))
            {
                var archivo = new FileStream(nombreArchivo, FileMode.Open);
                using (var strReader = new StreamReader(archivo))
                {
                    string lineas = strReader.ReadToEnd();
                    if (lineas!="")
                    {
                        return(true);
                    }else
                    {
                        return(false);
                    }
                }
            }else
            {
                return(false);
            }
        }
    }
}