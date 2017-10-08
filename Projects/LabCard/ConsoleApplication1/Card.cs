using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public enum Rank { Deuce, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
    public enum Suit { Spades = 9824, Clubs = 9827, Hearts = 9829, Diamonds = 9830 };

    struct Card
    {
        public Rank rank { get; set; }
        public Suit suit { get; set; }


        public Card(Rank theRank, Suit theSuit)
            : this()
        {
            rank = theRank;
            suit = theSuit;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", rank, (char) suit);
        }
    }
}
