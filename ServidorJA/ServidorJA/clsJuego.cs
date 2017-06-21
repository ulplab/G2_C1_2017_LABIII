using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using ClasesComunicacion;

namespace ServidorJA
{


    public class clsJuego
    {
        List<String> diccionario = new List<string>();//contiene el diccionario en memoria
        List<clsJugador> jugadores = new List<clsJugador>();
        private List<Color> listaColores = new List<Color>();
        string palabra;
        List<int> numerosUsados = new List<int>();// almacena los numeros (palabras) que ya fueron utilizadas
        StreamReader file;
        const int CHANCES = 5;// son las chances que tiene el jugador para adivinar la palabra,en caso de "ARRIESGAR" pierde toda las chances
        String[,] palabraArray;//variable multidimensional palabra que va a contener la palabra y por cada caracter el usuario q adivino el mismo y su numero de usuario

        #region Set y Get
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

        public List<clsJugador> Jugadores
        {
            get
            {
                return jugadores;
            }

            set
            {
                jugadores = value;
            }
        }
        #endregion
        public clsJuego()
        {
            LeerArchivo();
            //GeneraPalabra();
            agregarColores();
        }

        private void agregarColores()
        {
            listaColores.Add(Color.Blue);
            listaColores.Add(Color.Red);
            listaColores.Add(Color.Green);
            listaColores.Add(Color.Yellow);
            listaColores.Add(Color.Orange);
        }
        public void agregarJugador(clsJugador j)
        {
            j.Color = listaColores[Jugadores.Count];
            Jugadores.Add(j);
        }
        public void quitarJugador(clsJugador j)
        {
            if (Jugadores.Exists(x => x.Nick == j.Nick))
            {
                Jugadores.Remove(j);
            }
            if (Jugadores.Count() == 0)
            {
                //  finJuego(Color.Transparent);
            }
        }
        void Perdio(string jugador)
        {
            for (int i = 0; i <= (palabraArray.Length / 2) - 1; i++)
            {
                if (palabraArray[i, 1] != null && palabraArray[i, 1].Equals(jugador))
                {
                    palabraArray[i, 1] = null;
                }
            }
            Jugadores.ElementAt(BuscaIndiceJugador(jugador)).FueraDeJuego = true;
            // jugadores.ElementAt(BuscaIndiceJugador(jugador)).SinAcertar = 5;

        }//quita todo el puntaje de palabrasArray y deja fuera de  juego y sin acertar = 5
        void LeerArchivo()
        {
            file = new StreamReader(@"c:\diccionario.txt", Encoding.UTF8, true);
            string linea = "";

            while ((linea = file.ReadLine()) != null)
            {
                if (linea.Length >= 6 && linea.Length <= 14)
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
                Palabra = Palabra.Replace('á', 'a');
                Palabra = Palabra.Replace('é', 'e');
                Palabra = Palabra.Replace('í', 'i');
                Palabra = Palabra.Replace('ó', 'o');
                Palabra = Palabra.Replace('ú', 'u');
                Palabra = Palabra.ToUpper();
                //creo el arreglo con longitud equivalente a la palabra obtenida
                palabraArray = new String[Palabra.Length, 2];
                int contador = 0;
                foreach (clsJugador j in Jugadores)
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
       public int BuscaIndiceJugador(String nombre)
        {
            int indice = 0;
            int tamañoLista = Jugadores.Count;
            while (indice != tamañoLista)
            {
                if (Jugadores.ElementAt(indice).Nick.Equals(nombre))
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

       public bool ganador(string nombre)
       {
           //CONTROLAR GANADOR Y GANADOR POR PALABRA COMPLETA
       }
        public clsMensajeJuego enviaLetra(string nick, string l)
        {
            clsMensajeJuego msjRetorno = new clsMensajeJuego();
            List<int> listaPosiciones = new List<int>();
            int indiceJugador = BuscaIndiceJugador(nick);
            msjRetorno.Retorno = "FALLO";
            for (int i = 0; i <= (palabraArray.Length / 2) - 1; i++)
            {
                if (palabraArray[i, 0].Equals(l.ToString()))
                {
                    listaPosiciones.Add(i);
                    msjRetorno.Retorno = "ACERTADO";
                }
            }
            if ( msjRetorno.Retorno .Equals("FALLO"))
            {
                Jugadores.ElementAt(indiceJugador).SinAcertar++;
                if (Jugadores.ElementAt(indiceJugador).SinAcertar == CHANCES)
                {
                    Perdio(nick);
                }
            }
            msjRetorno.LetraPalabra = l;
            msjRetorno.PosicionLetra = listaPosiciones;
            msjRetorno.Accion = "PROBAR_LETRA";//REVISAR PORQUE SE PIERDE LA ACCION AL ENVIAR AL CLIENTE EL MSJ
            return msjRetorno;
        }
        public clsMensajeJuego enviaPalabra(string nick, string s)
        {
            clsMensajeJuego msjRetorno = new clsMensajeJuego();
            if (palabra.Equals(s))
            {
                Jugadores.ElementAt(BuscaIndiceJugador(nick)).Puntaje = 5;
                msjRetorno.Retorno = "ACERTADO";
                //p.Puntaje = 5;//cantidad de puntajes por acertar
                //finJuego(p.Color);
            }
            else
            {
                //quitarJugador(p); 
                msjRetorno.Retorno = "FALLO";
            }
            msjRetorno.LetraPalabra = s;
            msjRetorno.Accion = "PROBAR_PALABRA";
            return msjRetorno;
        }
    }
}
