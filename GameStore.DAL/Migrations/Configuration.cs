namespace GameStore.DAL.Migrations
{
    using GameStore.DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameStore.DAL.GamesStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GameStore.DAL.GamesStoreContext context)
        {

            context.Publishers.Add(new PublisherEntity()
            {
                Id = 1,
                Name = "EA",
                Description = "Loves your money",
                Games = null,
                Support = new SupportEntity()
                {
                    Address = "Baltimore",
                    Email = "LoveCash@com",
                    Phone = "555-555-555"
                }
            });


            context.Publishers.Add(new PublisherEntity()
            {
                Id = 2,
                Name = "Valve",
                Description = "Loves food"
            });

            context.Publishers.Add(new PublisherEntity()
            {
                Id = 3,
                Name = "Blizz",
                Description = "Also loves money",
                Games = null,
                Support = new SupportEntity()
                {
                    Address = "Čačinci",
                    Email = "Cash@com",
                    Phone = "555-555-555"
                }
            });

            context.Games.Add(new GameEntity()
            {
                Id = 1,
                PublisherId = 1,
                Name = "Fifa",
                Description = "Nogomet",
                OsSupport = "PC, PS4",
            });

            context.Games.Add(new GameEntity()
            {
                Id = 2,
                PublisherId = 1,
                Name = "NBA",
                Description = "Kosarka",
                OsSupport = "Android",
            });

            context.Games.Add(new GameEntity()
            {
                Id = 3,
                PublisherId = 2,
                Name = "Wow",
                Description = "rpg",
                OsSupport = "PC, PS4",
            });

            context.Games.Add(new GameEntity()
            {
                Id = 4,
                PublisherId = 1,
                Name = "Sims",
                Description = "Waste of time",
                OsSupport = "Sve",
            });

            context.Games.Add(new GameEntity()
            {
                Id = 5,
                PublisherId = 3,
                Name = "Bf",
                Description = "Nanana",
                OsSupport = "Sve",
            });

            context.SaveChanges();
        }
    }
}
