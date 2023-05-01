using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class PlayerHand
    {
        private Card[] hand;
        private int currentCard = 0;
        private int handSize = 21;
        private int amountOfCards;
        internal int handValue;


        public PlayerHand(Deck playableDeck)
        {

            hand = new Card[handSize];

            // Fills up the player hand
            for (int i = 0; i < 2; i++)
            {
                hand[i] = playableDeck.DealCard();

                //Calculate a value of the total hand
                handValue += hand[i].value;

                currentCard = i;
                amountOfCards++;
            }

        }

        internal void DrawCard(Deck playableDeck)
        {
            currentCard++;
            amountOfCards++;

            hand[currentCard] = playableDeck.DealCard();

            // Add new card value to the total hand
            handValue += hand[currentCard].value; 
        }

        internal Card ShowCards()
        {
            int currentCard = 0;

            if (currentCard < hand.Length)
            {
                // Shows all cards
                for (int i = 0; i < amountOfCards; i++)
                {
                    Console.WriteLine(hand[i]);
                }
            }
            return hand[currentCard++];
        }
    }
}
