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

            context.Support.Add(new Models.SupportEntity()
                {
                    PublisherId = context.Publishers.Where(c => c.Name == "Ea").FirstOrDefault().Id,
                    Address = "blabla",
                    Email = "njeh",
                    Phone = "wafwaf"
                });
            context.SaveChanges();
        }
    }
}
