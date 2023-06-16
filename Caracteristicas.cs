namespace EspacioPersonajes
{
    public class Caracteristicas
    {
        private int marcaje;
        private int control;
        private int tiro;
        private int nivel;
        private int intercepciones;
        private int salud;

        public int Control { get => control; set => control = value; }
        public int Marcaje { get => marcaje; set => marcaje = value; }
        public int Tiro { get => tiro; set => tiro = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Intercepciones { get => intercepciones; set => intercepciones = value; }
    }
}