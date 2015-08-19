using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class RPSgame
    {
        public enum Hand {Rock = 1, Papper, Scissors};
        public enum Outcome  {Win, Lose, Tie};

        public Hand ComputerHand { get; set; }
        public Hand PlayerHand { get; set; }
        public char PlayerSelection { get; set;}

        private bool validateSelection()
        {
            char value = Char.ToUpper(PlayerSelection);
            
            if(value != 'R' && value != 'P' && value != 'S')
            {
                return false;
            }
            
            return true;
        }

        public void PlayGame()
        {
            bool gameOver = false;
            var rand = new Random();
            char response;

            while (!gameOver)
            {
                Screen();
                PlayerSelection = Convert.ToChar(Console.ReadLine());
                getUserHand();
                ComputerHand = (Hand)rand.Next(1, 4);
                Console.Clear();
                Console.WriteLine("Computer's hand: {0}", ComputerHand);
                Console.WriteLine("Player's hand: {0}", PlayerHand);

                if (DeterminateWinner() == Outcome.Win)
                {
                    Console.WriteLine("{0} beats {1}", PlayerHand, ComputerHand);
                    Console.WriteLine("Player wins.");
                }
                else if (DeterminateWinner() == Outcome.Lose)
                {
                    Console.WriteLine("{0} beats {1}", ComputerHand, PlayerHand);
                    Console.WriteLine("Player lose.");
                }
                else
                {
                    Console.WriteLine("It's a tie.");
                }

                Console.WriteLine("Another game (y/n)?");
                response = Convert.ToChar(Console.ReadLine());

                while (valdiateResponse(response) == false)
                {
                    Console.WriteLine("Invalid input. Please re-enter:");
                    response = Convert.ToChar(Console.ReadLine());
                }

                if (Char.ToUpper(response) == 'N')
                    gameOver = true;

                Console.Clear();

            }
             
        }

        public Hand getUserHand()
        {
            while (!validateSelection())
            {
                Console.Clear();
                Console.WriteLine("Invalid input");
                Screen();
                PlayerSelection = Convert.ToChar(Console.ReadLine());

            }

            switch (Char.ToUpper(PlayerSelection))
            {
                case 'R': PlayerHand = Hand.Rock; break;
                case 'P': PlayerHand = Hand.Papper; break;
                case 'S': PlayerHand = Hand.Scissors; break;
                default: throw new Exception("Unexpected Error");
            }

            return PlayerHand;
        }

        public bool valdiateResponse(char response)
        {
            if (Char.ToUpper(response) != 'Y' && Char.ToUpper(response) != 'N')
                return false;

            return true;
        }

        public Outcome DeterminateWinner()
        {
            if (PlayerHand == Hand.Rock && ComputerHand == Hand.Scissors)
            {
                return Outcome.Win;
            }
            else if (PlayerHand == Hand.Papper && ComputerHand == Hand.Rock)
            {
                return Outcome.Win;
            }
            else if (PlayerHand == Hand.Scissors && ComputerHand == Hand.Papper)
            {
                return Outcome.Win;
            }
            else if (PlayerHand == Hand.Rock && ComputerHand == Hand.Papper)
            {
                return Outcome.Lose;
            }
            else if (PlayerHand == Hand.Papper && ComputerHand == Hand.Scissors)
            {
                return Outcome.Lose;
            }
            else if (PlayerHand == Hand.Scissors && ComputerHand == Hand.Rock)
            {
                return Outcome.Lose;
            }

            return Outcome.Tie;
        }

        private void Screen()
        {
            Console.WriteLine("Rock - R");
            Console.WriteLine("Papper - P");
            Console.WriteLine("Scissers - S");
            Console.WriteLine("Please chose:");
        }
    }
}
