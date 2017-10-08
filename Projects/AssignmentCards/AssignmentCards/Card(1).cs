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
    public enum Rank { Ace = 1, Deuce = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7,
        Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13 };
    public enum Suit { Spades = 9824, Clubs = 9827, Hearts = 9829, Diamonds = 9830 };

    struct Card : IComparable<Card>
    {
        public Rank rank { get; private set; }
        public Suit suit { get; private set; }


        public Card(Rank theRank, Suit theSuit)
            : this() //calling current default constructor
        {
            rank = theRank;
            suit = theSuit;
        }

        public int CompareTo(Card other)
        {
            if (this.rank == other.rank)
            {
                if (this.suit == other.suit)
                    return 0;
                if (this.suit > other.suit)
                    return 1;
            }
            if (this.rank > other.rank)
                return 1;
            return -1;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", (char)suit, rank);
        }
    }
}
