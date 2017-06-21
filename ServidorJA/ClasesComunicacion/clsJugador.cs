using System.Drawing;
using System;
using System.Text;



namespace ClasesComunicacion
{

    public class clsJugador
    {
        String nick;
        int puntaje = 0;
        int sinAcertar;
        bool fueraDeJuego = false;
        Color color;  

        public clsJugador(String nombre)
        {
            this.nick = nombre;
           // this.colorJ = color;

        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Nick
        {
            get
            {
                return nick;
            }
            set
            {
                nick = value;
            }


        }

        public int Puntaje
        {
            get
            {
                return puntaje;
            }

            set
            {
                puntaje = value;
            }
        }

        public int SinAcertar
        {
            get
            {
                return sinAcertar;
            }

            set
            {
                sinAcertar = value;
            }
        }

        public bool FueraDeJuego
        {
            get
            {
                return fueraDeJuego;
            }

            set
            {
                fueraDeJuego = value;
            }
        }
        ////    Jugador PuntajeMasAlto()
        //    {


        //    }
        //void GuardarPuntajesAltos()
        //{
        //    file = new StreamReader(@"c:\diccionario.txt", Encoding.UTF8, true);
        //    string linea = "";

        //    while ((linea = file.ReadLine()) != null)
        //    {
        //        if (linea.Length > 8)
        //        {

        //            diccionario.Add(linea);
        //        }
        //    }


        //}

    }
}
