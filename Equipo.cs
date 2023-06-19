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

        public Personaje Delantero { get => delantero; set => delantero = value; }
        public Personaje Mediocampo { get => mediocampo; set => mediocampo = value; }
        public Personaje DefensaOArquero { get => defensaOArquero; set => defensaOArquero = value; }
        public int Goles { get => goles; set => goles = value; }
        public string NombreEquipo { get => nombreEquipo; set => nombreEquipo = value; }

        public string Mostrar(){
            return("\n=============================Equipo: "+this.NombreEquipo+"=======================\nDELANTERO: \n"+this.delantero.Mostrar()+"\nMEDIOCAMPO: \n"+this.mediocampo.Mostrar()+"\nDEFENSA O ARQUERO: \n"+this.defensaOArquero.Mostrar());
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
    }
}