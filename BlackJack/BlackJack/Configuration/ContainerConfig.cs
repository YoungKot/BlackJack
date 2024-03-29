﻿using Autofac;
using BlackJack.Interfaces;

namespace BlackJack.Configuration
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Game>().As<IGame>();
            builder.RegisterType<Card>().As<ICard>();
            builder.RegisterType<Deck>().As<IDeck>();
            builder.RegisterType<Player>().As<IPlayer>();

            return builder.Build();
        }
    }
}
