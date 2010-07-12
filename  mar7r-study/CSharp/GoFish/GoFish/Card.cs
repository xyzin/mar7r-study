using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoFish
{
    class Card
    {
        private Suits suit;
        private Values value;

        public Card(Card.Suits suit, Card.Values value)
        {
            this.suit = suit;
            this.value = value;
        }

        public static string Plural(Card.Values value)
        {
            if (value == Values.Six)
                return "Sixes";
            else
                return value.ToString() + "s";
        }

        public enum Suits
        {
            Spades,
            Clubs,
            Diamonds,
            Hearts
        }

        public enum Values
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten =10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

        public string Name
        {
            get
            {
                return value + " of " + suit;
            }
        }

        public Card.Suits Suit
        {
            get
            {
                return suit;
            }
        }

        public Card.Values Value
        {
            get
            {
                return value;
            }
        }
    }
}
