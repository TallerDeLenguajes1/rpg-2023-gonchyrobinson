using System;
using EspacioPersonajes;
using EspacioEquipos;
internal class Program
{
    private static void Main(string[] args)
    {
        var creadorEquipos = new FabricaEquipos();
        var equipo = new Equipos();
        equipo = creadorEquipos.CreadorEquipos();
        Console.WriteLine(equipo.Mostrar());
    }
}
