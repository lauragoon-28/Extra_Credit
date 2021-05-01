using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack_Casino
{
    class Casino
    {
        public double balance { get; set; }

        public Casino()
        {
            balance = 500;
        }

        public Casino(double deposit)
        {
            balance = deposit;
        }

        public Card GetCard()
        {
            return new Card();
        }

        public void PlayHand()
        {
            List<Card> dealerHand = new List<Card>();
            List<Card> playerHand = new List<Card>();
            Console.WriteLine($"Balance: {balance.ToString("C")}");
            Console.WriteLine("How much do you want to bet?");
            string answer = Console.ReadLine();
            double bet = 0;
            if (double.TryParse(answer, out bet ) == false)
            {
                Console.WriteLine("Invalid input. You're kicked out of Vegas");
                return;
            }
            while (bet <= 0 || bet > balance)
            {
                Console.WriteLine("Invalid bet. Try again"); 
                Console.WriteLine("How much do you want to bet?");
                answer = Console.ReadLine();
                if (double.TryParse(answer, out bet) == false)
                {
                    Console.WriteLine("Invalid input. You're kicked out of Vegas");
                    return;
                }
            }
            balance = balance - bet;

            dealerHand.Add(new Card());
            dealerHand.Add(new Card());
            int dealerHandValue = dealerHand[0].numericalValue + dealerHand[1].numericalValue;
            string dealerHandHidden = $"Dealer Hand: {dealerHand[0]}, *HIDDEN CARD*";
            

            playerHand.Add(new Card());
            playerHand.Add(new Card());
            int playerHandValue = playerHand[0].numericalValue + playerHand[1].numericalValue;

            Console.WriteLine(dealerHandHidden);
            Console.WriteLine($"Your Hand:");
            playerHand.ForEach(Console.WriteLine);
            Console.WriteLine($"Your Hand Value: { playerHandValue}");

            Console.WriteLine("Would you like to hit or stand?");
            answer = Console.ReadLine();

            while (answer.ToLower() == "hit" && playerHandValue <= 21)
            {
                Card temp = new Card();
                playerHand.Add(temp);
                playerHandValue += temp.numericalValue;
                Console.WriteLine();
                Console.WriteLine(dealerHandHidden);
                Console.WriteLine($"Your Hand:");
                playerHand.ForEach(Console.WriteLine);
                Console.WriteLine($"Your Hand Value: { playerHandValue}"); if (playerHandValue > 21) 
                {
                    Console.WriteLine($"YOU BUST, Your new balance is {balance.ToString("C")}");
                    return;
                }
                Console.WriteLine("Would you like to hit or stand?");
                answer = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine("DEALER'S TURN:");
            Console.WriteLine($"Dealer's Hand:");
            playerHand.ForEach(Console.WriteLine);
            Console.WriteLine($"Dealer's Hand Value: { dealerHandValue}");
            while (dealerHandValue < 17)
            {
                Card temp = new Card();
                dealerHand.Add(temp);
                dealerHandValue += temp.numericalValue;
                Console.WriteLine($"Dealer's Hand:");
                playerHand.ForEach(Console.WriteLine);
                Console.WriteLine($"Dealer's Hand Value: { dealerHandValue}");
            }

            if (dealerHandValue > 21) 
            {
                Console.WriteLine($"THE DEALER BUSTED, YOU WIN {bet}");
                balance += bet * 2;
                Console.WriteLine($"Your new balance is {balance.ToString("C")}");
                return;
            }
            if (dealerHandValue == playerHandValue) 
            {
                Console.WriteLine($"YOU TIED, YOU KEEP YOUR MONEY");
                balance += bet;
                Console.WriteLine($"Your new balance is {balance.ToString("C")}");
                return;
            }
            if (dealerHandValue > playerHandValue)
            {
                Console.WriteLine($"YOU LOST");
                Console.WriteLine($"Your new balance is {balance.ToString("C")}");
                return;
            }
            if (dealerHandValue < playerHandValue)
            {
                Console.WriteLine($"YOU WIN, YOU WON {bet}");
                balance += 2*bet;
                Console.WriteLine($"Your new balance is {balance.ToString("C")}");
                return;
            }
        }

    }
}
