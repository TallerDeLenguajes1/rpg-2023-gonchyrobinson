using System;
using System.IO;
using System.Collections.Generic;
using EspacioPersonajes;
using EspacioEquipos;
using System.Text.Json;
using System.Net;

namespace EspacioPersistenciaDeDatos
{
    class PersonajesJSON
    {
        public void GuardarPersonajes(List<Equipos> equipos, string rutaArchivo)
        {
            FileStream archivo = new FileStream(rutaArchivo, FileMode.OpenOrCreate);
            var serializado = JsonSerializer.Serialize(equipos);
            using (var strWriter = new StreamWriter(archivo))
            {
                strWriter.WriteLine("{0}", serializado);
                strWriter.Close();
            }
        }
        public List<Equipos> LeerPersonajes(string rutaArchivo)
        {
            FileStream archivo = new FileStream(rutaArchivo, FileMode.Open);
            string? archivosLeidos;
            using (var strReader = new StreamReader(archivo))
            {
                archivosLeidos = strReader.ReadToEnd();
                strReader.Close();
            }
            var listadoEquipos = JsonSerializer.Deserialize<List<Equipos>>(archivosLeidos);
            return (listadoEquipos);
        }
        public bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                var archivo = new FileStream(nombreArchivo, FileMode.Open);
                using (var strReader = new StreamReader(archivo))
                {
                    string lineas = strReader.ReadToEnd();
                    if (lineas != "")
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                }
            }
            else
            {
                return (false);
            }
        }
        public Competencias GetCompetencias()
        {
            var url = $"http://api.football-data.org/v4/competitions/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string token = "c139f9a526184b62b0667a46dd8855f1"; // Reemplaza "tu_token" con tu token real
            request.Headers.Add("X-Auth-Token", token);
            Competencias? datosLeidos = null;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return (datosLeidos);
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string datosString = objReader.ReadToEnd();
                            datosLeidos = JsonSerializer.Deserialize<Competencias>(datosString);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
            }
            return (datosLeidos);
        }
    }
}