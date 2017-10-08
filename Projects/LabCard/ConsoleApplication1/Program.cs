using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card1 = new Card(Rank.Five, Suit.Clubs);
            Console.WriteLine(card1);
        }
    }
}
