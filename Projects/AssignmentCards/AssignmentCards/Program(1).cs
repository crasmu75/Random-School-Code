/**
 * Camille Rasmussen
 * A03: Cards
 **/ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssignmentCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new deck and display
            Deck deck = new Deck();
            Console.WriteLine("New Deck:\n");
            Console.WriteLine(deck);

            // shuffle deck and display
            deck.Shuffle();
            Console.WriteLine("\n\nShuffeled Deck:\n");
            Console.WriteLine(deck);

            // deal hands from testDeck and display
            deck = new Deck(TestDeck());
            Console.WriteLine("\n\nDealing hands of 5 cards from the test deck:\n");
            while (deck.Cards.Count >= 5)
            {
                Hand hand = new Hand(deck.Deal(5));
                Console.WriteLine(hand);
            }

            Console.WriteLine();
        }

        #region TestDeck .. to test IsStraight and IsFlush
        private static List<Card> TestDeck()
        {
            List<Card> testDeck = new List<Card>();

            // StaightFlush
            testDeck.Add(new Card(Rank.Five, Suit.Spades));
            testDeck.Add(new Card(Rank.Six, Suit.Spades));
            testDeck.Add(new Card(Rank.Seven, Suit.Spades));
            testDeck.Add(new Card(Rank.Eight, Suit.Spades));
            testDeck.Add(new Card(Rank.Nine, Suit.Spades));

            // Flush
            testDeck.Add(new Card(Rank.Four, Suit.Clubs));
            testDeck.Add(new Card(Rank.Six, Suit.Clubs));
            testDeck.Add(new Card(Rank.Seven, Suit.Clubs));
            testDeck.Add(new Card(Rank.Eight, Suit.Clubs));
            testDeck.Add(new Card(Rank.Queen, Suit.Clubs));

            // Straight
            testDeck.Add(new Card(Rank.Six, Suit.Diamonds));
            testDeck.Add(new Card(Rank.Seven, Suit.Diamonds));
            testDeck.Add(new Card(Rank.Eight, Suit.Hearts));
            testDeck.Add(new Card(Rank.Nine, Suit.Hearts));
            testDeck.Add(new Card(Rank.Ten, Suit.Clubs));

            // not quite a flush
            testDeck.Add(new Card(Rank.Deuce, Suit.Clubs));
            testDeck.Add(new Card(Rank.Nine, Suit.Clubs));
            testDeck.Add(new Card(Rank.Six, Suit.Clubs));
            testDeck.Add(new Card(Rank.Queen, Suit.Clubs));
            testDeck.Add(new Card(Rank.Ten, Suit.Diamonds));

            // not quite a straight
            testDeck.Add(new Card(Rank.Eight, Suit.Clubs));
            testDeck.Add(new Card(Rank.Ten, Suit.Spades));
            testDeck.Add(new Card(Rank.Jack, Suit.Hearts));
            testDeck.Add(new Card(Rank.Queen, Suit.Spades));
            testDeck.Add(new Card(Rank.King, Suit.Diamonds));

            return testDeck;
        }
        #endregion
    }
}