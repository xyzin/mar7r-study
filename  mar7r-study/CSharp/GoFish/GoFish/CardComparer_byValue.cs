using System;
using System.Collections.Generic;
using System.Text;

namespace GoFish
{
    class CardComparer_byValue : IComparer<Card>
    {
        #region IComparer<Card> 멤버

        public int Compare(Card x, Card y)
        {
            if (x.Value > y.Value)
                return 1;
            else if (x.Value < y.Value)
                return -1;
            else
                return 0;
        }

        #endregion
    }

    class CardComparer_bySuit : IComparer<Card>
    {
        #region IComparer<Card> 멤버

        public int Compare(Card x, Card y)
        {
            if (x.Suit > y.Suit)
                return 1;
            else if (x.Suit < y.Suit)
                return -1;
            else //(x.Suit == y.Suit)
            {
                if (x.Value > y.Value)
                    return 1;
                else if (x.Value < y.Value)
                    return -1;
                else
                    return 0;
            }
        }

        #endregion
    }
}
