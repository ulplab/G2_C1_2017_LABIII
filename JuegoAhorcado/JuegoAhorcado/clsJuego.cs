using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace JuegoAhorcado
{
   


    public class clsJuego : ICom
    {
        List<String> diccionario = new List<string>();//contiene el diccionario en memoria
        List<clsJugador> jugadores = new List<clsJugador>();
        string palabra;
        List<int> numerosUsados = new List<int>();// almacena los numeros (palabras) que ya fueron utilizadas
        StreamReader file;
        const int CHANCES = 5;// son las chances que tiene el jugador para adivinar la palabra,en caso de "ARRIESGAR" pierde toda las chances
        String[,] palabraArray;//variable multidimensional palabra que va a contener la palabra y por cada caracter el usuario q adivino el mismo y su numero de usuario
        



        public string Palabra
        {
            get
            {
                return palabra;
            }

            set
            {
                palabra = value;
            }
        }

        public clsJuego()
        {
            

            LeerArchivo();
        


        }

        public void agregarJugador(clsJugador j)
        {
            jugadores.Add(j);
        }

        public void quitarJugador(clsJugador j)
        {
            if(jugadores.Exists(x=>x.Nick==j.Nick))
            {
                jugadores.Remove(j);
            }
            if (jugadores.Count() == 0)
                finJuego(Color.Transparent);
        }

        public event ev_fin finJuego;
        public event ev_recibir recibe;
        void Perdio(string jugador)
        {
            for (int i = 0; i <= (palabraArray.Length/2)-1; i++)
            {
                if (palabraArray[i, 1]!=null && palabraArray[i, 1].Equals(jugador))
                {
                    palabraArray[i, 1] = null;
                }
            }
            jugadores.ElementAt(BuscaIndiceJugador(jugador)).FueraDeJuego = true;
            // jugadores.ElementAt(BuscaIndiceJugador(jugador)).SinAcertar = 5;

        }//quita todo el puntaje de palabrasArray y deja fuera de  juego y sin acertar = 5
        void LeerArchivo()
        {
            file = new StreamReader(@"C:\Proyecto Optativa2\G2_C1_2017_PC\diccionario.txt", Encoding.UTF8, true);
            string linea = "";

            while ((linea = file.ReadLine()) != null)
            {
                if (linea.Length >= 6 && linea.Length<=14)
                {

                    diccionario.Add(linea);
                }
            }


        }
        public int GenerateRandom(int min, int max)
        {
            int seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);
            return new Random(seed).Next(min, max);
        }//numero aleatorio para elegit palabra de diccionario al azar
        public void GeneraPalabra()
        {

           
            int numero = GenerateRandom(0, diccionario.Count - 1);
            if (numerosUsados.IndexOf(numero) >= 0)
            {
                // si el numero ya fue usad
                GeneraPalabra();

            }

            else
            {

                Palabra = diccionario.ElementAt(numero);
                //elimino los acentos de las palabras
                Palabra=Palabra.Replace('á', 'a');
                Palabra = Palabra.Replace('é', 'e');
                Palabra = Palabra.Replace('í', 'i');
                Palabra = Palabra.Replace('ó', 'o');
                Palabra = Palabra.Replace('ú', 'u');
                Palabra = Palabra.ToUpper();
                //creo el arreglo con longitud equivalente a la palabra obtenida
                palabraArray = new String[Palabra.Length, 2];
                int contador = 0;
                foreach (clsJugador j in jugadores)
                {
                    j.SinAcertar = 0;
                    j.FueraDeJuego = false;
                }
                foreach (char i in Palabra)
                {

                    palabraArray[contador, 0] = i.ToString();
                    palabraArray[contador, 1] = null;
                    contador++;

                }

            }

           

        }//genera  una nueva palabra para palabraArray y vuelve las chances perdidas por los jugadores  a cero
        int BuscaIndiceJugador(String nombre)
        {
            int indice = 0;
            int tamañoLista = jugadores.Count;
            while (indice != tamañoLista)
            {
                if (jugadores.ElementAt(indice).Nick.Equals(nombre))
                {
                    break;
                }
                indice++;
            }
            if (indice == tamañoLista)
            {
                return -1;
            }
            else
            {
                return indice;
            }

        }
        public bool enviaLetra(clsJugador jugador, char l)
        {
            //if (palabra.IndexOf(l) != -1)
            //{
            //    recibe(p, l.ToString());
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            int indiceJugador = BuscaIndiceJugador(jugador.Nick);
            bool retorno = false;
            for (int i = 0; i <=( palabraArray.Length/2)-1; i++)
            {
                if (palabraArray[i, 0].Equals(l.ToString()))
                {
                    palabraArray[i, 1] = jugador.Nick;
                    retorno = true;
                }
            }
            if (retorno == false)
            { 
                jugadores.ElementAt(indiceJugador).SinAcertar++;
                if (jugadores.ElementAt(indiceJugador).SinAcertar == CHANCES)
                {

                    Perdio(jugador.Nick);


                }
            }
            else
            {
                recibe(jugador, l.ToString());
            }
            return retorno;
        }

        public bool enviaPalabra(clsJugador p, string s)
        {
            if (palabra.Equals(s))
            {
                p.Puntaje = 5;//cantidad de puntajes por acertar
                finJuego(p.Color);
                return true;
            }
            else
            {
                quitarJugador(p);
                return false;
            }
        }
    }
    public class clsJugador
    {
        String nick;
        int puntaje = 0;
        int sinAcertar;
        bool fueraDeJuego = false;
        Color color;
        public clsJugador(String nombre, Color color)
        {
            this.nick = nombre;
            this.Color = color;

        }

        public string Nick
        {
            get
            {
                return nick;
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

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
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
