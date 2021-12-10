using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Game
    {
        private Deck deck = new Deck();
        private Player player = new Player();
        private Dealer dealer = new Dealer();
        private string answer;
        private bool flag;
        private void getResult()
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
        public void PlayGame()
        {   

            Console.WriteLine($"Ace value is {deck.getAceValue().ToString()} ");

            flag = true;
            player.DrawCard(deck);
            player.DrawCard(deck);
            player.SubtractScore();

            dealer.DrawCard(deck);
            dealer.DrawCard(deck);
            dealer.SubtractScore();

            while (true)
            {
                if (flag)
                {
                    Console.WriteLine("Your points are " + player.getPlayerScore().ToString());
                    Console.WriteLine("Your cards are: ");
                    foreach (var card in player.getPlayerCards())
                    {
                        Console.WriteLine(card.Face + " " + card.Suit + " " + card.Value);
                    }
                    Console.WriteLine("Would you like to continue?");
                    Console.WriteLine("Press y or n");
                    answer = Console.ReadLine();
                    flag = false;
                }

                if (answer == "y")
                {
                    player.DrawCard(deck);

                    if (player.getPlayerScore() > 21)
                    {
                        Console.WriteLine("Player have lost!");
                        getResult();
                        break;
                    }
                    else if (player.getPlayerScore() <= 21)
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
                            Console.WriteLine($"Would you like to continue?");
                            Console.WriteLine("Press y or n!");
                            Console.WriteLine($"Your score {player.getPlayerScore()}");
                            answer = Console.ReadLine();
                            if(answer == "y")
                            {
                                continue;
                            }
                            else if(answer == "n")
                            {
                                Console.WriteLine("Tied!");
                                getResult();
                                break;
                            }
                        }
                        else if (dealer.getDealerScore() < player.getPlayerScore() && player.getPlayerScore() < 21)
                        {
                            Console.WriteLine($"Would you like to continue?");
                            Console.WriteLine("Press y or n!");
                            Console.WriteLine($"Your score {player.getPlayerScore()}");
                            answer = Console.ReadLine();
                            if (answer == "y")
                            {
                                continue;
                            }
                            else if (answer == "n")
                            {
                                Console.WriteLine("Player won!");
                                getResult();
                                break;
                            }
                        }
                        else if (dealer.getDealerScore() > player.getPlayerScore() && dealer.getDealerScore() < 21)
                        {
                            Console.WriteLine($"Would you like to continue?");
                            Console.WriteLine("Press y or n!");
                            Console.WriteLine($"Your score {player.getPlayerScore()}");
                            answer = Console.ReadLine();
                            if (answer == "y")
                            {
                                continue;
                            }
                            else if (answer == "n")
                            {
                                Console.WriteLine("Dealer won!");
                                getResult();
                                break;
                            }
                        }
                        else if(dealer.getDealerScore() == 21)
                        {
                            Console.WriteLine("Dealer won!");
                            getResult();
                            break;
                        }
                        else if (player.getPlayerScore() == 21)
                        {
                            Console.WriteLine("Player won!");
                            getResult();
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (answer == "n")
                {
                    if (player.getPlayerScore() == dealer.getDealerScore())
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
                    Console.WriteLine("Incorrect answer. Answer can be y or n!");
                    flag = true;
                    continue;
                }
            }
        }
    }
}
