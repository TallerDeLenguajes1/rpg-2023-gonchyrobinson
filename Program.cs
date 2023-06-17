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
        }
        else
        {
            var Equipo = new Equipos();
            for (int i = 0; i < 10; i++)
            {
                Equipo = creadorEquipos.CreadorEquipos();
                foreach (var eq in listadoEquipos)
                {
                    while(eq.Nombre()==Equipo.Nombre())
                    {
                        Equipo =creadorEquipos.CreadorEquipos();
                    }
                }
                listadoEquipos.Add(Equipo);
            }
            persistencia.GuardarPersonajes(listadoEquipos, nombreArchivo);
        }
        Console.WriteLine("\n=========================================EQUIPOS=====================================\n");
        int k = 1;
        foreach (var equipo in listadoEquipos)
        {
            Console.WriteLine("\t\t\t\tEQUIPO " + k);
            Console.WriteLine("\n_______________________________________________________________\n");
            Console.WriteLine(equipo.Mostrar());
            Console.WriteLine("\n_______________________________________________________________\n");
            Console.WriteLine("\n");
            k++;
        }
        Console.WriteLine("\n\n\n///////////////////////////\tCOMIENZA EL JUEGO\t///////////////////////////\n");
        Console.WriteLine("\tSe asignaran 2 equipos al azar, los cuales jugarán entre ellos. Serán 3 enfrentamientos: Delantero vs Defensa o Arquero, Defensa o Arquero vs Delantero, Mediocampo vs Mediocampo. Cada enfrentamiento, será una jugada al azar, pueden ser jugadas de mucho o poco peligro, las cuales influirán en la efectividad o probabilidad de meter gol para el equipo que ataca. Se realizarán 3 jugadas. En caso de empate, cada jugador tendrá una jugada de ataque y una de defensa hasta que uno marque y el otro falle que se terminará el partido. El ganador, será el equipo que termina con más goles");

        Random rand = new Random();
        int eq1 = rand.Next(0, 10);
        Equipos equipo1 = listadoEquipos[eq1];
        Console.WriteLine("\t\t\t---Equipo 1:  " + equipo1.Nombre() + "\n");
        Console.WriteLine(equipo1.Mostrar());
        int eq2 = rand.Next(0, 10);
        while (eq2 == eq1)
        {
            eq2 = rand.Next(0, 10);
        }
        Equipos equipo2 = listadoEquipos[eq2];
        Console.WriteLine("\n....................................................................................\n");
        Console.WriteLine("\t\t\t---Equipo2:" + equipo2.Nombre() + "\n");
        Console.WriteLine(equipo2.Mostrar());
        
        
    }
    public enum Jugada
    {
        penal = 1,
        tiroLibre = 2,
        frenteAFrente = 3,
        saqueDelMedio = 4,
        saqueDelArco = 5,
        corner = 6,
        otra = 7
    }
    public double Efectividad(Jugada jugada)
    {
        double efectividad;
        switch (jugada)
        {
            case Jugada.penal:
                efectividad = 75;
                break;
            case Jugada.frenteAFrente:
                efectividad = 70;
                break;
            case Jugada.saqueDelArco:
                efectividad = 25;
                break;
            case Jugada.saqueDelMedio:
                efectividad = 30;
                break;
            case Jugada.tiroLibre:
                efectividad = 60;
                break;
            case Jugada.corner:
                efectividad = 40;
                break;
            default:
                efectividad = 50;
                break;
        }
        return (efectividad);
    }
    public string JugadaAleatoria(Jugada jugada)
    {
        string jugadaSTR;
        switch (jugada)
        {
            case Jugada.penal:
                jugadaSTR = "Penal";
                break;
            case Jugada.frenteAFrente:
                jugadaSTR = "Frente a frente";
                break;
            case Jugada.saqueDelArco:
                jugadaSTR = "Saque del arco";
                break;
            case Jugada.saqueDelMedio:
                jugadaSTR = "Saque del medio";
                break;
            case Jugada.tiroLibre:
                jugadaSTR = "Tiro Libre";
                break;
            case Jugada.corner:
                jugadaSTR = "Corner";
                break;
            default:
                jugadaSTR = "Otro";
                break;
        }
        return (jugadaSTR);
    }


    public void JuegaJugadaDelanteroVsDefensa(Equipos equipo1, Equipos equipo2)
    {
        Console.WriteLine("\n- Presiona una tecla para jugar la jugada: ");
        string? tecla = Console.ReadLine();
        Random rand = new Random();
        Jugada jugada = (Jugada)rand.Next(0, 8);
        double efectividad = Efectividad(jugada);
        Console.WriteLine("\n\t\tJugada: " + JugadaAleatoria(jugada));
        double ataque = equipo1.Delantero.Ataque(efectividad);
        Console.WriteLine("\n\nAtaca: " + equipo1.Delantero.Nombre() + "puntos de ataque para esta jugada:  " + ataque);
        double defensa = equipo2.DefensaOArquero.Defensa(efectividad);
        Console.WriteLine("\n\nDefiende: " + equipo2.DefensaOArquero.Nombre() + "puntos de defensa para esta jugada:  " + defensa);
        if (ataque > defensa)
        {
            Console.WriteLine("\nGOL DEL DELANTERO DE " + equipo1.Nombre() + "\n");
            equipo1.Goles += 1;
        }
        else
        {
            if (ataque < defensa)
            {
                Console.WriteLine("\nNo fue gol, gana el defensa");
            }
            else
            {
                ataque = equipo2.DefensaOArquero.Ataque((1 - efectividad));
                defensa = equipo1.Delantero.Defensa(efectividad);
                if (ataque < defensa)
                {
                    Console.WriteLine("\nGOL DEL DEFENSOR (contrataque)" + equipo2.Nombre() + "\n");
                    equipo2.Goles += 1;
                }
                else
                {
                    Console.WriteLine("\nNo fue gol, pero el delantero frena el contrataque");
                }
            }
        }
    }
    public void JuegaJugadaMediocampoVsMediocampo(Equipos equipo1, Equipos equipo2)
    {
        double ataque1 = equipo1.Mediocampo.Ataque(50);
        double ataque2 = equipo2.Mediocampo.Ataque(50);
        if (ataque1 > ataque2)
        {
            Console.WriteLine("\nAtaca el equipo: " + equipo1.Nombre());
            Console.WriteLine("\n\nAtaca: " + equipo1.Mediocampo.Nombre());
            Console.WriteLine("\n\nDefiende: " + equipo2.Mediocampo.Nombre());
            MediovsMedio(equipo1, equipo2);

        }
        else
        {
            if (ataque2 > ataque1)
            {
                Console.WriteLine("\nAtaca el equipo:  " + equipo2.NombreEquipo);
                Console.WriteLine("\n\nAtaca: " + equipo2.Mediocampo.Nombre());
                Console.WriteLine("\n\nDefiende: " + equipo1.Mediocampo.Nombre());
                MediovsMedio(equipo2, equipo1);
            }
            else
            {
                double defensa1 = equipo1.Mediocampo.Defensa(50);
                double defensa2 = equipo2.Mediocampo.Defensa(50);
                if (defensa1 > defensa2)
                {
                    Console.WriteLine("\nAtaca el equipo: " + equipo1.Nombre());
                    Console.WriteLine("\n\nAtaca: " + equipo1.Mediocampo.Nombre());
                    Console.WriteLine("\n\nDefiende: " + equipo2.Mediocampo.Nombre());
                    MediovsMedio(equipo1, equipo2);
                }
                else
                {
                    if (defensa2 > defensa1)
                    {
                        Console.WriteLine("\nAtaca el equipo:  " + equipo2.NombreEquipo);
                        Console.WriteLine("\n\nAtaca: " + equipo2.Mediocampo.Nombre());
                        Console.WriteLine("\n\nDefiende: " + equipo1.Mediocampo.Nombre());
                        MediovsMedio(equipo2, equipo1);
                    }
                    else
                    {
                        Console.WriteLine("\nNingun jugador pudo generar una ocación, por lo tanto, competirán otros 2 jugadores");
                    }
                }
            }
        }

    }
    public void MediovsMedio(Equipos equipo1, Equipos equipo2)
    {
        Console.WriteLine("\n- Presiona una tecla para jugar la jugada: ");
        string? tecla = Console.ReadLine();
        Random rand = new Random();
        Jugada jugada = (Jugada)rand.Next(0, 8);
        double efectividad = Efectividad(jugada);
        Console.WriteLine("\n\t\tJugada: " + JugadaAleatoria(jugada));
        double ataque = equipo1.Mediocampo.Ataque(efectividad);
        Console.WriteLine("\n\nAtaca: " + equipo1.Mediocampo.Nombre() + "puntos de ataque para esta jugada:  " + ataque);
        double defensa = equipo2.Mediocampo.Defensa(efectividad);
        Console.WriteLine("\n\nDefiende: " + equipo2.Mediocampo.Nombre() + "puntos de defensa para esta jugada:  " + defensa);
        if (ataque > defensa)
        {
            Console.WriteLine("\nGOL DEL DELANTERO DE " + equipo1.Nombre() + "\n");
            equipo1.Goles += 1;
        }
        else
        {
            if (ataque < defensa)
            {
                Console.WriteLine("\nNo fue gol, gana el defensa");
            }
            else
            {
                ataque = equipo2.Mediocampo.Ataque((1 - efectividad));
                defensa = equipo1.Mediocampo.Defensa(efectividad);
                if (ataque < defensa)
                {
                    Console.WriteLine("\nGOL DEL DEFENSOR (contrataque)" + equipo2.Nombre() + "\n");
                    equipo2.Goles += 1;
                }
                else
                {
                    Console.WriteLine("\nNo fue gol, pero el delantero frena el contrataque");
                }
            }
        }
    }

}
