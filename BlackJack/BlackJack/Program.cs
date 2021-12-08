using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    class Program
    {
        private static string answer;
        private static Deck deck = new Deck();
        private static Player player = new Player();
        private static Dealer dealer = new Dealer();
        private static void getResult()
        {
            Console.WriteLine("Player points are " + player.getPlayerScore().ToString());
            Console.WriteLine("Player cards: ");
            foreach (var card in player.getPlayerCards())
            {
                Console.WriteLine(card.Face + " " + card.Suit + " " + card.Value);
            }

            Console.WriteLine("\nDealer points are " + dealer.getDealerScore().ToString());
            Console.WriteLine("Dealer cards: ");
            foreach (var card in dealer.getDealerCards())
            {
                Console.WriteLine(card.Face + " " + card.Suit + " " + card.Value);
            }
        }

        private static int getAceValue()
        {
            Random rng = new Random();
            var list = new List<int>();
            list.Add(1);
            list.Add(11);
            var AceValue = list.OrderBy(a => rng.Next()).ToList().First();
            return AceValue;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Ace value is {getAceValue().ToString()} ");
            deck.createDeck(getAceValue());
            deck.Shuffle();

            player.DrawCard(deck);
            player.DrawCard(deck);
            player.SubtractScore();

            dealer.DrawCard(deck);
            dealer.DrawCard(deck);
            dealer.SubtractScore();

            while (true)
            {
                Console.WriteLine("Your points are " + player.getPlayerScore().ToString());
                Console.WriteLine("Your cards are: ");
                foreach (var card in player.getPlayerCards())
                {
                    Console.WriteLine(card.Face + " " + card.Suit + " " + card.Value);
                }
                Console.WriteLine("Would you like to continue?");
                Console.WriteLine("Press y/n");
                answer = Console.ReadLine();

                if(answer == "y")
                {
                    player.DrawCard(deck);

                    if (player.getPlayerScore() > 21)
                    {
                        Console.WriteLine("You have lost!");
                        getResult();
                        break;
                    }
                    else if(player.getPlayerScore() <= 21)
                    {
                        dealer.DrawCard(deck);

                        if (dealer.getDealerScore() > 21)
                        {
                            Console.WriteLine("Dealer lost!");
                            getResult();
                            break;
                        }
                        else if (player.getPlayerScore() == dealer.getDealerScore())
                        {
                            Console.WriteLine("Tied!");
                            getResult();
                            break;
                        }
                        else if (dealer.getDealerScore() < player.getPlayerScore() && player.getPlayerScore() <= 21)
                        {
                            Console.WriteLine("Player won!");
                            getResult();
                            break;
                        }
                        else if (dealer.getDealerScore() > player.getPlayerScore() && dealer.getDealerScore() <= 21)
                        {
                            Console.WriteLine("Dealer won!");
                            getResult();
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if(answer == "n")
                {
                    if(player.getPlayerScore() == dealer.getDealerScore())
                    {
                        Console.WriteLine("Tied!");
                        getResult();
                        break;
                    }
                    else if(dealer.getDealerScore() < player.getPlayerScore() && player.getPlayerScore() <= 21)
                    {
                        Console.WriteLine("Player won!");
                        getResult();
                        break;
                    }
                    else if (dealer.getDealerScore() > player.getPlayerScore() && dealer.getDealerScore() <= 21)
                    {
                        Console.WriteLine("Dealer won!");
                        getResult();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect answer. Answer can be y or n!");
                    continue;
                }
            }

        }
    }
}
