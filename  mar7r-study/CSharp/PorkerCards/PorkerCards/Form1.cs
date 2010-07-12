using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PorkerCards
{
    public partial class Form1 : Form
    {
        Deck deck1;
        Deck deck2;

        public Form1()
        {
            InitializeComponent();
            ResetDeck(1);
            ResetDeck(2);
        }

        private void btnResetDeck1_Click(object sender, EventArgs e)
        {
            ResetDeck(1);
        }

        private void btnResetDeck2_Click(object sender, EventArgs e)
        {
            ResetDeck(2);
        }

        private void moveToDeck2_Click(object sender, EventArgs e)
        {
            Card moveCard = deck1.Deal(listDeck1.SelectedIndex);
            deck2.Add(moveCard);
            RedrawDeck(1);
            RedrawDeck(2);
        }

        private void moveToDeck1_Click(object sender, EventArgs e)
        {
            Card moveCard = deck2.Deal(listDeck2.SelectedIndex);
            deck1.Add(moveCard);
            RedrawDeck(1);
            RedrawDeck(2);
        }

        private void btnShuffleDeck1_Click(object sender, EventArgs e)
        {
            deck1.Shuffle();
            RedrawDeck(1);
        }

        private void ResetDeck(int DeckNumber)
        {
            if (DeckNumber == 1)
            {
                Random random = new Random();
                int cardsOfDeck1 = random.Next(1, 11);
                Card[] cards = new Card[cardsOfDeck1];
                for (int i = 0; i < cardsOfDeck1; i++)
                {
                    cards[i] = new Card((Card.Suits)random.Next(4), (Card.Values)random.Next(1, 14));
                }
                deck1 = new Deck(cards);
                deck1.Sort();
                RedrawDeck(1);
            }
            else
            {
                deck2 = new Deck();
                RedrawDeck(2);
            }
        }

        private void btnShuffleDeck2_Click(object sender, EventArgs e)
        {
            deck2.Shuffle();
            RedrawDeck(2);
        }

        private void RedrawDeck(int DeckNumber)
        {
            if (DeckNumber == 1)
            {
                listDeck1.Items.Clear();
                foreach (string cardName in deck1.GetCardNames())
                {
                    listDeck1.Items.Add(cardName);
                }
                lbDeck1.Text = "Deck #1 (" + deck1.Count + " cards)";
                listDeck1.SelectedIndex = 0;
            }
            else
            {
                listDeck2.Items.Clear();
                foreach (string cardName in deck2.GetCardNames())
                {
                    listDeck2.Items.Add(cardName);
                }
                lbDeck2.Text = "Deck #1 (" + deck2.Count + " cards)";
                listDeck2.SelectedIndex = 0;
            }
        }
    }
}
