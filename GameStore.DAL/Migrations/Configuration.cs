namespace GameStore.DAL.Migrations
{
    using GameStore.Common;
    using GameStore.DAL.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameStore.DAL.GamesStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameStore.DAL.GamesStoreContext context)
        {/*
            context.Publishers.Add(new PublisherEntity()
            {
                Description = "Seven hundred twelve counts of extortion. Eight hundred and forty-nine counts of racketeering. Two hundred and forty-six counts of fraud. Eighty-seven counts of conspiracy murder.Five hundred and twenty-seven counts of obstruction of justice. How do the defendants plead?",
                Name = "EA",
                Support = new SupportEntity()
                {
                    Address = "Electronic Arts Inc. ,Privacy Policy Administrator, 209 Redwood Shores Parkway ,Redwood City, CA 94065 ,United States",
                    Email = "help.ea.com",
                    Phone = "650-628-1393"
                },
                Games = new List<GameEntity>()
                {
                    new GameEntity() 
                    {
                        Genre = "Sports",
                        Name = "Fifa",
                        Description = "The city needs Bruce Wayne, your resources, your knowledge. It doesn't need your body or your life. That time is past.",
                        OsSupport = "PC, PS4",
                        Price = 40          
                    },
                    new GameEntity() 
                    {
                        Genre = "Sports",
                        Name = "Nba",
                        Description = "The city needs Bruce Wayne, your resources, your knowledge. It doesn't need your body or your life. That time is past.",
                        OsSupport = "PC, PS4",
                        Price = 40
                    },
                    new GameEntity() 
                    {
                        Genre = "BF",
                        Name = "Shooter",
                        Description = "Oh, hee-hee, aha. Ha, ooh, hee, ha-ha, ha-ha. And I thought my jokes were bad.",
                        OsSupport = "PC",
                        Price = 20
                    },
                }
            });

            context.Publishers.Add(new PublisherEntity()
            {
                Description = "Death does not wait for you to be ready! Death is not considerate of fair! And make no mistake, here you face death. Tiger. Jujitsu. Panther. You're skilled. But this is not a dance. And you are afraid. But not of me. Tell us Mr. Wayne, what do you fear?",
                Name = "Valve",
                Support = new SupportEntity()
                {
                    Address = "PO BOX 1688, Bellevue, WA 98009",
                    Email = "help.ea.com",
                    Phone = "sdk@valvesoftware.com"
                },
                Games = new List<GameEntity>()
                {
                    new GameEntity()
                    {
                        Genre = "HL",
                        Name = "Shooter",
                        Description = "Bane was a member of the League of Shadows. And then he was excommunicated. And any man who is too extreme for Ra's Al Ghul, is not to be trifled with.",
                        OsSupport = "PC",
                        Price = 30
                    }
                }
            });


            context.Publishers.Add(new PublisherEntity()
            {
                Description = "No, no, no. A vigilante is just a man lost in scramble for his own gratification. He can be destroyed or locked up. But if you make yourself more than just a man, if you devote yourself to an idel and if they can't stop you then you become something else entirely. Legend, Mr Wayne.",
                Name = "Blizzad",
                Support = new SupportEntity()
                {
                    Address = "Blizzard Entertainment SAS, TSA 60001 ,78008 Versailles CEDEX ,France ",
                    Email = "tours@blizzard.com.",
                    Phone = "489 952 457"
                },
                Games = new List<GameEntity>()
                {
                    new GameEntity() 
                    {
                        Genre = "Wow",
                        Name = "RPG",
                        Description = "We have purged your fear. You are ready to Iead these men. You are ready to become a member of the League of Shadows. But first, you must demonstrate your commitment to justice.",
                        OsSupport = "Xobx",
                        Price = 20
                    },
                    new GameEntity() 
                    {
                        Genre = "RPG",
                        Name = "Bla",
                        Description = "You care about justice? Look beyond your own pain, Bruce. This city is rotting.",
                        OsSupport = "SNES",
                        Price = 10
                    },
                    new GameEntity() 
                    {
                        Genre = "Tekken",
                        Name = "Fighting",
                        Description = "And as for the television's so-called plan, Batman has no jurisdiction.",
                        OsSupport = "Ps3",
                        Price = 150
                    },
                }
            });*/
            
            
            Image image1 = Image.FromFile(@"C:\Users\Luka/Desktop\slika1.png");

            GameEntity game = context.Games.Where(g => g.Name == "Fifa").First();
            game.GameImages = new List<GameImageEntity>()
            {
                new GameImageEntity()
                {
                    GameId = game.Id,
                    Content = Utilities.ImageToArray(image1)
                }
               
            };

            context.Games.AddOrUpdate(game);

            context.SaveChanges();
        }
    }
}




