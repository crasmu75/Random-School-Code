/**
 * Camille Rasmussen
 * A03: Cards
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentCards
{
    class Hand
    {
        public List<Card> Cards { get; private set; }

        public Hand(List<Card> newHand)
        {
            newHand.Sort();
            Cards = newHand;
        }

        public Boolean IsFlush()
        {
            String theSuit = Cards[0].suit.ToString();
            foreach(Card c in Cards)
            {
                if (c.suit.ToString() != theSuit)
                    return false;
            }
            return true;
        }

        public Boolean IsStraight()
        {
            int thatRank = (int) Cards[0].rank;
            int counter = 0;
            foreach(Card c in Cards)
            {
                if(counter < Cards.Count)
                {
                    if ((int)c.rank != thatRank)
                        return false;
                    thatRank++;
                    counter++;
                }
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder list = new StringBuilder();
            foreach (Card c in Cards)
                list.AppendFormat("{0,-10} ", c.ToString());
            if (IsStraight())
                list.Append(" Straight ");
            if (IsFlush())
                list.Append(" Flush");
            return list.ToString();
        }
    }
}
