using Laboratorio_2_OOP_201902;
using Laboratorio_2_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Game
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private Board boardGame;
        private bool endGame;


        // ------------------ATRIBUTOS QUE SE PIDEN EN EL LAB----------------------------------
        // Atributo decks es una lista de mazos. En el hay 2 decks, uno para cada jugador
        private List<Deck> decks;
        // Atributo captainCards es una lista de cartas de tipo capitan
        private List<SpecialCard> captainCards;
        // ------------------------------------------------------------------------------------



        // -----------------MODIFIQUE EL CONSTRUCTOR COMO SE PIDE EN EL LAB -------------------
        //Constructor
        public Game()
        {
            Random random = new Random();
            players = new Player[2] { new Player(), new Player() };
            ActivePlayer = players[random.Next(0, 2)];
            boardGame = new Board();
            EndGame = false;

            // Cada deck tiene sus cartas
            // Creamos una nueva lista de decks
            List<Deck> decks = new List<Deck>();
            this.decks = decks;

            Deck deckJ1 = new Deck();
            Deck deckJ2 = new Deck();
            decks.Add(deckJ1);
            decks.Add(deckJ2);

            this.captainCards = new List<SpecialCard>();

        }
        // ---------------------------------------------------------------------------------------




        // -------------------------- ESTO NO SE PIDE, ES DEL CODIGO ANTERIOR ------------------------
        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }
        public bool EndGame
        {
            get
            {
                return this.endGame;
            }
            set
            {
                endGame = value;
            }
        }

        //Metodos
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void Play()
        {
            throw new NotImplementedException();
        }
        // ---------------------------------------------------------------------------------



        // ---------------------------- METODOS QUE SE PIDEN EN EL LAB ---------------------------------
        public void agregarCartasALosMazos()
        {
            // Buscamos la ruta hacia Decks.txt
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.
            Parent.FullName + @"\Files\Decks.txt";

            // Abrimos el archivo para leer de el
            StreamReader reader = new StreamReader(path);

            // Leemos la primera linea. En este caso, line guarda "START"
            string line = reader.ReadLine();
            // Creamos una lista de cartas para guardarlas todas
            List<Card> aux = new List<Card>();

            // Mientras no lleguemos al final del deck, vamos agregando cartas
            while (true)
            {
                // line ahora guarda la primera linea que realmente es una carta
                line = reader.ReadLine();
                if (line == "END")
                {
                    break;
                }
                // Separado es un array donde se guardan en cada valor las caracteristica de la carta
                string[] separado = line.Split(",");
                if (separado[0] == "CombatCard")
                {
                    CombatCard nuevaCarta = new CombatCard(separado[1], (EnumType)Enum.Parse(typeof(EnumType), separado[2]),separado[3], int.Parse(separado[4]), bool.Parse(separado[5]));
                    aux.Add(nuevaCarta);
                }
                else
                {
                    SpecialCard nuevaCarta = new SpecialCard(separado[1], (EnumType)Enum.Parse(typeof(EnumType), separado[2]), separado[3]);
                    aux.Add(nuevaCarta);
                }
            }

            // Agregamos las cartas al deck 0 (del jugador 1)
            decks[0].Cards = aux;

            // Reiniciamos el string line
            line = "";
            List<Card> aux2 = new List<Card>();
            // Ahora line es START
            line = reader.ReadLine();

            while (true)
            {
                // line ahora guarda la primera linea que realmente es una carta
                line = reader.ReadLine();
                if (line == "END")
                {
                    break;
                }
                // Separado es un array donde se guardan en cada valor las caracteristica de la carta
                string[] separado = line.Split(",");
                // Dependiendo de la clase creamos una carta u otra
                if (separado[0] == "CombatCard")
                {
                    // Creamos la carta y la agregamos a la lista
                    CombatCard nuevaCarta = new CombatCard(separado[1], (EnumType)Enum.Parse(typeof(EnumType), separado[2]), separado[3], int.Parse(separado[4]), bool.Parse(separado[5]));
                    aux2.Add(nuevaCarta);
                }
                else
                {
                    SpecialCard nuevaCarta = new SpecialCard(separado[1], (EnumType)Enum.Parse(typeof(EnumType), separado[2]), separado[3]);
                    aux2.Add(nuevaCarta);
                }
            }

            // Agregamos las cartas al deck 1 (del jugador 2)
            decks[1].Cards = aux2;

            // Ya podemos cerrar el archivo
            reader.Close();
        }


        // Metodo que hice para verificar que las cartas se estaban agregando correctamente a los decks
        // Si quieres pruebalo, muestra el name y el type de todas las special y combat card del archivo
        public void mostrarCartas()
        {
            foreach (Deck deck in decks)
            {
                foreach (Card card in deck.Cards)
                {
                    Console.WriteLine($"{card.Name}, {card.Type}");
                }
            }
        }


        public void agregarCapitanes()
        {
            // Buscamos la ruta hacia Decks.txt
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.
            Parent.FullName + @"\Files\Captains.txt";

            // Abrimos el archivo para leer de el
            StreamReader reader = new StreamReader(path);


            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] aux = line.Split(",");
                captainCards.Add(new SpecialCard(aux[1], (EnumType)Enum.Parse(typeof(EnumType), aux[2]), aux[3]));
                Console.WriteLine(line);
            }
            reader.Close();

        }

        // ------------------------------------------------------------------------------------------------------------

    }
}
