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
    class Deck
    {
        public List<Card> Cards { get; private set; }
        List<Card> dealt { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
            NewDeck();
        }

        public Deck( List<Card> cardDeck )
        {
            Cards = cardDeck;
        }

        public List<Card> NewDeck()
        {
            foreach (AssignmentCards.Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (AssignmentCards.Suit s in Enum.GetValues(typeof(Suit)))
                {
                    this.Cards.Add(new Card(r, s));
                }
            }
            return Cards;
        }

        public void Shuffle()
        {
            for (int i = Cards.Count -1; i > 0; i--)
            {
                Random random = new Random();
                int j = random.Next(0, i);
                //exchange Cards[j] with Cards[i]
                Card temp = Cards[j];
                Cards[j] = Cards[i];
                Cards[i] = temp;
            }
                
        }

        public List<Card> Deal(int numberToDeal)
        {
            dealt = new List<Card>();
            if (numberToDeal > Cards.Count)
                Console.WriteLine("Sorry, there aren't that many cards in the deck.");
            else
            {
                for (int index = 0; index < numberToDeal; numberToDeal--)
                {
                    dealt.Add(Cards.ElementAt(index));
                    Cards.RemoveAt(index);
                }
            }
            return dealt;
        }

        public override string ToString()
        {
            StringBuilder list = new StringBuilder();
            /*foreach (AssignmentCards.Card c in Cards)
                list.AppendFormat(null, "{0}\n", c.ToString());*/
            //Environment.NewLine);
            int counter = 0;
            while (counter < Cards.Count)
            {
                list.AppendFormat("{0,-9} ", Cards[counter].ToString());
                counter++;
                if (counter % 4 == 0)
                    list.Append("\n");
            }
            return list.ToString();
        }
    }
}
