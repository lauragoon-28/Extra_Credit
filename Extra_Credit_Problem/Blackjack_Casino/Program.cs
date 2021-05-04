using System;

namespace Blackjack_Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~Welcome To~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~Laura Goon's~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~CASINO!!!~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("RULES:");
            Console.WriteLine("1. The goal of blackjack is to beat the dealer's hand without going over 21.");
            Console.WriteLine("2. Face cards are worth 10. Aces are worth 1 for simplicity.");
            Console.WriteLine("3. Each player starts with two cards, one of the dealer's cards is hidden until the end.");
            Console.WriteLine("4. To 'Hit' is to ask for another card. To 'Stand' is to hold your total and end your turn.");
            Console.WriteLine("5. If you go over 21 you bust, and the dealer wins regardless of the dealer's hand.");
            Console.WriteLine("6. Dealer will hit until his / her cards total 17 or higher.");
            Console.WriteLine();

            string answer;
            double deposit;
            Console.WriteLine("How much would you like to deposit?");
            answer = Console.ReadLine();
            if (double.TryParse(answer, out deposit) == false)
            {
                Console.WriteLine("Invalid input. Goodbye!");
                return;
            }

            Casino c1 = new Casino(deposit);

            Console.WriteLine("Would you like to play a game of Blackjack? (yes or no)");
            answer = Console.ReadLine();

            while (answer.ToLower() == "yes" && c1.balance > 0)
            {
                c1.PlayHand();
                Console.WriteLine();
                Console.WriteLine("Would you like to play a game of Blackjack? (yes or no)");
                answer = Console.ReadLine();
            }
        }
    }
}
