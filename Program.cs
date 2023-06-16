using System;
using EspacioPersonajes;
using EspacioEquipos;
using EspacioPersistenciaDeDatos;
using System.Collections.Generic;
internal class Program
{
    private static void Main(string[] args)
    {
        var persistencia = new PersonajesJSON();
        var creadorEquipos = new FabricaEquipos();
        string nombreArchivo = @"personajesJSON.json";
        List<Equipos> listadoEquipos = new List<Equipos>();
        if (persistencia.Existe(nombreArchivo))
        {
            listadoEquipos = persistencia.LeerPersonajes(nombreArchivo);
        }else
        {
            var Equipo = new Equipos();
            for (int i = 0; i < 10; i++)
            {
                Equipo = creadorEquipos.CreadorEquipos();
                listadoEquipos.Add(Equipo);
            }
            persistencia.GuardarPersonajes(listadoEquipos, nombreArchivo);
        }
    Console.WriteLine("\n=========================================EQUIPOS=====================================\n");
    foreach (var equipo in listadoEquipos)
    {
        Console.WriteLine("\n");
        Console.WriteLine(equipo.Mostrar());
        Console.WriteLine("\n");
    }
    }

}
