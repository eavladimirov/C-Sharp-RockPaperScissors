using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new RPSgame();
            char response;

            Console.WriteLine("Would you like to play a game of Rock, Pappre, Scissors?(y/n)");
            response = Convert.ToChar(Console.ReadLine());

            while (game.valdiateResponse(response) == false)
            {
                Console.WriteLine("Invalid input. Please re-enter:");
                response = Convert.ToChar(Console.ReadLine());
            }

            if (Char.ToUpper(response) == 'Y')
            {
                Console.Clear();
                game.PlayGame();
            }

            Console.WriteLine("Good bye.");
            Console.ReadLine();  //Pouse the screen
        }
    }
}
