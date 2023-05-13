using BlackJack.Interfaces;
using System;

namespace BlackJack
{
    public class Game : IGame
    {
        private readonly IDeck _deck;

        private readonly IPlayer _player;

        private readonly IPlayer _dealer;

        private string answer;

        private bool flag;

        public Game(IDeck deck, IPlayer player, IPlayer dealer)
        {
            _deck = deck;
            _player = player;
            _dealer = dealer;
        }

        private void GetResult()
        {
            Console.WriteLine("Player points are " + _player.GetScore().ToString());
            Console.WriteLine("Player cards: ");
            foreach (var card in _player.GetCards())
            {
                Console.WriteLine(card.Face + " " + card.Suit + " " + card.Value);
            }

            Console.WriteLine("\nDealer points are " + _dealer.GetScore().ToString());
            Console.WriteLine("Dealer cards: ");
            foreach (var card in _dealer.GetCards())
            {
                Console.WriteLine(card.Face + " " + card.Suit + " " + card.Value);
            }
        }
        public void PlayGame()
        {   
            Console.WriteLine($"Ace value is {_deck.GetAceValue()} ");

            flag = true;
            _player.DrawCard(_deck);
            _player.DrawCard(_deck);
            _player.SubtractScore();

            _dealer.DrawCard(_deck);
            _dealer.DrawCard(_deck);
            _dealer.SubtractScore();

            while (true)
            {
                if (flag)
                {
                    Console.WriteLine("Your points are " + _player.GetScore().ToString());
                    Console.WriteLine("Your cards are: ");
                    foreach (var card in _player.GetCards())
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
                    _player.DrawCard(_deck);

                    if (_player.GetScore() > 21)
                    {
                        Console.WriteLine("Player have lost!");
                        GetResult();
                        break;
                    }
                    else if (_player.GetScore() <= 21)
                    {
                        _dealer.DrawCard(_deck);

                        if (_dealer.GetScore() > 21)
                        {
                            Console.WriteLine("Dealer lost!");
                            GetResult();
                            break;
                        }
                        else if (_player.GetScore() == _dealer.GetScore())
                        {
                            Console.WriteLine($"Would you like to continue?");
                            Console.WriteLine("Press y or n!");
                            Console.WriteLine($"Your score {_player.GetScore()}");
                            answer = Console.ReadLine();
                            if(answer == "y")
                            {
                                continue;
                            }
                            else if(answer == "n")
                            {
                                Console.WriteLine("Tied!");
                                GetResult();
                                break;
                            }
                        }
                        else if (_dealer.GetScore() < _player.GetScore() && _player.GetScore() < 21)
                        {
                            Console.WriteLine($"Would you like to continue?");
                            Console.WriteLine("Press y or n!");
                            Console.WriteLine($"Your score {_player.GetScore()}");
                            answer = Console.ReadLine();
                            if (answer == "y")
                            {
                                continue;
                            }
                            else if (answer == "n")
                            {
                                Console.WriteLine("Player won!");
                                GetResult();
                                break;
                            }
                        }
                        else if (_dealer.GetScore() > _player.GetScore() && _dealer.GetScore() < 21)
                        {
                            Console.WriteLine($"Would you like to continue?");
                            Console.WriteLine("Press y or n!");
                            Console.WriteLine($"Your score {_player.GetScore()}");
                            answer = Console.ReadLine();
                            if (answer == "y")
                            {
                                continue;
                            }
                            else if (answer == "n")
                            {
                                Console.WriteLine("Dealer won!");
                                GetResult();
                                break;
                            }
                        }
                        else if(_dealer.GetScore() == 21)
                        {
                            Console.WriteLine("Dealer won!");
                            GetResult();
                            break;
                        }
                        else if (_player.GetScore() == 21)
                        {
                            Console.WriteLine("Player won!");
                            GetResult();
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
                    if (_player.GetScore() == _dealer.GetScore())
                    {
                        Console.WriteLine("Tied!");
                        GetResult();
                        break;
                    }
                    else if (_dealer.GetScore() < _player.GetScore() && _player.GetScore() <= 21)
                    {
                        Console.WriteLine("Player won!");
                        GetResult();
                        break;
                    }
                    else if (_dealer.GetScore() > _player.GetScore() && _dealer.GetScore() <= 21)
                    {
                        Console.WriteLine("Dealer won!");
                        GetResult();
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
