using System;
using EspacioPersonajes;
namespace EspacioEquipos
{
    class Equipos
    {
        private Personaje delantero;
        private Personaje mediocampo;
        private Personaje defensaOArquero;
        private int goles;
        private string nombreEquipo;
        private string area;

        public Personaje Delantero { get => delantero; set => delantero = value; }
        public Personaje Mediocampo { get => mediocampo; set => mediocampo = value; }
        public Personaje DefensaOArquero { get => defensaOArquero; set => defensaOArquero = value; }
        public int Goles { get => goles; set => goles = value; }
        public string NombreEquipo { get => nombreEquipo; set => nombreEquipo = value; }
        public string Area { get => area; set => area = value; }

        public List<Personaje> GetAllJugadores()
        {
            var Jugadores = new List<Personaje>();
            Jugadores.Add(Delantero);
            Jugadores.Add(Mediocampo);
            Jugadores.Add(DefensaOArquero);
            return Jugadores;
        }

        public string Mostrar(){
            return("\n=============================Equipo: "+this.NombreEquipo+"=======================\nPAIS: "+this.area+"\nDELANTERO: \n"+this.delantero.Mostrar()+"\nMEDIOCAMPO: \n"+this.mediocampo.Mostrar()+"\nDEFENSA O ARQUERO: \n"+this.defensaOArquero.Mostrar());
        }
        public string Nombre(){
            return(nombreEquipo);
        }
        public int GolesMarcados(){
            return(goles);
        }
        public void aumentaNivel(){
            delantero.CaracteristicasPersonaje.Nivel+=1;
            mediocampo.CaracteristicasPersonaje.Nivel+=1;
            defensaOArquero.CaracteristicasPersonaje.Nivel+=1;
        }
        public void AumentaEstadisticas(int factor){
            delantero.AumentaCaracteristicas(factor);
            mediocampo.AumentaCaracteristicas(factor);
            defensaOArquero.AumentaCaracteristicas(factor);
        }
        public void DisminuyeEstadisticas(int factor){
            delantero.DisminuyeCaracteristicas(factor);
            mediocampo.DisminuyeCaracteristicas(factor);
            defensaOArquero.DisminuyeCaracteristicas(factor);
        }
        public void ReestableceGoles(){
            Goles =0;
        }
        public double MejoraLiga(Competition competicion, double efectividad){
            if (competicion.area.name==area)
            {
                efectividad*=1.25;
                if (efectividad>=100)
                {
                    efectividad=99;
                }
            }
            return(efectividad);
        }
    }
}