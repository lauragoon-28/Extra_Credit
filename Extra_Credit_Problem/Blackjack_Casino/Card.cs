using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack_Casino
{
    class Card
    {
        public string suit { get; set; }
        
        public int value { get; set; }

        public int numericalValue { get; set; }

        public Card()
        {
            Random rand = new Random();
            value = rand.Next(1, 14);

            if (value > 10)
            {
                numericalValue = 10;
            }
            else 
            {
                numericalValue = value;
            }

            int randSuit = rand.Next(1, 5);
            if (randSuit == 1)
            {
                suit = "Hearts";
            }
            else if (randSuit == 2)
            {
                suit = "Spades";
            }
            else if (randSuit == 3)
            {
                suit = "Diamonds";
            }
            else if (randSuit == 4)
            {
                suit = "Clubs";
            }
        }

        public override string ToString()
        {
            if (value == 1)
            {
                return $"Ace of {suit}";
            }
            else if (value == 11)
            {
                return $"Jack of {suit}";
            }
            else if (value == 12)
            {
                return $"Queen of {suit}";
            }
            else if (value == 13)
            {
                return $"King of {suit}";
            }
            return $"{value} of {suit}";
        }

    }
}
