using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using static Practica1Agentes.MainWindow;

namespace Practica1Agentes
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Cancion
        {
            public string Nombre { get; set; }
            public string Genero { get; set; }
            public string Artista { get; set; }

            public Cancion(string nombre, string genero, string artista)
            {
                Nombre = nombre;
                Genero = genero;
                Artista = artista;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Cancion> canciones = new List<Cancion>()
            {
                new Cancion("Bohemian Rhapsody", "Rock", "Queen"),
                new Cancion("Imagine", "Pop", "John Lennon"),
                new Cancion("El Paso del Gigante", "Cumbia", "Sonador"),
                new Cancion("Despacito", "Reggaeton", "Luis Fonsi"),
                new Cancion("Billie Jean", "Pop", "Michael Jackson"),
                new Cancion("Hotel California", "Rock", "Eagles"),
                new Cancion("Dancing Queen", "Pop", "ABBA"),
                new Cancion("Livin' on a Prayer", "Rock", "Bon Jovi"),
                new Cancion("Gasolina", "Reggaeton", "Daddy Yankee"),
                new Cancion("Iron Man", "Metal", "Black Sabbath"),
                new Cancion("Cumbia de los Monjes", "Cumbia", "Gran Encuentro"),
                new Cancion("Master of Puppets", "Metal", "Metallica"),
                new Cancion("17 años", "Cumbia", "Los Angeles Azules"),
                new Cancion("Me porto bonito", "Reggaeton", "Bad Bunny"),
                new Cancion("Back in Black", "Metal", "AC/DC"),
            };

            Dictionary<string, int> generoCount = new Dictionary<string, int>();
            Cancion[] cancionesArray = canciones.ToArray();
            Random random = new Random();
            for (int i = 0; i < cancionesArray.Length; i++)
            {
                int j = random.Next(i + 1);
                Cancion temp = cancionesArray[i];
                cancionesArray[i] = cancionesArray[j];
                cancionesArray[j] = temp;
            }

            foreach (Cancion cancion in cancionesArray)
            {
                MessageBoxResult respuesta = MessageBox.Show($"¿Te gusta {cancion.Nombre} de {cancion.Artista}?", "Canción", MessageBoxButton.YesNo);

                if (respuesta == MessageBoxResult.Yes)
                {
                    if (generoCount.ContainsKey(cancion.Genero))
                    {
                        generoCount[cancion.Genero]++;
                    }
                    else
                    {
                        generoCount[cancion.Genero] = 1;
                    }
                }
            }

            string generoFavorito = generoCount.OrderByDescending(g => g.Value).First().Key;
            RecomendarCanciones(generoFavorito);
        }

        private void RecomendarCanciones(string generoFavorito)
        {
            List<string> recomendaciones = new List<string>();

            if (generoFavorito == "Rock")
            {
                tbx.Text = "Genero favorito: Rock";
                MessageBoxResult Subrock = MessageBox.Show($"Tu Genero favorito fue Rock, ¿Te gusta el Rock Indie?", "Subgeneros Rock", MessageBoxButton.YesNo);
                if (Subrock == MessageBoxResult.Yes)
                {
                    recomendaciones.Add("Creep - Radiohead");
                    recomendaciones.Add("Do I Wanna Know - Arctic Monkeys");
                }
                else if (Subrock == MessageBoxResult.No)
                {
                    recomendaciones.Add("Free Birde - Lynyrd Skynyrd ");
                    recomendaciones.Add("Losing My Religion - R.E.M");
                }
                MessageBoxResult Subrock1 = MessageBox.Show($"¿Te gusta el Rock Alternativo?", "Subgeneros Rock", MessageBoxButton.YesNo);
                if (Subrock1 == MessageBoxResult.Yes)
                {
                    recomendaciones.Add("Zombie - The Cranberries");
                    recomendaciones.Add("One - U2");
                }
                else if (Subrock1 == MessageBoxResult.No)
                {
                    recomendaciones.Add("Smells Like Teen Spirit - Nirvana");
                    recomendaciones.Add("Wonderwall - Oasis");
                }
                MessageBoxResult Subrock2 = MessageBox.Show($"¿Te gusta el Rock Latino?", "Subgeneros Rock", MessageBoxButton.YesNo);
                if (Subrock2 == MessageBoxResult.Yes)
                {
                    recomendaciones.Add("Viento - Caifanes");
                    recomendaciones.Add("Música Ligera - Soda Stereo");
                }
                else if (Subrock2 == MessageBoxResult.No)
                {
                    recomendaciones.Add("Karma Police - Radiohead");
                    recomendaciones.Add("Black Hole Sun - Soundgarden");
                }
            }
            else if (generoFavorito == "Pop")
            {
                tbx.Text = "Genero favorito: Pop";
                MessageBoxResult Subpop = MessageBox.Show($"Tu Genero favorito fue Pop, ¿Te gusta el Kpop?", "Subgeneros Pop", MessageBoxButton.YesNo);
                if (Subpop == MessageBoxResult.Yes)
                {
                    recomendaciones.Add("Dynamyte - BTS");
                    recomendaciones.Add("Queen Card - (G)I-DLE");
                }
                else if (Subpop == MessageBoxResult.No)
                {
                    recomendaciones.Add("Bad Romance - Lady Gaga");
                    recomendaciones.Add("Lost on You - LP");
                }
                MessageBoxResult Subpop1 = MessageBox.Show($"¿Te gusta el Pop Latino?", "Subgeneros Pop", MessageBoxButton.YesNo);
                if (Subpop1 == MessageBoxResult.Yes)
                {
                    recomendaciones.Add("Rosa Pastel - Belanova");
                    recomendaciones.Add("Don - Miranda!");
                }
                else if (Subpop1 == MessageBoxResult.No)
                {
                    recomendaciones.Add("Blinding Lights - The Weeknd");
                    recomendaciones.Add("Out of time - The Weeknd");
                }
                MessageBoxResult Subpop2 = MessageBox.Show($"¿Te gusta el Pop Alternativo?", "Subgeneros Pop", MessageBoxButton.YesNo);
                if (Subpop2 == MessageBoxResult.Yes)
                {
                    recomendaciones.Add("Bad Guy - Billie Elish");
                    recomendaciones.Add("Thunder - Imagine Dragons");
                }
                else if (Subpop2 == MessageBoxResult.No)
                {
                    recomendaciones.Add("Perfect - Ed Sheeran");
                    recomendaciones.Add("Stitches - Shawn Mendes");
                }
            }
            else if (generoFavorito == "Metal")
            {
                tbx.Text = "Genero favorito: Metal";
                MessageBoxResult Submetal = MessageBox.Show($"Tu Genero favorito fue Metal, ¿Te gusta el Heavy Metal?", "Subgeneros Metal", MessageBoxButton.YesNo);
                if (Submetal == MessageBoxResult.Yes)
                {
                    recomendaciones.Add("Nothing Else Matters - Metallica");
                    recomendaciones.Add("The Unforgiven - Metallica");
                }
                else if (Submetal == MessageBoxResult.No)
                {
                    recomendaciones.Add("Sweet Child O' Mine - Guns N'Roses");
                    recomendaciones.Add("Welcome to the Jungle - Guns N'Roses");
                }
                MessageBoxResult Submetal1 = MessageBox.Show($"¿Te gusta el Trash Metal?", "Subgeneros Metal", MessageBoxButton.YesNo);
                if (Submetal1 == MessageBoxResult.Yes)
                {
                    recomendaciones.Add("Raining Blood - Slayer");
                    recomendaciones.Add("Symphony of Destruction - Megadeath");
                }
                else if (Submetal1 == MessageBoxResult.No)
                {
                    recomendaciones.Add("Paranoid - Black Sabbath");
                    recomendaciones.Add("Enter Sandman - Metallica");
                }
                MessageBoxResult Submetal2 = MessageBox.Show($"¿Te gusta el Power Metal?", "Subgeneros Metal", MessageBoxButton.YesNo);
                if (Submetal2 == MessageBoxResult.Yes)
                {
                    recomendaciones.Add("Through the Fire and Flames - Dragonforce");
                    recomendaciones.Add("Valhalla - Blind Guardian");
                }
                else if (Submetal2 == MessageBoxResult.No)
                {
                    recomendaciones.Add("The Tropper - Iron Maiden");
                    recomendaciones.Add("Whole Lotta Rosie - Led Zeppelin");
                }
            }
            else if (generoFavorito == "Cumbia")
            {
                tbx.Text = "Genero favorito: Cumbia";
                recomendaciones.Add("Procura - ChiChi Peralta");
                recomendaciones.Add("Escandalo - La Sonora Dinamita");
                recomendaciones.Add("Baila esta cumbia - Selena");
                recomendaciones.Add("Todo me gusta de ti - Aaron y su grupo ilusion");
                recomendaciones.Add("Oye mujer - Raymix");
                recomendaciones.Add("La mujer del Pelotero - Merenglass Grupo");
            }
            else if (generoFavorito == "Reggaeton")
            {
                tbx.Text = "Genero favorito: Reggaeton";
                recomendaciones.Add("Mi Gente - J Balvin");
                recomendaciones.Add("Tusa - Karol G");
                recomendaciones.Add("Yonaguni - Bad Bunny");
                recomendaciones.Add("Pepas - Farruko");
                recomendaciones.Add("PROVENZA - Karol G");
                recomendaciones.Add("DÁKITI - Bad Bunny");
            }

            RecomendacionesListBox.ItemsSource = recomendaciones;
        }
    }
}
