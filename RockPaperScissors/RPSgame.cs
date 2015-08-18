using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class RPSgame
    {
        public enum Hand {Rock = 1, Paper, Scissors};
        public enum Outcome  {Win, Lose, Tie};

        public Hand ComputerHand { get; set; }
        public Hand PlayerHand { get; set; }
        public char PlayerSelection { get; set;}

        public Hand getUserHand()
        {
            while (!validateSelection)
            {
                Console.Clear();
                Console.WriteLine("Invalid input");
                Screen();
                PlayerSelection = Convert.ToChar(Console.ReadLine());
            }
        }

        private bool validateSelection()
        {
            char value = Char.ToUpper(PlayerSelection);
            
            if(value != 'R' && value != 'P' && value != 'S')
            {
                return false;
            }

            return true;
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
