using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class BlackJackGame
    {

        PlayerHand playerHand;
        DealerHand dealerHand;
        static Deck gameDeck;

        bool gameRunning;
        bool playerHit = false;


        public BlackJackGame()
        {
            gameRunning = true;
        }


        internal void Main()
        {

            // Creates All the Decks and sets playable cards. 
            CreatePlayableDecks();

            // Creates players hand
            playerHand = new PlayerHand(gameDeck);

            // Creates dealers hand
            dealerHand = new DealerHand(gameDeck);

            Console.WriteLine("Your Cards: ");
            playerHand.ShowCards();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your Hand: " + playerHand.handValue);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nDealer's hand: ");
            dealerHand.ShowCard();
            Console.WriteLine("[Hidden Card]");



            Console.WriteLine("\nHit, Stand or Double Down");

            // Loop for game
            while (gameRunning)
            {

                string playerInput = Console.ReadLine();

                if (playerInput.ToUpper() != null || playerInput.ToUpper() == "")
                {
                    if (playerInput.ToUpper() == "HIT")
                    {

                        HitMe();
                        playerHit = true;
                    }
                    else if (playerInput.ToUpper() == "STAND")
                    {
                        Stand();
                    }
                    else if(playerInput.ToUpper() =="DOUBLE DOWN" && !playerHit)
                    {
                        DoubleDown();
                    }
                    else
                    {
                        WrongInput();
                    }
                }
            }

            
        }



        private void CreatePlayableDecks()
        {
            gameDeck = new Deck();
            gameDeck.ShuffleDeck();
        }
        private void CheckGameStatus()
        {

            if (dealerHand.handValue > 21)
            {
                DealerBust();
                return;
            }
            
            if (playerHand.handValue > dealerHand.handValue)
            {
                PlayerWon();
                return;
            }
            // Dealer Wina
            else if (playerHand.handValue < dealerHand.handValue)
            {
                DealerWon();
                return;
            }
            else if (playerHand.handValue == dealerHand.handValue)
            {
                Push();
                return;
            }
        }
        private void WrongInput()
        {
            // Does a reset of the UI 
            Console.Clear();
            Console.WriteLine("Your Cards: ");
            playerHand.ShowCards();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your hand: " + playerHand.handValue);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nDealer's hand: ");
            dealerHand.ShowCard();
            Console.WriteLine("[Hidden Card]");

            Console.WriteLine("\nHit or Stand");
        }

        private void HitMe()
        {
            // Give player a card
            playerHand.DrawCard(gameDeck);

            // Going over 21 ends game
            if (playerHand.handValue > 21)
            {
                PlayerBust();
                gameRunning = false;
                return;
            }

            // UI
            SConsole.Clear();
            Console.WriteLine("Your Cards: ");
            playerHand.ShowCards();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your hand: " + playerHand.handValue);
            Console.ForegroundColor = ConsoleColor.Gray;


            Console.WriteLine("\nDealer's hand: ");
            dealerHand.ShowCard();
            Console.WriteLine("[Hidden Card]");

            Console.WriteLine("\nHit or Stand");
        }
        private void Stand()
        {
            gameRunning = false;

            // Draws cards until dealers hand is 17 or above
            while (dealerHand.handValue <= 17)
            {
                dealerHand.DrawCard(gameDeck);
            }

            CheckGameStatus();
        }
        private void DoubleDown()
        {
            gameRunning = false;

            // Doubeling down only gives one card
            playerHand.DrawCard(gameDeck);

            while (dealerHand.handValue <= 17)
            {
                dealerHand.DrawCard(gameDeck);
            }


            // then ends game
            CheckGameStatus();
        }

        private void Push()
        {
            Console.Clear();
            Console.WriteLine("Your Cards: ");
            playerHand.ShowCards();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(playerHand.handValue);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nDealer's hand: ");
            dealerHand.ShowCards();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(dealerHand.handValue);
            Console.WriteLine("\nPUSH!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void PlayerBust()
        {
            Console.Clear();
            Console.WriteLine("Your Cards: ");
            playerHand.ShowCards();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[BUST!] " + playerHand.handValue);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nDealer's hand: ");
            dealerHand.ShowCards();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(dealerHand.handValue);
            Console.WriteLine("\nDealer Won!");
            Console.ForegroundColor = ConsoleColor.Gray;

            
        }
        private void DealerBust()
        {
            Console.Clear();
            Console.WriteLine("Your Cards: ");
            playerHand.ShowCards();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your hand: " + playerHand.handValue);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nDealer's hand: ");
            dealerHand.ShowCards();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[BUST!] " + dealerHand.handValue);
            Console.WriteLine("\nPlayer Won!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void PlayerWon()
        {
            Console.Clear();
            Console.WriteLine("Your Cards: ");
            playerHand.ShowCards();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your Hand: " + playerHand.handValue);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nDealers hand: ");
            dealerHand.ShowCards();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Dealer's Hand: " + dealerHand.handValue);
            Console.WriteLine("\nPlayer Won");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void DealerWon()
        {
            Console.Clear();
            Console.WriteLine("Your Cards: ");
            playerHand.ShowCards();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your Hand: " + playerHand.handValue);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nDealer's hand: ");
            dealerHand.ShowCards();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(dealerHand.handValue);
            Console.WriteLine("\nDealer Won!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /*private void PrintWholeDeck(Deck deck)
        {
            Console.WriteLine("Deck:  ");
            for (int i = 0; i < 312; i++)
            {
                Console.Write("{0, -25}", deck.DealCard());
                if ((i + 1) % 4 == 0)
                {
                    Console.WriteLine();
                }

            }
            Console.WriteLine();
        }*/
        /*private void PrintCard(Deck deck)
        {
            Console.Write(deck.DealCard());
        }*/
    }
}