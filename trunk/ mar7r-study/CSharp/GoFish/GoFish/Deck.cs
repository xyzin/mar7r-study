using System;
using System.Collections.Generic;
using System.Text;

namespace GoFish
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

        public Card Peek(int cardNumber)
        {
            return cards[cardNumber];
        }

        public Card Deal()
        {
            return Deal(0);
        }

        public bool ContainsValue(Card.Values value)
        {
            foreach (Card card in cards)
            {
                if (card.Value == value)
                    return true;
            }
            return false;
        }

        public Deck PullOutValues(Card.Values value)
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count-1; i >= 0; i--)
            {
                if (cards[i].Value == value)
                    deckToReturn.Add(Deal(i));
            }
            return deckToReturn;
        }

        public bool HasBook(Card.Values value)
        {
            int NumberOfCards = 0;
            foreach (Card card in cards)
	        {
                if (card.Value == value)
                    NumberOfCards++;
	        }
            if (NumberOfCards == 4)
                return true;
            else
                return false;
        }

        public void SortByValue()
        {
            cards.Sort(new CardComparer_byValue());
        }
    }
}
