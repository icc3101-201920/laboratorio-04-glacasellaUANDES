using Laboratorio_2_OOP_201902;
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
        private List<Deck> decks;
        private Board boardGame;
        private bool endGame;

        

        //Constructor
        public Game()
        {
            Random random = new Random();
            players = new Player[2] { new Player(), new Player() };
            ActivePlayer = players[random.Next(0, 2)];
            boardGame = new Board();
            EndGame = false;
            // Accedemos a la lista de cartas de cada jugador
            Deck DP1 = players[0].Deck;
            Deck DP2 = players[1].Deck;
            // Agregamos los decks a la lista de decks
            this.decks.Add(DP1);
            this.decks.Add(DP2);
        }

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




        // Metodos que se piden en el laboratorio
        public void agregarCartasAlArchivo()
        {
            // Buscamos la ruta hacia Decks.txt
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.
            Parent.FullName + @"\Files\Decks.txt";

            // Abrimos el archivo para leer de el
            StreamReader reader = new StreamReader(path);

            // Leemos la primera linea
            string line = reader.ReadLine();
            // Mientras no lleguemos al final del deck, vamos agregando cartas
            while (line != "END")
            {

                line = reader.ReadLine();
            }
            reader.Close();
        }
    }
}
