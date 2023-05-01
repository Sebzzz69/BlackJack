using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Card
    {
        private string face;
        private string suite;
        internal int value;
        internal bool hasBeenDealt;

        public Card(string cardFace, string cardSuite, int cardValue)
        {
            this.face = cardFace;
            this.suite = cardSuite;
            this.value = cardValue;
            hasBeenDealt = false;

        }


        // Ovverrides defualt ToPrint() to be able to print cards customly 
        public override string ToString()
        {
            return face + " of " + suite + $"({value})";
        }
    }
}
