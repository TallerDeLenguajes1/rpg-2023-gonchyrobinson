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

        public Personaje Delantero { get => delantero; set => delantero = value; }
        public Personaje Mediocampo { get => mediocampo; set => mediocampo = value; }
        public Personaje DefensaOArquero { get => defensaOArquero; set => defensaOArquero = value; }
        public int Goles { get => goles; set => goles = value; }

        public string Mostrar(){
            return("\n---------------------------DELANTERO----------------------------------\n"+this.delantero.Mostrar()+"\n---------------------------MEDIOCAMPO----------------------------------\n"+this.mediocampo.Mostrar()+"\n---------------------------DEFENSA O ARQUERO----------------------------------\n"+this.defensaOArquero.Mostrar());
        }

    }
}