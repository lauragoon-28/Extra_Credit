using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack_Casino
{
    class Card
    {
        public string Suit { get; set; }
        
        public int Value { get; set; }

        public int NumericalValue { get; set; }

        public Card()
        {
            Random rand = new Random();
            Value = rand.Next(1, 14);

            if (Value > 10)
            {
                NumericalValue = 10;
            }
            else 
            {
                NumericalValue = Value;
            }

            int randSuit = rand.Next(1, 5);
            if (randSuit == 1)
            {
                Suit = "Hearts";
            }
            else if (randSuit == 2)
            {
                Suit = "Spades";
            }
            else if (randSuit == 3)
            {
                Suit = "Diamonds";
            }
            else if (randSuit == 4)
            {
                Suit = "Clubs";
            }
        }

        public override string ToString()
        {
            if (Value == 1)
            {
                return $"Ace of {Suit}";
            }
            else if (Value == 11)
            {
                return $"Jack of {Suit}";
            }
            else if (Value == 12)
            {
                return $"Queen of {Suit}";
            }

            else if (Value == 13)
            {
                return $"King of {Suit}";
            }
            return $"{Value} of {Suit}";
        }

    }
}
