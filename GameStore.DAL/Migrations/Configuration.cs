namespace GameStore.DAL.Migrations
{
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

            //context.Publishers.Add(new Models.PublisherEntity()
            //{
            //    Id = 1,
            //    Name = "Ea",
            //    Description = "Trebao bih izbacit ovo",
            //    Support = new Models.SupportEntity()
            //    {
            //        Address = "Balitmore",
            //        PublisherId = 1,
            //        Phone = "015552555",
            //        Email = "Ea@support.com",
            //    }
            //});

            //context.Publishers.Add(new Models.PublisherEntity()
            //{
            //    Id = 2,
            //    Name = "Valve",
            //    Description = "Zbilja",
            //    Support = new Models.SupportEntity()
            //    {
            //        Address = "Čačinci",
            //        PublisherId = 2,
            //        Phone = "0188825535",
            //        Email = "Valve@support.com",
            //    }
            //});

            //context.Publishers.Add(new Models.PublisherEntity()
            //{
            //    Id = 3,
            //    Name = "Blizz",
            //    Description = "Ali ono",
            //    Support = new Models.SupportEntity()
            //    {
            //        Address = "Preko puta",
            //        PublisherId = 3,
            //        Phone = "013332555",
            //        Email = "Blizz@support.com",
            //    }
            //});

            context.Games.Add(new Models.GameEntity()
            {
                Id = 1,
                Name = "Fifa",
                Description = "Sport game",
                Genre = "Sports",
                Price = 50,
                OsSupport = "Ps3",
                PublisherId = 1,
                ReviewScore = 84,
            });

            context.Games.Add(new Models.GameEntity()
            {
                Id = 2,
                Name = "NBA",
                Description = "Sport game",
                Genre = "Sports",
                Price = 40,
                OsSupport = "Ps3",
                PublisherId = 1,
                ReviewScore = 55
            });

            context.Games.Add(new Models.GameEntity()
            {
                Id = 3,
                Name = "Left4Dead",
                Description = "Zombies",
                Genre = "Shooter",
                Price = 22,
                OsSupport = "PC",
                PublisherId = 2,
                ReviewScore = 90
            });

            context.Games.Add(new Models.GameEntity()
            {
                Id = 4,
                Name = "Wow",
                Description = "",
                Genre = "Role-Playing",
                Price = 60,
                OsSupport = "Mac",
                PublisherId = 3,
                ReviewScore = 55
            });

            context.Games.Add(new Models.GameEntity()
            {
                Id = 5,
                Name = "HL",
                Description = "",
                Genre = "Shooter",
                Price = 50,
                OsSupport = "OS",
                PublisherId = 2,
                ReviewScore = 84
            });

            context.Games.Add(new Models.GameEntity()
            {
                Id = 6,
                Name = "witcher",
                Description = "Meh meh",
                Genre = "Role-Playing",
                Price = 50,
                OsSupport = "Android",
                PublisherId = 2,
                ReviewScore = 99
            });
        }
    }
}
