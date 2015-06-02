namespace GameStore.DAL.Migrations
{
    using GameStore.DAL.Models;
    using System;
    using System.Collections.Generic;
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
            context.Publishers.Add(new CompanyEntity()
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

            context.Publishers.Add(new CompanyEntity()
            {
                Id = 2,
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


            context.SaveChanges();
        }
    }
}
