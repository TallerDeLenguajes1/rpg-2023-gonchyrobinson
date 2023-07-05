using System;
using EspacioPersonajes;
using EspacioEquipos;
using EspacioPersistenciaDeDatos;
using System.Collections.Generic;

internal class Program
{

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
    public static double Efectividad(Jugada jugada)
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
    public static string JugadaAleatoria(Jugada jugada)
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


    public static void JuegaJugadaDelanteroVsDefensa(Equipos equipo1, Equipos equipo2)
    {
        Console.WriteLine("\n- Presiona una tecla para jugar la jugada: ");
        string? tecla = Console.ReadLine();
        Random rand = new Random();
        Jugada jugada = (Jugada)rand.Next(0, 8);
        double efectividad = Efectividad(jugada);
        Console.WriteLine("\t\tJugada: " + JugadaAleatoria(jugada));
        double ataque = equipo1.Delantero.Ataque(efectividad);
        Console.WriteLine("\nAtaca: " + equipo1.Delantero.Nombre() + " puntos de ataque para esta jugada:  " + ataque);
        double defensa = equipo2.DefensaOArquero.Defensa(100 - efectividad);
        Console.WriteLine("Defiende: " + equipo2.DefensaOArquero.Nombre() + " puntos de defensa para esta jugada:  " + defensa);
        if (ataque > defensa)
        {
            Console.WriteLine("GOL DEL DELANTERO DE " + equipo1.Nombre() + "\n");
            equipo1.Goles += 1;
        }
        else
        {
            if (ataque < defensa)
            {
                Console.WriteLine("No fue gol, gana el defensa");
            }
            else
            {
                ataque = equipo2.DefensaOArquero.Ataque((100 - efectividad));
                defensa = equipo1.Delantero.Defensa(efectividad);
                if (ataque < defensa)
                {
                    Console.WriteLine("GOL DEL DEFENSOR (contrataque)" + equipo2.Nombre() + "\n");
                    equipo2.Goles += 1;
                }
                else
                {
                    Console.WriteLine("No fue gol, pero el delantero frena el contrataque");
                }
            }
        }
    }
    public static void JuegaJugadaMediocampoVsMediocampo(Equipos equipo1, Equipos equipo2)
    {
        double ataque1 = equipo1.Mediocampo.Ataque(50);
        double ataque2 = equipo2.Mediocampo.Ataque(50);
        if (ataque1 > ataque2)
        {
            Console.WriteLine("\nAtaca el equipo: " + equipo1.Nombre());
            Console.WriteLine("Ataca: " + equipo1.Mediocampo.Nombre());
            Console.WriteLine("Defiende: " + equipo2.Mediocampo.Nombre());
            MediovsMedio(equipo1, equipo2);

        }
        else
        {
            if (ataque2 > ataque1)
            {
                Console.WriteLine("\nAtaca el equipo:  " + equipo2.NombreEquipo);
                Console.WriteLine("Ataca: " + equipo2.Mediocampo.Nombre());
                Console.WriteLine("Defiende: " + equipo1.Mediocampo.Nombre());
                MediovsMedio(equipo2, equipo1);
            }
            else
            {
                double defensa1 = equipo1.Mediocampo.Defensa(50);
                double defensa2 = equipo2.Mediocampo.Defensa(50);
                if (defensa1 > defensa2)
                {
                    Console.WriteLine("\nAtaca el equipo: " + equipo1.Nombre());
                    Console.WriteLine("Ataca: " + equipo1.Mediocampo.Nombre());
                    Console.WriteLine("Defiende: " + equipo2.Mediocampo.Nombre());
                    MediovsMedio(equipo1, equipo2);
                }
                else
                {
                    if (defensa2 > defensa1)
                    {
                        Console.WriteLine("\nAtaca el equipo:  " + equipo2.NombreEquipo);
                        Console.WriteLine("Ataca: " + equipo2.Mediocampo.Nombre());
                        Console.WriteLine("Defiende: " + equipo1.Mediocampo.Nombre());
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
    public static void MediovsMedio(Equipos equipo1, Equipos equipo2)
    {
        Console.WriteLine("\n- Presiona una tecla para jugar la jugada: ");
        string? tecla = Console.ReadLine();
        Random rand = new Random();
        Jugada jugada = (Jugada)rand.Next(0, 8);
        double efectividad = Efectividad(jugada);
        Console.WriteLine("\n\t\tJugada: " + JugadaAleatoria(jugada));
        double ataque = equipo1.Mediocampo.Ataque(efectividad);
        Console.WriteLine("Ataca: " + equipo1.Mediocampo.Nombre() + " puntos de ataque para esta jugada:  " + ataque);
        double defensa = equipo2.Mediocampo.Defensa(100 - efectividad);
        Console.WriteLine("Defiende: " + equipo2.Mediocampo.Nombre() + " puntos de defensa para esta jugada:  " + defensa);
        if (ataque > defensa)
        {
            Console.WriteLine("GOL DEL DELANTERO DE " + equipo1.Nombre() + "\n");
            equipo1.Goles += 1;
        }
        else
        {
            if (ataque < defensa)
            {
                Console.WriteLine("No fue gol, gana el defensa");
            }
            else
            {
                ataque = equipo2.Mediocampo.Ataque((100 - efectividad));
                defensa = equipo1.Mediocampo.Defensa(efectividad);
                if (ataque < defensa)
                {
                    Console.WriteLine("GOL DEL DEFENSOR (contrataque)" + equipo2.Nombre() + "\n");
                    equipo2.Goles += 1;
                }
                else
                {
                    Console.WriteLine("No fue gol, pero el delantero frena el contrataque");
                }
            }
        }
    }

    public static Equipos JuegaPartida(Equipos equipo1, Equipos equipo2)
    {
        string? avanzar;
        int factor;
        int aumentaONo;
        Random rand = new Random();
        Console.WriteLine("\t\t\t---Equipo 1:  " + equipo1.Nombre() + "\n");
        Console.WriteLine(equipo1.Mostrar());
        Console.WriteLine("\n....................................................................................\n");
        Console.WriteLine("\t\t\t---Equipo2:" + equipo2.Nombre() + "\n");
        Console.WriteLine(equipo2.Mostrar());
        Console.WriteLine("\n\nAtaca " + equipo1.Nombre() + ", Defiende" + equipo2.Nombre());
        JuegaJugadaDelanteroVsDefensa(equipo1, equipo2);
        Console.WriteLine("\n\nAtaca " + equipo2.Nombre() + ", Defiende" + equipo1.Nombre());
        JuegaJugadaDelanteroVsDefensa(equipo2, equipo1);
        Console.WriteLine("\n\nSe enfrentan mediocampos");
        JuegaJugadaMediocampoVsMediocampo(equipo1, equipo2);
        if (equipo1.GolesMarcados() > equipo2.GolesMarcados())
        {
            Console.WriteLine("\n\t\t--------EQUIPO GANADOR:  " + equipo1.Nombre());
            Console.WriteLine("RESULTADO FINAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + "- " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
            return (equipo1);
        }
        else
        {
            if (equipo2.GolesMarcados() > equipo1.GolesMarcados())
            {
                Console.WriteLine("\n\t\t--------EQUIPO GANADOR:  " + equipo2.Nombre());
                Console.WriteLine("RESULTADO FINAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + "- " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
                return (equipo2);
            }
            else
            {
                Console.WriteLine("\n\nDESEMPATE:  Se busca un reemplzo");
                while (equipo1.GolesMarcados() == equipo2.GolesMarcados())
                {
                    Console.WriteLine("Resultado Parcial:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + " - " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
                    Console.WriteLine("Presiona una tecla para dar indicaciones aleatorias al equipo: Si las indicaciones son:\n\tMuy buenas → aumentan en 2 todas las estadisticas de tus jugadores\n\tBuenas →aumentan en 1 todas las estadísticas de tus jugadores\n\tNeutrales, no modifcan el juego de tus jugadores\n\tMalas → Disminuyen 1 las estadisticas de tus jugadores\n\tMuy malas → Disminuyenn 2 puntos las estadisticas de tus jugadores");
                    avanzar = Console.ReadLine();
                    factor = rand.Next(1, 3);
                    aumentaONo = rand.Next(0, 3);
                    switch (aumentaONo)
                    {
                        case 0:
                            Console.WriteLine("No se modifican las estadisticas de tus jugadores");
                            break;
                        case 1:
                            Console.WriteLine("Buenas indicaciones, aumentan las estadisticas de tus jugadores en un factor: " + factor);
                            equipo1.AumentaEstadisticas(factor);
                            break;
                        case 2:
                            Console.WriteLine("Malas indicaciones, disminuyen las estadisticas de tus jugadores en un factor " + factor);
                            equipo2.DisminuyeEstadisticas(factor);
                            break;
                        default:
                            break;
                    }
                    JuegaJugadaDelanteroVsDefensa(equipo1, equipo2);
                    JuegaJugadaDelanteroVsDefensa(equipo2, equipo1);
                    JuegaJugadaMediocampoVsMediocampo(equipo1, equipo2);
                }
                if (equipo1.GolesMarcados() > equipo2.GolesMarcados())
                {
                    Console.WriteLine("\n\t\t--------EQUIPO GANADOR:  " + equipo1.Nombre());
                    Console.WriteLine("RESULTADO FINAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + "- " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
                    return (equipo1);
                }
                else
                {
                    Console.WriteLine("\n\t\t--------EQUIPO GANADOR:  " + equipo2.Nombre());
                    Console.WriteLine("RESULTADO FINAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + "- " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
                    return (equipo2);

                }
            }

        }

    }

    private static void Main(string[] args)
    {
        var persistencia = new PersonajesJSON();
        var creadorEquipos = new FabricaEquipos();
        string nombreArchivo = @"personajesJSON.json";
        List<Equipos> listadoEquipos = new List<Equipos>();
        var listadoJugadores = new List<Personaje>();
        if (persistencia.Existe(nombreArchivo))
        {
            listadoEquipos = persistencia.LeerPersonajes(nombreArchivo);
        }
        else
        {
            var Equipo = new Equipos();
            for (int i = 0; i < 10; i++)
            {
                Equipo = creadorEquipos.CreadorEquipos(listadoJugadores);
                foreach (var eq in listadoEquipos)
                {
                    while (eq.Nombre() == Equipo.Nombre())
                    {
                        listadoJugadores.Remove(Equipo.Delantero);
                        listadoJugadores.Remove(Equipo.DefensaOArquero);
                        listadoJugadores.Remove(Equipo.Mediocampo);
                        Equipo = creadorEquipos.CreadorEquipos(listadoJugadores);
                    }
                }
                listadoEquipos.Add(Equipo);
                // listadoJugadores.Add(Equipo.Delantero);
                // listadoJugadores.Add(Equipo.DefensaOArquero);
                // listadoJugadores.Add(Equipo.Mediocampo);
            }
            persistencia.GuardarPersonajes(listadoEquipos, nombreArchivo);
        }

        Console.WriteLine("\tSe asignaran 2 equipos, los cuales jugarán entre ellos. Serán 3 enfrentamientos: Delantero vs Defensa o Arquero, Defensa o Arquero vs Delantero, Mediocampo vs Mediocampo. Cada enfrentamiento, será una jugada al azar, pueden ser jugadas de mucho o poco peligro, las cuales influirán en la efectividad o probabilidad de meter gol para el equipo que ataca, las jugadas mas efectivas, aumentarán mas el ataque que la defensa y las menos efectivas aumentaran mas la defensa que el ataque. Se realizarán 3 jugadas. En caso de empate, cada jugador tendrá una jugada de ataque, una de defensa y un enfrentamiento entre mediocampos hasta que uno marque y el otro falle que se terminará el partido. A medida que se van produciendo empates, tu equipo recibirá una indicacion del entrenador que puede mejorar, disminuir o no modificar las estadistcas de los jugadores. El ganador, será el equipo que termina con más goles. Cuando un equipo gana, pasa a jugar la siguiente ronda, pero con un aumento de nivel que aumentara las posibilidades de ganar. El juego termina cuando un equipo vence a todos los equipos de la lista");
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

        Random rand = new Random();
        int eq1;
        Console.WriteLine("\nElije un equipo del 1 al 10\n");
        string? equipoEl = Console.ReadLine();
        if (int.TryParse(equipoEl, out eq1))
        {
            if (eq1 > 10 || eq1 < 0)
            {
                eq1 = rand.Next(0, 10);
            }

        }
        else
        {
            eq1 = rand.Next(0, 10);
        }
        Equipos equipo1 = listadoEquipos[eq1 - 1];
        listadoEquipos.Remove(equipo1);
        int eq2 = rand.Next(0, listadoEquipos.Count());
        while (eq2 == eq1)
        {
            eq2 = rand.Next(0, listadoEquipos.Count());
        }
        eq2 = rand.Next(0, (listadoEquipos.Count()));
        Equipos equipo2 = listadoEquipos[eq2];
        listadoEquipos.Remove(equipo2);

        Equipos ganador = JuegaPartida(equipo1, equipo2);
        while (ganador == equipo1 && listadoEquipos.Count() > 0)
        {
            Console.WriteLine("\n\n");
            equipo1.ReestableceGoles();
            eq2 = rand.Next(0, (listadoEquipos.Count()));
            equipo2 = listadoEquipos[eq2];
            listadoEquipos.Remove(equipo2);

            ganador = JuegaPartida(equipo1, equipo2);
            ganador.aumentaNivel();
        }
        if (listadoEquipos.Count() == 0)
        {
            Console.WriteLine("\nGANADOR!");
            Console.WriteLine(equipo1.Mostrar());
        }
        else
        {
            Console.WriteLine("\nPerdiste!!");
        }


    }
}
