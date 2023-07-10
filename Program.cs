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
        var listadoJugadores = new List<Personaje>();
        var listadoCompeticiones = persistencia.GetCompetencias();
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
        Console.WriteLine("\n_______________________________________________________________\n");
        foreach (var equipo in listadoEquipos)
        {
            // Console.WriteLine("\t\t\t\tEQUIPO " + k);
            Console.WriteLine("\t" + k + "-" + equipo.Nombre());
            // Console.WriteLine("\n");
            k++;
        }
        Console.WriteLine("\n_______________________________________________________________\n");
        Console.WriteLine("\n\n\n///////////////////////////\tCOMIENZA EL JUEGO\t///////////////////////////\n");
        Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣶⣾⣿⣿⣾⣿⣭⣵⣖⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣢⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣵⣿⣿⠏⠁⢀⠀⠌⠁⠄⡉⠈⠉⠁⠉⠤⠱⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣌⣾⣿⣿⣧⠂⡌⠢⠑⡈⠄⠢⠐⠄⢂⠁⢃⠦⠹⣶⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⡱⣈⠅⡃⠔⠀⠄⠁⠀⠂⠄⠀⠄⣳⢎⢇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣽⣿⣿⡿⢋⠠⢁⠎⠴⢞⣷⣦⣤⣦⣧⣜⣦⣿⣶⣾⣾⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⡧⢀⠂⠌⣐⣿⢟⣋⣿⣿⠿⠏⠀⢺⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣞⠛⢿⡗⢢⡀⠀⠉⠁⢂⣈⣻⡽⠃⠔⠂⠈⣿⠩⣍⠒⣽⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⢃⣹⡌⢿⡀⠂⠁⠀⢀⠠⢉⠁⡀⢤⡌⡐⠀⡘⣷⢎⣽⡎⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡚⣏⡁⢀⣷⠀⡀⠌⢠⡚⡤⠃⠔⡏⠸⠿⢿⣿⣿⣯⢷⣧⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢇⠘⠸⢻⣿⡄⣃⠄⡇⢧⠀⢃⠸⠀⣤⢿⣿⢿⣿⡿⣿⡼⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠹⣿⡗⣯⡐⢯⡜⡡⠌⠀⢰⣾⣻⣾⣿⣿⣿⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣟⠰⢹⣞⡵⣊⠅⠂⠀⠈⢱⣿⣿⣿⡿⢿⣹⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⠣⣜⢻⣷⣉⠆⡠⠀⡀⢳⣙⡿⠿⣡⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣧⢉⣮⠹⢿⣮⣱⡰⣩⣿⣿⣯⣷⣿⣿⢣⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣯⢁⢎⡡⢠⡙⣷⣿⣷⣿⣽⣿⣿⣿⣿⣏⢻⣟⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣼⢳⡌⠒⣧⢣⡝⢤⣿⣿⣿⣿⣿⣿⡿⣟⣾⣿⣿⣿⣳⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣴⣶⣿⡿⣽⢸⡇⡘⣷⠂⡜⣺⣿⢟⣿⣿⣿⣿⣝⣻⣿⣿⣿⣿⣿⡿⡷⣦⡤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣟⣿⣿⣿⣟⡷⣿⢿⣨⢻⡠⣿⡇⢸⣿⡏⠰⣨⢿⣿⣿⣾⣿⣿⣿⣿⣿⣻⢷⣻⡗⣿⣳⢗⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣤⣾⣿⣿⣿⣿⣳⢯⣿⣻⣿⣥⠈⡧⣹⣏⠳⡍⢀⢲⣽⢿⣞⡿⣿⢿⡿⣿⣝⣳⣟⣯⣷⢻⣷⣹⣞⣯⣧⣶⣶⣦⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣞⣯⢿⣽⣾⣿⣿⣟⣾⣽⣟⣷⣻⣽⢿⣦⣿⣸⣿⣵⣰⣾⣟⣯⢿⡾⣝⣳⢯⢷⣏⢿⡼⢧⣟⢾⣻⢞⣽⣻⡾⢯⣷⣛⢿⣿⣿⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣯⢟⣶⡻⣞⣿⣿⣿⣿⡿⣾⡽⣾⡽⣾⡽⣯⡿⣯⣿⣽⣻⡾⣟⣯⡽⣞⣳⢯⢯⡽⣞⣻⢾⣏⣿⢯⣞⣯⣳⢟⣮⢿⣽⣻⢞⡽⣮⡹⢿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣟⣾⣻⢾⡽⣿⣿⡿⣿⣽⣿⣳⣟⣷⣻⢷⣻⢷⣻⣷⣟⡾⣯⢟⡾⣖⡿⣭⡟⣾⣫⢷⢯⣽⣻⢮⡽⣞⡮⢷⡭⣟⣾⣻⠶⣏⡿⣽⠶⣏⡷⣹⢟⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⢷⣯⣷⣯⢿⣽⣿⣿⣿⣿⣟⣷⣻⣞⡷⣯⢿⡽⣯⢷⣻⢾⣽⡳⣯⢟⡾⣵⣛⣾⢳⣽⣫⢟⡷⣿⣚⣿⣳⣽⣫⢾⣽⣟⣧⢿⣽⣹⢯⡿⣽⢞⣵⣫⢞⣣⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣯⢿⣟⣯⣟⡿⣾⣿⣯⣿⢾⣽⣞⡷⣯⢿⡽⣯⢿⡽⣯⣟⣯⢾⣝⣳⢯⣟⠾⣝⣞⡯⣶⣯⡿⣽⣻⣽⣾⣽⢞⣳⢯⣾⣟⡾⣏⡾⣭⢷⣻⠽⣞⢧⢯⢿⡼⣹⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣽⣯⣿⣿⣞⣿⣿⢿⣽⣾⠛⠇⢸⡿⣽⢯⡿⣽⢯⣟⣷⣻⢯⡾⣭⣟⣳⢾⣻⢷⢛⣵⠷⠷⣭⣛⣯⡷⣯⣻⢞⡽⣚⣯⢿⡽⣯⡽⣏⣯⢷⣻⢯⣯⣟⣮⢳⢷⡺⣵⢦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⡾⣷⣿⣿⣿⣾⣿⢿⢟⢶⣳⣾⣒⣿⢯⡿⣽⢯⣟⣾⣳⡯⣷⢫⡷⣾⢽⣻⣅⣹⡟⢸⣶⠔⣿⣤⣷⣟⡷⢯⣯⣽⢫⣿⡯⣟⣵⡻⣝⣾⢣⣿⣟⣮⣽⣾⣿⣾⣿⣿⠟⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣽⣻⣟⣯⢿⣻⣟⣯⢿⡽⣯⣟⣾⣳⡯⣟⡵⣯⣟⣞⣯⢷⣏⢛⣧⡜⣫⢜⣿⣢⣞⡾⣽⡻⣞⡼⣯⢷⡻⣝⣮⡽⡿⣭⣿⣷⣿⣿⣿⣿⣿⣿⡟⠀⢸⣯⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⢿⣿⣯⣿⣿⣿⣿⡷⣟⡾⣽⢯⣷⣻⣞⣯⣟⣷⣻⣞⡷⣿⡽⣹⢶⣻⢮⡽⣾⢽⣻⢯⣿⡾⣾⣻⡽⢾⣹⣳⡽⣭⠿⣽⣯⢻⡵⢾⣹⣟⣿⣿⣿⣿⣿⣟⣷⣿⣿⡄⡄⢸⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣯⣿⡽⣟⣷⣿⢿⣿⣿⣯⢿⣽⣻⣞⣷⣻⢾⡽⣞⡷⣯⣟⡷⣽⢫⣯⠷⣯⢟⣾⣫⣽⣛⣮⣽⢳⢧⡟⣯⣳⡽⣳⢯⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣿⣿⣿⣿⣷⡙⡄⠙⢹⠿⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣞⡿⣟⣿⡽⣿⣯⣷⣿⣟⣾⣳⣟⣾⣽⣿⡠⠤⠤⠭⠭⠭⢉⣿⣼⡻⣭⣟⡶⣛⣶⢻⡼⣞⡯⣟⣾⣳⢯⣿⡽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣾⣛⣿⣣⣏⢿⣺⣦⣵⣒⣒⣬⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣳⣟⣿⣷⣿⣿⣿⣿⢿⣽⣯⢉⡉⠉⠹⣧⠀⠀⠀⠀⢀⣜⣉⣋⡓⡛⠛⠓⢛⣹⣞⣷⣻⣷⣿⣽⣻⣾⣯⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢯⣻⣽⡿⣟⢿⡻⣜⢯⣻⡽⣿⢿⡿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢟⣿⡿⣽⣿⣿⣿⣿⣿⣿⣿⣿⠇⢰⠃⠀⠀⠀⠀⠀⠀⠤⠀⠈⠁⠀⠀⠀⢀⡜⠉⣹⣟⡾⣗⡿⣻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡽⢯⡷⣯⣿⢾⡷⣽⣞⣭⡷⣿⣹⣞⡷⢯⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠎⣷⠃⣹⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣘⣙⣉⣉⣹⠇⠀⠀⠀⠀⣸⣓⣚⣒⡒⠋⠀⣰⠿⣼⠿⣽⣳⢯⡿⣽⡻⣟⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣽⣷⣿⣾⢿⣷⢯⡿⣽⡷⠿⠚⢩⠻⢏⢆⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡎⣾⠿⣱⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣯⣟⡿⣿⣈⣉⣉⣙⣉⣙⣙⡿⣽⣳⣟⡻⢿⣹⡟⣧⢿⣻⡽⣯⣷⣯⣿⣿⣿⣿⣿⣿⢧⣿⠹⣿⠉⣿⣿⣿⣿⣿⣿⣻⣾⣟⣯⣟⡿⢋⡁⠰⣀⠃⢆⡙⢦⢉⢦⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣰⣿⢃⣾⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣾⣽⣿⡽⣯⣿⣽⣯⣟⣾⣱⣟⣳⡽⣾⣽⣏⡷⣽⢫⣟⣶⣿⣿⣿⣿⣿⣿⣿⡿⣿⡏⢸⣧⠘⣿⠀⣿⣿⣿⣿⣿⠛⠛⠿⠟⠻⣧⢒⠥⣊⠵⣌⠳⢄⠐⢂⠳⡌⢧⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠛⢧⣿⣽⡭⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⢸⣿⡇⢻⢹⣷⠸⢣⠃⡓⢦⢡⣷⢸⢸⣿⢰⣲⡆⢱⣿⣻⢾⡽⣷⣿⣿⣿⣿⡿⣯⣿⣿⡇⢸⡏⢸⡯⢠⣿⣿⢷⣯⠇⠀⠀⠀⠀⠀⠈⢻⡶⣡⠚⡌⠡⠌⡘⣦⠐⠤⣀⠑⢤⡀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡠⢊⡴⢡⢊⠻⣿⣼⣿⣿⣿⣿⣿⣿⣿⡟⠁⠀⠈⣿⣶⣾⣷⢿⣿⢿⣿⣿⣶⣳⢶⣞⡶⣞⡶⣶⢷⣻⢮⡷⣯⣿⣿⣿⣿⣟⣷⣻⣿⣿⢿⡇⢸⡇⢸⠇⢸⣿⢯⣟⡾⠀⠀⠀⠀⠀⠀⠀⠀⠙⣷⡷⣈⠒⠈⡔⣹⢌⠲⣁⠦⠀⠙⢄⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠔⡩⣔⡯⣿⣸⠃⠱⣈⢛⣿⣻⣿⣿⣿⣿⡿⠁⠀⠀⠀⢹⣿⣳⣯⣿⢾⡿⣿⣿⣷⢯⣟⡾⣽⣏⡿⣽⣻⢯⡿⣽⣿⣿⣿⣿⣳⠿⣼⣿⣿⣿⣿⠀⣿⠀⣾⠀⢸⣟⡿⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣧⡆⠨⠄⡸⣌⠲⡡⢎⡑⢢⡈⠣⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠔⡪⢔⠮⣵⢫⠾⢃⠋⢀⡡⢖⣿⣾⣿⣿⣯⣿⡿⠁⠀⠀⠀⠀⠈⣿⣷⣿⣾⣿⢿⣿⣽⣿⣻⢾⣽⣳⢾⡽⣯⣟⣽⣿⣿⡿⣟⡿⣜⣳⣿⣿⣿⣿⣾⡇⠀⣿⠀⣿⠀⢸⣯⢿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⡅⢢⠱⣎⠱⡡⣆⠸⡡⢄⠀⢣
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠔⡚⢤⢛⡴⢫⠞⠲⢉⠰⢀⢢⠱⣬⣟⢫⡾⣽⣿⣾⡿⠁⠀⠀⠀⠀⠀⠐⣿⣿⣷⣿⣿⣿⣿⡿⣾⣽⣻⢾⡽⣯⣟⡷⡽⣾⣳⣯⣽⣳⣿⣽⣿⣿⣿⣯⢿⡽⡇⠀⣿⠀⣿⠀⢸⣯⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢧⡓⠉⠉⠷⣱⣘⢆⠡⠂⡉⢼
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠔⡊⠔⡬⣘⠦⡍⠆⠓⡌⡱⢈⡔⣡⢞⣹⢳⣞⣿⣿⣿⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⣿⣿⣯⣿⣿⣯⣿⣿⣯⢷⣯⢿⣽⣳⢯⣻⠵⣯⣷⣟⣾⣽⣷⣿⣿⣿⣿⣿⣿⣿⡇⠀⣿⠀⣹⠀⣸⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡴⠉⠀⡄⠉⠠⢀⠉⢀⠀⠑⢢⣹
⠀⠀⣀⣀⢀⡀⣀⠖⠉⣈⢧⠀⠀⠀⠀⠀⠀⣀⢤⣒⢮⡙⡔⣪⠜⣊⠒⡡⢊⡔⡩⢖⡸⣡⢧⡺⣜⣮⣿⣿⣾⣿⡿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣟⣿⣿⣿⣿⣯⣿⣟⣾⣻⢾⣽⢻⣼⢻⣯⢷⣿⣿⡿⣿⣿⣿⣟⣷⡻⣞⣷⡇⠀⡿⢁⣿⢀⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣦⡁⠸⣴⣜⣴⡭⣶⡏⠾⡼⢶⠉
⡴⠉⡄⠀⢀⡰⢥⣠⣽⣿⣯⣷⢄⡠⠴⣒⣽⣼⣾⢿⣆⠳⡘⢡⣘⡤⣋⠴⣣⢼⡱⢯⣜⣧⣿⣽⣿⣿⣿⡿⠟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣯⣟⡾⣽⢯⡞⣧⣟⡿⣾⣿⣿⣟⣿⣿⣿⣟⡾⣧⣿⣟⣷⡳⣠⠁⣸⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢱⠀⣼⢁⡀⢠⢐⡀⣈⠐⡀⠠⢠
⢸⡷⣆⣡⣾⣇⠟⢚⣿⣿⣿⣿⣿⣾⣿⢿⣙⣫⣵⣮⢿⣷⣛⣯⣵⣶⣽⣿⣽⣿⣿⣿⣿⣿⣿⣿⠿⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣟⣿⣿⣿⣻⡝⣮⣽⣳⢯⣿⣿⣿⣟⣾⣿⣿⡟⣾⣻⣏⡷⡾⠋⣰⡇⢀⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⢉⡟⠾⠷⢾⢿⡻⢿⡽⢿⡏
⠏⠐⡠⢉⠉⣹⣤⣼⣿⣿⣿⣿⣿⣿⣷⣻⣿⣯⣷⣾⣿⣿⣿⣿⣿⣿⡿⠿⠿⠿⠛⠛⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣾⣿⣿⣏⡷⣽⣷⣯⣿⣿⣿⣿⣳⣿⣿⣿⣳⣿⣿⡿⣯⢿⠁⢰⣟⣠⣾⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢧⣮⡝⢯⢶⣧⢇⣶⣻⠇
⠛⡿⢳⡷⠾⠟⠛⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠟⠛⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⢷⣿⣿⢟⣽⣿⣿⣟⣾⣿⣿⣟⣾⣿⢿⣽⣾⣿⣿⢯⡿⣽⠏⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣇⡤⣩⣍⣫⣌⣴⣿⠏⠀
⠀⠳⡶⣬⣓⣤⠿⠟⣋⣿⡿⣟⣫⣿⠿⠛⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⡿⣯⢿⣽⣾⣿⣿⡟⣧⣿⣿⣿⢯⣟⣿⣽⣾⣿⣿⣻⣞⣯⢿⡝⢀⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⠾⠷⠾⠟⠉⠀⠀
⠀⠀⢹⣀⠆⡴⣤⣾⣿⣿⡿⠟⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⡿⣽⣿⣿⣿⣿⡟⣧⢿⣿⣿⣟⣧⣿⣿⣿⡿⣿⡽⣞⣷⣻⣞⡟⣠⣿⣟⣾⡿⣯⢿⣿⣿⢿⣿⣿⣿⣿⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠉⠛⠛⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⣿⣿⣾⢿⣽⣿⣿⣛⣾⣿⣿⢿⣯⣟⣷⣻⡽⣾⢳⡟⢹⡏⢻⡇⠸⣽⣻⣿⢿⣽⣯⣿⣿⣿⢯⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢾⣿⣿⣿⣯⣿⣟⣯⣿⣿⣿⣾⣿⣿⣻⣽⣻⢾⡽⣞⡷⣻⢭⣏⢿⠀⢧⠈⢷⡀⠻⣟⡿⣯⣿⣿⢿⣻⣽⣿⣻⡦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⡟⣿⣷⣿⣿⣿⣿⣿⢻⣷⣯⡟⣾⣽⣯⠛⣷⣽⢹⣮⡟⣾⢣⠘⣷⡄⢹⣦⠈⣿⣽⣿⣾⣿⣿⣷⣿⣷⣿⣵⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⣿⣽⣿⡿⣿⣿⣿⢿⣻⣾⣿⣻⡽⣛⡷⣻⡼⣻⢵⣫⡟⣼⣿⢯⡿⡄⢸⣧⠀⣿⠀⢽⣻⣽⣯⢿⣽⡻⣟⣿⣻⣷⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⢿⣿⣿⡿⣟⢾⣱⣻⢭⢷⡻⣼⢏⣷⣻⣼⢿⣯⣿⣿⡇⣹⣿⢸⣿⠀⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣿⣿⡿⣿⣿⣟⣿⡿⣏⣷⢫⣯⢳⣭⡟⣾⣝⣷⢿⣻⣽⣾⣿⣿⣿⣿⡗⢻⣯⠀⣿⠀⢹⣟⣿⣻⢯⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣽⣿⣿⡿⣽⣟⣳⡽⣞⣻⣼⣛⣶⣻⢳⣯⣞⣯⣿⣿⣿⡟⣛⡿⣽⢇⠀⣿⠀⢹⡇⠈⣟⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣻⣿⣻⣯⣿⣽⣫⢾⣵⡻⣧⢯⣟⣶⣿⣻⢷⣯⣿⢿⣻⢽⡻⣝⣻⢮⣿⠀⠹⡇⠸⣷⠀⢿⣳⣯⢿⣽⣿⣿⣿⣿⣿⢿⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣾⣷⣯⣷⣾⡽⣿⣞⣿⡻⣟⣯⣷⣾⢿⡟⣿⣻⢯⡷⣯⠿⠙⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⢉⡠⣾⣿⣷⡟⠁⡏⠀⠀⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣯⢿⣟⣮⢷⣻⣶⣻⣶⣻⣽⣞⣳⣯⠿⠙⢗⠛⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢤⣾⣭⢿⡟⣹⣿⡷⠀⡅⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡟⠋⠉⠉⠋⠉⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠚⠉⠀⠀⢻⡇⢹⣟⡿⠱⠁⢠⠐⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⡇⣿⣿⢃⠇⢠⠂⢨⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣰⣿⣿⢿⡿⠄⢠⠃⠠⡾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Random rand = new Random();
        int eq1;
        Console.WriteLine("\nElije un equipo del 1 al 10\n");
        string? equipoEl = Console.ReadLine();
        if (int.TryParse(equipoEl, out eq1))
        {
            if (eq1 > 10 || eq1 < 0)
            {
                eq1 = rand.Next(1, 11);
            }

        }
        else
        {
            eq1 = rand.Next(1, 11);
        }
        Equipos equipo1 = listadoEquipos[eq1 - 1];
        Console.WriteLine("EQUIPO ELEGIDO: " + equipo1.Nombre());
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
            Console.WriteLine(@"
  _____ _____ _____ _    _ _____ ______ _   _ _______ ______   _____        _____ _______ _____ _____   ____  
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____| |  __ \ /\   |  __ \__   __|_   _|  __ \ / __ \ 
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__    | |__) /  \  | |__) | | |    | | | |  | | |  | |
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|   |  ___/ /\ \ |  _  /  | |    | | | |  | | |  | |
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |  / ____ \| | \ \  | |   _| |_| |__| | |__| |
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______| |_| /_/    \_\_|  \_\ |_|  |_____|_____/ \____/ 
                                                                                                               
                                                                                                               ");
            Console.WriteLine(@"
                                                                                        ,/)
                                                                                        |_|
        _        _        _        _        _        _        _        _        _       ].[       ,~,
       |.|      |.|      |.|      |.|      |.|      |.|      |.|      |.|      |.|    /~`-'~\     |_|
       ]^[      ]^[      ]^[      ]^[      ]^[      ]^[      ]^[      ]^[      ]^[   (<|   |>)    ]0[
     /~/^\~\  /~`-'~\  /~`-'~\  /~`-'~\  /~`-'~\  /~`-'~\  /~`-'~\  /~`-'~\  /~`-'~\  \|___|/   ,-`^'~\
    {<| $ |>}{<| 8 |>}{<| 6 |>}{<| , |>}{<| 3 |>}{<| 7 |>}{<| 9 |>}{<| , |>}{<| 2 |>} {/   \}  {<|   |>}
     \|___|/  \|___|/  \|___|/  \|___|/  \|___|/  \|___|/  \|___|/  \|___|/  \|___|/  /__1__\   \|,__|/
    /\    \    /   \    /   \    /   \    /   \    /   \    /   \    /   \    /   \   | / \ |   {/ \  /
    |/>/|__\  /__|__\  /__|__\  /__|__\  /__|__\  /__|__\  /__|__\  /__|__\  /__|__\  |/   \|   /__|\/\
    |)   \ |  | / \ |  | / \ |  | / \ |  | / \ |  | / \ |  | / \ |  | / \ |  | / \ |  {}   {}   | / \ |
   (_|    \)  (/   \)  (/   \)  (/   \)  (/   \)  (/   \)  (/   \)  (/   \)  (/   \)  |)   (|   (/   \)
   / \    (|  |)   (|  |)   (|  |)   (|  |)   (|  |)   (|  |)   (|  |)   (|  |)   (|  ||   ||  _|)   (|_
.,.\_/,..,|,)(.|,.,|,)(,|,.,|.)(.|,.,|,)(,|,.,|.)(.|,.,|,)(,|,.,|.)(.|,.,|,)(,|,.,|.)(.|.,.|,)(.,|.,.|,.),.,.");
            equipo1.ReestableceGoles();
            eq2 = rand.Next(0, (listadoEquipos.Count()));
            equipo2 = listadoEquipos[eq2];
            listadoEquipos.Remove(equipo2);

            ganador = JuegaPartida(equipo1, equipo2);
            ganador.aumentaNivel();
        }
        if (listadoEquipos.Count() == 0)
        {
            Console.WriteLine(@"
   _____          __  __ _____  ______ ____  _   _ _ _ 
  / ____|   /\   |  \/  |  __ \|  ____/ __ \| \ | | | |
 | |       /  \  | \  / | |__) | |__ | |  | |  \| | | |
 | |      / /\ \ | |\/| |  ___/|  __|| |  | | . ` | | |
 | |____ / ____ \| |  | | |    | |___| |__| | |\  |_|_|
  \_____/_/    \_\_|  |_|_|    |______\____/|_| \_(_|_)
                                                       
                                                       ");
            Console.WriteLine(@"
        ____
       ( () )
        \  /
         ||
         ||
        [__]
       /)  (\
      (( () ))
       \\__//
        `..'
         ||
         ||    
        //\\__
     _ ((  `--'
    (_) \)
");
            Console.WriteLine("\nGANADOR: ");
            Console.WriteLine(equipo1.Mostrar());
        }
        else
        {
            Console.WriteLine(@"
  _____  ______ _____  _____ _____  _____ _______ ______ _ _ 
 |  __ \|  ____|  __ \|  __ \_   _|/ ____|__   __|  ____| | |
 | |__) | |__  | |__) | |  | || | | (___    | |  | |__  | | |
 |  ___/|  __| |  _  /| |  | || |  \___ \   | |  |  __| | | |
 | |    | |____| | \ \| |__| || |_ ____) |  | |  | |____|_|_|
 |_|    |______|_|  \_\_____/_____|_____/   |_|  |______(_|_)
                                                             
                                                            ");
            Console.WriteLine(@"
         _
        |.|
        ]^[
      ,-|||~\
     {<|||||>}
      \|||||/
      {/   \}
      /__9__\
      | / \ |
      (<   >)
     _|)   (|_
,.,.(  |.,.|  ).,.,.");
        }


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
                jugadaSTR = "Penal\n";
                jugadaSTR += @"      ,
     -   \O                                     ,  .-.___
   -     /\                                   O/  /xx\XXX\
  -   __/\ `                                  /\  |xx|XXX|
     `    \, ()                              ` << |xx|XXX|
 jgs^^^^^^^^`^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^";
                break;
            case Jugada.frenteAFrente:
                jugadaSTR = "Frente a frente\n";
                jugadaSTR += @"
                     ___
 o__        o__     |   |\
/|          /\      |   |X\
/ > o        <\     |   |XX\";
                break;
            case Jugada.saqueDelArco:
                jugadaSTR = "Saque del arco";
                jugadaSTR += @"  -                              ___
         |.|                          . /\_/\
       __]-[_________ /             .  (-<_>-)
      /        _____|<_          .   .  \/_\/
     / _   &  /               .   .
    / / \_ __|            .
  _/_/  / X   \
 <_/   /   ____\
      /___/|  /             
      |  / ( <                
      ( <   \ |
       \ |   >\
       _>|  (_/
      (__|";
                break;
            case Jugada.saqueDelMedio:
                jugadaSTR = "Saque del medio\n";
                jugadaSTR += @"
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⣿⣿⣿⣿⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣾⣿⡿⠿⢿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⠁⠀⠚⠛⠉⢻⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢛⣿⠀⠀⠀⠀⢀⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⠴⠶⢶⣏⠙⣇⠀⠀⢀⣾⡟⢳⣦⣤⣀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠴⠞⠋⠀⠀⠀⠀⠉⠙⠝⠷⠶⠛⣉⡴⠾⠇⠀⠈⢣⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⠾⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠴⠚⠁⠀⠀⢠⡄⢠⣤⣝⣦⣀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡏⠀⠀⠀⣀⣀⣀⣤⣶⣶⡶⠤⠤⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⣸⣿⣿⣯⢻⣦⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⠏⠀⣠⣴⠿⠋⠉⠉⣽⣏⠙⠛⠲⠤⠄⡀⠀⠀⠀⠀⠀⠘⣦⣿⣿⣿⣿⣿⠀⠙⢷⡀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡾⠁⢀⡼⠋⠁⠀⠀⠀⠀⣿⣿⡿⢦⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡿⠉⠉⠻⣇⠀⠀⢰⡇
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⠁⠀⢸⠃⠀⠀⠀⠀⠀⠀⣿⡇⠙⠒⠬⠉⠑⠂⠀⠀⠀⠀⠀⠀⣿⠃⠀⠀⠀⠙⠷⣦⡾⠃
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⣿⠄⠀⠀⠀⠀⠀⠀⠙⢿⣤⡤⠀⠀⣄⠀⠀⠀⠀⠀⠀⢰⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠿⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⣸⡿⠂⢠⣤⣼⣷⣄⠀⠀⠀⠀⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠟⠀⠀⠀⠀⠀⠈⠻⣿⣦⣤⣾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⣠⠄⠀⠀⢈⣿⡏⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣆⠀⢀⣾⠁⠀⢠⡾⠛⠉⢿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡴⠛⠛⢷⣾⡇⠀⢠⡟⠀⠀⠀⠈⢻⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⠁⠀⠀⠀⢹⣿⣷⣾⡶⠀⠀⠀⢀⣼⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡴⠛⠛⠻⣦⠀⠀⣻⣿⠋⠁⠀⠰⣦⣴⠟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣰⠟⠀⠀⠀⣀⣹⣷⣾⣿⠇⠀⠀⢀⣴⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⡶⣶⠛⠋⠉⠀⠀⣴⡞⠙⠛⠋⠙⣿⡄⢀⣴⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⠟⠁⠀⢀⡄⠀⣀⣤⣼⣿⠇⢠⣾⣦⠀⢿⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢀⣤⣤⣤⣤⣴⠟⠁⠀⠀⠀⣸⣿⠟⠉⠀⠸⣇⣄⡀⠛⠋⢀⣀⣼⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⢠⡟⠀⣈⠉⠀⣀⣀⡤⠶⠞⠛⠋⠉⠀⠀⠀⢤⡿⠿⣿⣦⣰⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⣠⡾⠃⠀⣹⣷⠟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢦⣄⡈⢿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣾⠋⠀⢀⡼⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢷⣴⠾⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";
                break;
            case Jugada.tiroLibre:
                jugadaSTR = "Tiro Libre";
                jugadaSTR += @"
           _
         /_`\
         /-\ )
       __7_/_(_______ _
      /        _____|<_\
     /        /
    / /|__ __/    
  _/_/ /     |      
 <_/  /_     |
     /  \-___|
    ( )'  |  /      ___
     \ |  ( )      /\_/\
      >\  | /     (-<_>-)
     (_/  |/       \/_\/    
         (_)";

                break;
            case Jugada.corner:
                jugadaSTR = "Corner\n";
                jugadaSTR += @"
                              +---------------------------+    
                              |\                          |\   
                              | \    @ \_    /            | \
                              |  \  /  \_o--<_/           | o\
______________________________|___|/______________________|-|\|__________________
         /                   /    /              _ o     / /|_                /
        /                   /  _o'------------- / / \ ----/                  /
       /                   /  /|_                /\    /                    /
      /                   /_ /\ _______________ / / __/                    /
     /                      / /                                           /
    /                                                                    /
   /                                                                    /
  /                                                                    /
 /____________________________________________________________________/";
                break;
            default:
                jugadaSTR = "Otro\n";
                jugadaSTR += @"
                ⠀⠀⠀⣀⣤⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⢠⣾⢽⣍⣹⠾⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⢸⣷⢼⡁⢘⠗⢳⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠈⠻⣦⣯⣹⣶⠿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢀⣰⠀⠀⠀⣼⣥⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢸⡏⠀⠀⠀⠻⣿⣿⣿⣿⠛⠳⢤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠈⣧⠀⠀⠀⠀⠈⠁⠉⢿⣷⣤⣄⠀⠉⠑⢲⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠘⣆⠀⠀⠀⠀⠀⠀⠀⠉⠀⠈⠙⢦⣠⣾⠏⠈⠙⠲⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠘⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠳⢤⣀⠀⠀⠀⠑⢦⣀⣀⡤⢤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣶⣦⣀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠈⠳⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣄⠀⢀⣼⣿⣿⣦⣤⠬⣍⡑⠒⠒⡎⠉⠉⠉⠙⠒⢤⡴⠋⠀⠈⣻⣿⣿⡆⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠈⠳⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣷⣿⣿⣿⣿⣿⣿⣧⣄⠉⠳⢴⣇⡀⠀⠀⠀⢠⢞⠀⠀⠀⠐⣿⣿⡟⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⠓⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣿⣿⣿⣿⣿⣿⡷⠖⠚⠉⠀⠀⠀⠀⠘⠮⢕⣒⣂⣼⠛⠁⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠓⢦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⡇⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠲⢤⣀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠹⣆⠀⠀⠀⠀⢿⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⣀⡼⠋⠙⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠉⠁⠀⠀⠀⠈⣧⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠔⠋⠹⣷⠀⠀⣹⣿⣿⣿⣿⠧⠴⠒⠒⠒⠒⠒⠒⠒⠦⣄⡀⠀⠀⠀⢽⣄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣔⣞⠉⣀⣀⣀⡤⠛⠉⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠣⡀⠀⠈⢿⣆⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣶⣿⣿⡿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢲⡋⠉⢧⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⡀⠘⡆⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠳⡀⢹⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢱⠘⡆⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢦⣜⡦⣄⡀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠃";
                break;
        }
        return (jugadaSTR);
    }


    public static void JuegaJugadaDelanteroVsDefensa(Equipos equipo1, Equipos equipo2, Competition competicion)
    {
        Console.WriteLine("\n- Presiona una tecla para jugar la jugada: ");
        string? tecla = Console.ReadLine();
        Random rand = new Random();
        Jugada jugada = (Jugada)rand.Next(0, 8);
        double efectividad1 = Efectividad(jugada);
        double efectividad2 = 100 - efectividad1;
        efectividad1 = equipo1.MejoraLiga(competicion, efectividad1);
        efectividad2 = equipo2.MejoraLiga(competicion, efectividad2);
        Console.WriteLine("\nEfectividad ataque: " + efectividad1);
        Console.WriteLine("\t\tJugada: " + JugadaAleatoria(jugada));
        double ataque = equipo1.Delantero.Ataque(efectividad1);
        Console.WriteLine("\nATACA: " + equipo1.Delantero.Nombre() + " puntos de ataque para esta jugada:  " + ataque);
        double defensa = equipo2.DefensaOArquero.Defensa(efectividad2);
        Console.WriteLine("DEFIENDE: " + equipo2.DefensaOArquero.Nombre() + " puntos de defensa para esta jugada:  " + defensa);
        Console.WriteLine("\n- Presiona una tecla para avanzar: ");
        tecla = Console.ReadLine();
        if (ataque > defensa)
        {
            Console.WriteLine(@"
   _____  ____  _      _ _ 
  / ____|/ __ \| |    | | |
 | |  __| |  | | |    | | |
 | | |_ | |  | | |    | | |
 | |__| | |__| | |____|_|_|
  \_____|\____/|______(_|_)
                           
                           ");
            Console.WriteLine("GOL DEL DELANTERO DE " + equipo1.Nombre() + "\n");
            equipo1.Goles += 1;
        }
        else
        {
            if (ataque < defensa)
            {
                Console.WriteLine(@"
  _____  ______ ______ ______ _   _  _____         _ _ 
 |  __ \|  ____|  ____|  ____| \ | |/ ____|  /\   | | |
 | |  | | |__  | |__  | |__  |  \| | (___   /  \  | | |
 | |  | |  __| |  __| |  __| | . ` |\___ \ / /\ \ | | |
 | |__| | |____| |    | |____| |\  |____) / ____ \|_|_|
 |_____/|______|_|    |______|_| \_|_____/_/    \_(_|_)
                                                       
                                                       ");
                Console.WriteLine("No fue gol, gana el defensa");
            }
            else
            {
                ataque = equipo2.DefensaOArquero.Ataque((efectividad2));
                defensa = equipo1.Delantero.Defensa(efectividad1);
                if (ataque < defensa)
                {
                    Console.WriteLine(@"
   _____  ____  _      _ _ 
  / ____|/ __ \| |    | | |
 | |  __| |  | | |    | | |
 | | |_ | |  | | |    | | |
 | |__| | |__| | |____|_|_|
  \_____|\____/|______(_|_)
                           
                           ");
                    Console.WriteLine("GOL DEL DEFENSOR (contrataque)" + equipo2.Nombre() + "\n");
                    equipo2.Goles += 1;
                }
                else
                {
                    Console.WriteLine(@"
  _____  ______ ______ ______ _   _  _____         _ _ 
 |  __ \|  ____|  ____|  ____| \ | |/ ____|  /\   | | |
 | |  | | |__  | |__  | |__  |  \| | (___   /  \  | | |
 | |  | |  __| |  __| |  __| | . ` |\___ \ / /\ \ | | |
 | |__| | |____| |    | |____| |\  |____) / ____ \|_|_|
 |_____/|______|_|    |______|_| \_|_____/_/    \_(_|_)
                                                       
                                                       ");
                    Console.WriteLine("No fue gol, pero el delantero frena el contrataque");
                }
            }
        }
    }
    public static void JuegaJugadaMediocampoVsMediocampo(Equipos equipo1, Equipos equipo2, Competition competicion)
    {
        double efectividad1 = equipo1.MejoraLiga(competicion, 50);
        double efectividad2 = equipo2.MejoraLiga(competicion, 50);
        double ataque1 = equipo1.Mediocampo.Ataque(efectividad1);
        double ataque2 = equipo2.Mediocampo.Ataque(efectividad2);
        if (ataque1 > ataque2)
        {
            Console.WriteLine("\nAtaca el equipo: " + equipo1.Nombre());
            Console.WriteLine("Ataca: " + equipo1.Mediocampo.Nombre());
            Console.WriteLine("Defiende: " + equipo2.Mediocampo.Nombre());
            MediovsMedio(equipo1, equipo2, competicion);

        }
        else
        {
            if (ataque2 > ataque1)
            {
                Console.WriteLine("\nAtaca el equipo:  " + equipo2.NombreEquipo);
                Console.WriteLine("Ataca: " + equipo2.Mediocampo.Nombre());
                Console.WriteLine("Defiende: " + equipo1.Mediocampo.Nombre());
                MediovsMedio(equipo2, equipo1, competicion);
            }
            else
            {
                double defensa1 = equipo1.Mediocampo.Defensa(efectividad1);
                double defensa2 = equipo2.Mediocampo.Defensa(efectividad2);
                if (defensa1 > defensa2)
                {
                    Console.WriteLine("\nAtaca el equipo: " + equipo1.Nombre());
                    Console.WriteLine("Ataca: " + equipo1.Mediocampo.Nombre());
                    Console.WriteLine("Defiende: " + equipo2.Mediocampo.Nombre());
                    MediovsMedio(equipo1, equipo2, competicion);
                }
                else
                {
                    if (defensa2 > defensa1)
                    {
                        Console.WriteLine("\nAtaca el equipo:  " + equipo2.NombreEquipo);
                        Console.WriteLine("Ataca: " + equipo2.Mediocampo.Nombre());
                        Console.WriteLine("Defiende: " + equipo1.Mediocampo.Nombre());
                        MediovsMedio(equipo2, equipo1, competicion);
                    }
                    else
                    {
                        Console.WriteLine("\nNingun jugador pudo generar una ocación, por lo tanto, competirán otros 2 jugadores");
                    }
                }
            }
        }

    }
    public static void MediovsMedio(Equipos equipo1, Equipos equipo2, Competition competicion)
    {
        Console.WriteLine("\n- Presiona una tecla para jugar la jugada: ");
        string? tecla = Console.ReadLine();
        Random rand = new Random();
        Jugada jugada = (Jugada)rand.Next(0, 8);
        double efectividad1 = Efectividad(jugada);
        double efectividad2 = 100 - efectividad1;
        efectividad2 = equipo2.MejoraLiga(competicion, efectividad2);
        efectividad1 = equipo1.MejoraLiga(competicion, efectividad1);
        Console.WriteLine("\nEfectividad ataque: " + efectividad1);
        Console.WriteLine("\n\t\tJugada: " + JugadaAleatoria(jugada));
        double ataque = equipo1.Mediocampo.Ataque(efectividad1);
        Console.WriteLine("Ataca: " + equipo1.Mediocampo.Nombre() + " puntos de ataque para esta jugada:  " + ataque);
        double defensa = equipo2.Mediocampo.Defensa(efectividad2);
        Console.WriteLine("Defiende: " + equipo2.Mediocampo.Nombre() + " puntos de defensa para esta jugada:  " + defensa);
        Console.WriteLine("\n- Presiona una tecla para avanzar: ");
        tecla = Console.ReadLine();
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
                ataque = equipo2.Mediocampo.Ataque((efectividad2));
                defensa = equipo1.Mediocampo.Defensa(efectividad1);
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
        var buscadorLiga = new PersonajesJSON();
        string? avanzar;
        int factor;
        int aumentaONo;
        Random rand = new Random();
        var competicion = new Competencias();
        competicion = buscadorLiga.GetCompetencias();
        int cant = competicion.competitions.Count();
        int indiceLiga = rand.Next(0,cant);
        while (competicion.competitions[indiceLiga] == null)
        {
            indiceLiga = rand.Next(0, competicion.competitions.Count());
        }
        var liga = competicion.competitions[indiceLiga];
        Console.WriteLine("\n" + liga.Mostrar() + "\n");
        Console.WriteLine("\t\t\t---Equipo 1:  " + equipo1.Nombre() + "\n");
        Console.WriteLine(equipo1.Mostrar());
        Console.WriteLine("\n....................................................................................\n");
        Console.WriteLine("\t\t\t---Equipo2:" + equipo2.Nombre() + "\n");
        Console.WriteLine(equipo2.Mostrar());
        Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

        Console.WriteLine("\n\nATACA: " + equipo1.Nombre() + ",\nDEFIENDE: " + equipo2.Nombre());
        JuegaJugadaDelanteroVsDefensa(equipo1, equipo2, liga);
        Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

        Console.WriteLine("\n\nATACA " + equipo2.Nombre() + ", \nDEFIENDE: " + equipo1.Nombre());
        JuegaJugadaDelanteroVsDefensa(equipo2, equipo1, liga);
        Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

        Console.WriteLine("\n\nSe enfrentan mediocampos");
        JuegaJugadaMediocampoVsMediocampo(equipo1, equipo2, liga);
        Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

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
                    Console.WriteLine("RESULTADO PARCIAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + " - " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
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

                    Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

                    JuegaJugadaDelanteroVsDefensa(equipo1, equipo2, liga);
                    Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

                    JuegaJugadaDelanteroVsDefensa(equipo2, equipo1, liga);
                    Console.WriteLine(@"
   _____ _____ _____ _    _ _____ ______ _   _ _______ ______        _ _    _  _____          _____          
  / ____|_   _/ ____| |  | |_   _|  ____| \ | |__   __|  ____|      | | |  | |/ ____|   /\   |  __ \   /\    
 | (___   | || |  __| |  | | | | | |__  |  \| |  | |  | |__         | | |  | | |  __   /  \  | |  | | /  \   
  \___ \  | || | |_ | |  | | | | |  __| | . ` |  | |  |  __|    _   | | |  | | | |_ | / /\ \ | |  | |/ /\ \  
  ____) |_| || |__| | |__| |_| |_| |____| |\  |  | |  | |____  | |__| | |__| | |__| |/ ____ \| |__| / ____ \ 
 |_____/|_____\_____|\____/|_____|______|_| \_|  |_|  |______|  \____/ \____/ \_____/_/    \_\_____/_/    \_\
                                                                                                             
                                                                                                             ");

                    JuegaJugadaMediocampoVsMediocampo(equipo1, equipo2, liga);
                }
                if (equipo1.GolesMarcados() > equipo2.GolesMarcados())
                {
                    Console.WriteLine("\n\t\t--------EQUIPO GANADOR:  " + equipo1.Nombre());
                    Console.WriteLine("RESULTADO FINAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + "- " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
                    return (equipo1);
                }
                else
                {
                    Console.WriteLine(@"
   _____              _   _               _____   _______   ______   _   _ 
  / ____|     /\     | \ | |     /\      / ____| |__   __| |  ____| | | | |
 | |  __     /  \    |  \| |    /  \    | (___      | |    | |__    | | | |
 | | |_ |   / /\ \   | . ` |   / /\ \    \___ \     | |    |  __|   | | | |
 | |__| |  / ____ \  | |\  |  / ____ \   ____) |    | |    | |____  |_| |_|
  \_____| /_/    \_\ |_| \_| /_/    \_\ |_____/     |_|    |______| (_) (_)
                                                                           
                                                                          ");
                    Console.WriteLine("\n\t\t--------EQUIPO GANADOR:  " + equipo2.Nombre());
                    Console.WriteLine("RESULTADO FINAL:  " + equipo1.Nombre() + " " + equipo1.GolesMarcados() + "- " + equipo2.Nombre() + " " + equipo2.GolesMarcados());
                    return (equipo2);

                }
            }

        }

    }


}
