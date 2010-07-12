using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoFish
{
    class Game
    {
        private List<Player> players;
        private Dictionary<Card.Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;

        public Game(string playerName, string[] opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)
            {
                players.Add(new Player(player, random, textBoxOnForm));
            }
            books = new Dictionary<Card.Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }

        public void Deal()
        {
            stock.Shuffle();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < players.Count; j++)
                {
                    players[j].TakeCard(stock.Deal());
                }
            }
        }

        public bool PlayOneRound(int selectedPlayerCard)
        {
            players[0].AskForACard(players, selectedPlayerCard, stock, players[0].Peek(selectedPlayerCard).Value);
            PullOutBooks(players[0]);
            if (players[0].CardCount == 0)
                for (int i = 0; i < 5; i++)
                {
                    players[0].TakeCard(stock.Deal(0));
                    if (stock.Count == 0)
                    {
                        textBoxOnForm.Text += "The stock is out of cards. Game over!";
                        return true;
                    }
                }
                
            for (int i = 1; i < players.Count; i++)
            {
                players[i].AskForACard(players, i, stock);
                PullOutBooks(players[i]);
                if (players[i].CardCount == 0)
                    for (int j = 0; j < 5; j++)
                    {
                        players[i].TakeCard(stock.Deal(0));
                        if (stock.Count == 0)
                        {
                            textBoxOnForm.Text += "The stock is out of cards. Game over!";
                            return true;
                        }
                    }
            }
            players[0].SortHand();
            return false;
        }

        public bool PullOutBooks(Player player)
        {
            List<Card.Values> list = player.PullOutBooks();
            foreach (Card.Values value in list)
            {
                books.Add(value, player);
            }
            if (player.CardCount == 0)
                return true;
            else 
                return false;
        }

        public string DescribeBooks()
        {
            string description = "";
            foreach (Card.Values key in books.Keys)
            {
                description += books[key].Name + " has a book of " + Card.Plural(key) + "." + "\r\n";
            }
            return description;
        }

        public string GetWinnerName()
        {
            throw new System.NotImplementedException();
        }

        public string[] GetPlayerCardnames()
        {
            return players[0].GetCardNames();
        }

        public string DescribePlayerhands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += players[i].Name + " has " + players[i].CardCount;
                if (players[i].CardCount == 1)
                    description += " card.\r\n";
                else
                    description += " cards.\r\n";
            }
            description += "The stock has " + stock.Count + " cards left.";
            return description;
        }
    }
}
