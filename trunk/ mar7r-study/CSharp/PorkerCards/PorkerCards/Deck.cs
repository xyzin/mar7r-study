using System;
using System.Collections.Generic;
using System.Text;

namespace PorkerCards
{
    class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit < 4; suit++)
            {
                for (int value = 1; value < 14; value++)
                {
                    cards.Add(new Card((Card.Suits)suit, (Card.Values)value));
                }
            }
        }

        public Deck(Card[] initalCards)
        {
            cards = new List<Card>(initalCards);
        }

        public int Count
        {
            get
            {
                return cards.Count;
            }
        }

        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        public Card Deal(int index)
        {
            Card cardToDeal = cards[index];
            cards.RemoveAt(index);
            return cardToDeal;
        }

        public void Shuffle()
        {
            Random random = new Random();
            Card shuffleCard;
            for (int i = 0; i < 20; i++)
            {
                shuffleCard = Deal(random.Next(cards.Count));
                cards.Add(shuffleCard);
            }
        }

        public string[] GetCardNames()
        {
            List<string> names = new List<string>();
            foreach (Card c in cards)
            {
                names.Add(c.Name);
            }
            return names.ToArray();
        }
        
        public void Sort()
        {
            cards.Sort(new CardComparer_bySuit());
        }
    }
}
