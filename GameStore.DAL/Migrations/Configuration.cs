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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameStore.DAL.GamesStoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Publishers.Add(new Models.PublisherEntity()
            {
                Name = "EA",
                Description = "",
                Support = new Models.SupportEntity()
                {
                    Address = "Electronic Arts Inc.209 Redwood Shores Parkway Redwood City, CA 94065",
                    Email = "help.ea.com",
                    Phone = "650-628-1422"
                }
            });

            context.Publishers.Add(new Models.PublisherEntity()
            {
                Name = "Valve",
                Description = "",
                Support = new Models.SupportEntity()
                {
                    Address = "PO BOX 1688Bellevue, WA 98009",
                    Email = "help@valvesoftware.com",
                    Phone = ""
                }
            });

            context.Publishers.Add(new Models.PublisherEntity()
            {
                Name = "Valve",
                Description = "",
                Support = new Models.SupportEntity()
                {
                    Address = "PO BOX 1688Bellevue, WA 98009",
                    Email = "help@valvesoftware.com",
                    Phone = ""
                }
            });

            context.SaveChanges();

            PublisherEntity publisherEa = context.Publishers.Where(p => p.Name == "Ea").FirstOrDefault();
            Guid publisherEaId = publisherEa.Id;

            context.Games.Add(new Models.GameEntity()
            {
                Name = "Fifa",
                Genre = "Sports",
                Description = "Sports game bla bla",
                Price = 40,
                PublisherId = publisherEaId,
                OsSupport = "Ps3"
            });

            context.Games.Add(new Models.GameEntity()
            {
                Name = "NBA",
                Genre = "Sports",
                Description = "Sports game bla bla",
                Price = 50,
                PublisherId = publisherEaId,
                OsSupport = "PC"
            });

            context.Games.Add(new Models.GameEntity()
            {
                Name = "Mass Effect",
                Genre = "Rpg",
                Description = "bla bla",
                Price = 25,
                PublisherId = publisherEaId,
                OsSupport = "PC"
            });

            PublisherEntity valve = context.Publishers.Where(p => p.Name == "Valve").FirstOrDefault();
            Guid valveId = valve.Id;

            context.Games.Add(new Models.GameEntity()
            {
                Name = "HL",
                Genre = "Shooter",
                Description = "",
                Price = 40,
                PublisherId = valveId,
                OsSupport = "PC"
            });

            context.Games.Add(new Models.GameEntity()
            {
                Name = "CS",
                Genre = "Shooter",
                Description = "njeh njeh",
                Price = 47,
                PublisherId = valveId,
                OsSupport = "PC"
            });

            context.SaveChanges();
        }
    }
}
