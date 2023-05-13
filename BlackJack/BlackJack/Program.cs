using Autofac;
using BlackJack.Configuration;
using BlackJack.Interfaces;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using var scope = container.BeginLifetimeScope();
            var game = scope.Resolve<IGame>();
            game.PlayGame();
        }
    }
}
