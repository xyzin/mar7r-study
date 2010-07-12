using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoFish
{
    class Player
    {
        private string name;
        private Random random;
        private Deck cards;
        private TextBox textBoxOfForm;

        public Player(String name, Random random, TextBox textBoxOfForm)
        {
            this.name = name;
            this.random = random;
            this.cards = new Deck(new Card[]{});
            this.textBoxOfForm = textBoxOfForm;

            textBoxOfForm.Text += name + " has just joined the game." + "\r\n";
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int CardCount
        {
            get
            {
                return cards.Count;
            }
        }

        public List<Card.Values> PullOutBooks()
        {
            List<Card.Values> Books = new List<Card.Values>();
            for (int i = 1; i < 14; i++)
            {
                Card.Values value = (Card.Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                {
                    if (cards.Peek(card).Value == value)
                        howMany++;
                }
                if (howMany == 4)
                {
                    Books.Add(value);
                    cards.PullOutValues(value);
                }
            }
            return Books;
        }

        public Card.Values GetRandomValue()
        {
            return Peek(random.Next(cards.Count)).Value;
        }

        public Deck DoYouHaveAny(Card.Values value)
        {
            Deck returnDeck = cards.PullOutValues(value);
            textBoxOfForm.Text += name + " has " + returnDeck.Count + " " + Card.Plural(value) + "." + "\r\n";
            return returnDeck;
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {
            AskForACard(players, myIndex, stock, GetRandomValue());
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock, Card.Values value)
        {
            int newCards = 0;
            textBoxOfForm.Text += name + " asks if anyone has a " + value + "." + "\r\n";
            foreach (Player p in players)
            {
                if (p.Name == name) continue;
                Deck newDeck = p.DoYouHaveAny(value);
                while (newDeck.Count > 0)
                {
                    cards.Add(newDeck.Deal(0));
                    newCards++;
                }
            }
            if (newCards == 0)
            {
                cards.Add(stock.Deal(0));
                textBoxOfForm.Text += name + " had to draw from the stock." + "\r\n";
                if (stock.Count == 0)
                {
                    textBoxOfForm.Text += "The stock is out of cards. Game over!";
                }
            }
        }

        public void TakeCard(Card card)
        {
            cards.Add(card);
        }

        public string[] GetCardNames()
        {
            return cards.GetCardNames();
        }

        public Card Peek(int cardNumber)
        {
            return cards.Peek(cardNumber);
        }

        public void SortHand()
        {
            cards.SortByValue();
        }
    }
}
