using System;
using EspacioPersonajes;
internal class Program
{
    private static void Main(string[] args)
    {
        var creadorPersonajes = new fabricaPersonaje();
        var jugador1 = new Personaje();
        jugador1 = creadorPersonajes.CrearPersonaje(2);
        Console.WriteLine(jugador1.Mostrar());
    }
}
