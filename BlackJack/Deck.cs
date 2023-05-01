using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        private Card[] cardDeck;
        private int currentCard;
        private const int numberOfCards = 312; // Number of all cards in game
        private Random randNum;



        public Deck()
        {
            // Array for all the faces
            string[] faces = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven",
                              "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
            // Array for all suites
            string[] suite = { "Hearts", "Clubs", "Diamonds", "Spades" };

            int[] cardValue = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };


            cardDeck = new Card[numberOfCards];

            currentCard = 0;

            randNum = new Random();

            // Fills up deck with cards
            int j = 0;
            for (int i = 0; i < cardDeck.Length; i++)
            {                
                cardDeck[i] = new Card(faces[i % 13], suite[j / 13], cardValue[i % 13]);

                j++;

                // Devides the cards into suites
                if ((j / 13) == 4)
                {
                    j = 0;
                }
                

            }
        }

        internal void ShuffleDeck()
        {
            currentCard = 0;
            
            // Uses and empty card object to swaps
            // around the cards randomly
            for (int i = 0; i < cardDeck.Length; i++)
            {
                int randomIndex = randNum.Next(numberOfCards);
                Card tmp = cardDeck[randomIndex];
                cardDeck[i] = cardDeck[randomIndex];
                cardDeck[randomIndex] = tmp;
            }
            
        }

        internal Card DealCard()
        {
            
            bool gaveCard = false;

            // Loops until a correct card has been dealt
            while (!gaveCard)
            {
                // Chooses a random card within all the cards
                int randomCard = randNum.Next(numberOfCards);


                if (currentCard < cardDeck.Length && !cardDeck[randomCard].hasBeenDealt)
                {
                    // Returns a card that has not been dealt yet
                    
                    gaveCard = true;
                    cardDeck[randomCard].hasBeenDealt = true;
                    return cardDeck[randomCard];
                }
            }
            return null;
            
        }
    }
}
