namespace GameStore.DAL.Migrations
{
    using GameStore.DAL.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GameStore.DAL.GamesStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameStore.DAL.GamesStoreContext context)
        {

            //context.Publishers.Add(new PublisherEntity()
            //{
            //    Description = "Seven hundred twelve counts of extortion. Eight hundred and forty-nine counts of racketeering. Two hundred and forty-six counts of fraud. Eighty-seven counts of conspiracy murder.Five hundred and twenty-seven counts of obstruction of justice. How do the defendants plead?",
            //    Name = "EA",
            //    Support = new SupportEntity()
            //    {
            //        Address = "Electronic Arts Inc. ,Privacy Policy Administrator, 209 Redwood Shores Parkway ,Redwood City, CA 94065 ,United States",
            //        Email = "help.ea.com",
            //        Phone = "650-628-1393"
            //    },
            //    Games = new List<GameEntity>()
            //    {
            //        new GameEntity() 
            //        {
            //            Genre = "Sports",
            //            Name = "Fifa",
            //            Description = "The city needs Bruce Wayne, your resources, your knowledge. It doesn't need your body or your life. That time is past.",
            //            OsSupport = "PC, PS4",
            //            Price = 40  ,
            //            IsInCart = false
            //        },
            //        new GameEntity() 
            //        {
            //            Genre = "Sports",
            //            Name = "Nba",
            //            Description = "The city needs Bruce Wayne, your resources, your knowledge. It doesn't need your body or your life. That time is past.",
            //            OsSupport = "PC, PS4",
            //            Price = 40,
            //            IsInCart = false
            //        },
            //        new GameEntity() 
            //        {
            //            Genre = "Shooter",
            //            Name = "Battlefield",
            //            Description = "Oh, hee-hee, aha. Ha, ooh, hee, ha-ha, ha-ha. And I thought my jokes were bad.",
            //            OsSupport = "PC",
            //            Price = 20,
            //            IsInCart = false
            //        },
            //    }
            //});
            //context.Publishers.Add(new PublisherEntity()
            //{
            //    Description = "Death does not wait for you to be ready! Death is not considerate of fair! And make no mistake, here you face death. Tiger. Jujitsu. Panther. You're skilled. But this is not a dance. And you are afraid. But not of me. Tell us Mr. Wayne, what do you fear?",
            //    Name = "Valve",
            //    Support = new SupportEntity()
            //    {
            //        Address = "PO BOX 1688, Bellevue, WA 98009",
            //        Email = "help.ea.com",
            //        Phone = "sdk@valvesoftware.com"
            //    },
            //    Games = new List<GameEntity>()
            //    {
            //        new GameEntity()
            //        {
            //            Genre = "Shooter",
            //            Name = "Half-life",
            //            Description = "Bane was a member of the League of Shadows. And then he was excommunicated. And any man who is too extreme for Ra's Al Ghul, is not to be trifled with.",
            //            OsSupport = "PC",
            //            Price = 30,
            //            IsInCart = false
            //        },
            //        new GameEntity()
            //        {
            //            Genre = "Puzzle",
            //            Name = "Portal",
            //            Description = "But I know the rage that drives you. That impossible anger strangIing the grief until the memory of your loved one is just poison in your veins. And one day, you catch yourself wishing the person you loved had never existed so you'd be spared your pain.",
            //            OsSupport = "PC, Ps3, Xbox360",
            //            Price = 50,
            //            IsInCart = false
            //        },
            //        new GameEntity()
            //        {
            //            Genre = "Shooter",
            //            Name = "Left4Dead",
            //            Description = "Let me get this straight. You think that your client, one of the wealthiest, most powerful men in the world is secretly a vigilante who spends his nights beating criminals to a pulp with his bare hands and your plan is to blackmail this person? Good luck.",
            //            OsSupport = "PC, Ps3, Xbox360",
            //            Price = 27,
            //            IsInCart = false
            //        },
            //        new GameEntity()
            //        {
            //            Genre = "Rpg",
            //            Name = "Dota2",
            //            Description = "Death does not wait for you to be ready! Death is not considerate of fair! And make no mistake, here you face death. Tiger. Jujitsu. Panther. You're skilled. But this is not a dance. And you are afraid. But not of me. Tell us Mr. Wayne, what do you fear?",
            //            OsSupport = "PC",
            //            Price = 0,
            //            IsInCart = false
            //        },

            //    }
            //});
            //context.Publishers.Add(new PublisherEntity()
            //{
            //    Description = "No, no, no. A vigilante is just a man lost in scramble for his own gratification. He can be destroyed or locked up. But if you make yourself more than just a man, if you devote yourself to an idel and if they can't stop you then you become something else entirely. Legend, Mr Wayne.",
            //    Name = "Blizzard",
            //    Support = new SupportEntity()
            //    {
            //        Address = "Blizzard Entertainment SAS, TSA 60001 ,78008 Versailles CEDEX ,France ",
            //        Email = "tours@blizzard.com.",
            //        Phone = "489 952 457"
            //    },
            //    Games = new List<GameEntity>()
            //    {
            //        new GameEntity() 
            //        {
            //            Genre = "RPG",
            //            Name = "Wow",
            //            Description = "We have purged your fear. You are ready to Iead these men. You are ready to become a member of the League of Shadows. But first, you must demonstrate your commitment to justice.",
            //            OsSupport = "Xobx",
            //            Price = 20,
            //            IsInCart = false
            //        },
            //        new GameEntity() 
            //        {
            //            Genre = "RPG",
            //            Name = "Diablo",
            //            Description = "You care about justice? Look beyond your own pain, Bruce. This city is rotting.",
            //            OsSupport = "SNES",
            //            Price = 10,
            //            IsInCart = false
            //        },
            //        new GameEntity() 
            //        {
            //            Genre = "Fighting",
            //            Name = "Tekken",
            //            Description = "And as for the television's so-called plan, Batman has no jurisdiction.",
            //            OsSupport = "Ps3",
            //            Price = 150,
            //            IsInCart = false
            //        },
            //    }
            //});

            //context.Publishers.Add(new PublisherEntity()
            //{
            //    Description = "Look around you. You'll see two councilmen, a union official, couple off-duty cops and a judge. I wouldn't have a second's hesitation of blowing your head off in front of them. Now, that's power you can't buy. That's the power of fear.",
            //    Name = "Codemasteers",
            //    Support = new SupportEntity()
            //    {
            //        Address = "Codemasters Southam Studio Lower Farm, Stoneythorpe, Southam Warwickshire, CV47 2DL",
            //        Email = "custservice@codemasters.com",
            //        Phone = "+44 (0) 1926 814132"
            //    },
            //    Games = new List<GameEntity>()
            //    {
            //        new GameEntity() 
            //        {
            //            Genre = "Racing",
            //            Name = "Dirt",
            //            Description = "Never start with the head. The victim gets all fuzzy. He can't feel the next... See?",
            //            OsSupport = "PS4",
            //            Price = 20  ,
            //            IsInCart = false
            //        },
            //        new GameEntity() 
            //        {
            //            Genre = "Racing",
            //            Name = "Formula1",
            //            Description = "Behind you, stands a symbol of oppression. Blackgate Prison, where a thousand men have languished under the name of this man: Harvey Dent.",
            //            OsSupport = "Jumbo Mumbo",
            //            Price = 30,
            //            IsInCart = false
            //        },
            //        new GameEntity() 
            //        {
            //            Genre = "Racing",
            //            Name = "Grid",
            //            Description = "I think you and your friend have found the last game in town. where it hurts, their wallets. It's bold. You gonna count me in?",
            //            OsSupport = "Ultratron 3000",
            //            Price = 70,
            //            IsInCart = false
            //        },
            //    }
            //});

            //context.SaveChanges();

            //// Fifa
            //Image image1 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika1.png");
            //GameEntity game = context.Games.Where(g => g.Name == "Fifa").First();
            //game.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game.Id,
            //        Content = Utilities.ImageToArray(image1)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game);



            //// Nba
            //Image image2 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika2.png");
            //GameEntity game2 = context.Games.Where(g => g.Name == "Nba").First();
            //game2.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game2.Id,
            //        Content = Utilities.ImageToArray(image2)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game2);

            ////Battlefield
            //Image image3 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika3.png");
            //GameEntity game3 = context.Games.Where(g => g.Name == "Battlefield").First();
            //game3.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game3.Id,
            //        Content = Utilities.ImageToArray(image3)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game3);

            ////Half-life
            //Image image4 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika4.png");
            //GameEntity game4 = context.Games.Where(g => g.Name == "Half-life").First();
            //game4.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game4.Id,
            //        Content = Utilities.ImageToArray(image4)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game4);

            ////Portal
            //Image image5 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika5.png");
            //GameEntity game5 = context.Games.Where(g => g.Name == "Portal").First();
            //game5.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game5.Id,
            //        Content = Utilities.ImageToArray(image5)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game5);

            ////Left4Dead
            //Image image6 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika6.png");
            //GameEntity game6 = context.Games.Where(g => g.Name == "Left4Dead").First();
            //game6.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game6.Id,
            //        Content = Utilities.ImageToArray(image6)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game6);

            ////Left4Dead
            //Image image7 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika7.png");
            //GameEntity game7 = context.Games.Where(g => g.Name == "Dota2").First();
            //game7.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game7.Id,
            //        Content = Utilities.ImageToArray(image7)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game7);

            ////Wow
            //Image image8 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika8.png");
            //GameEntity game8 = context.Games.Where(g => g.Name == "Wow").First();
            //game8.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game8.Id,
            //        Content = Utilities.ImageToArray(image8)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game8);

            ////Wow
            //Image image9 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika9.png");
            //GameEntity game9 = context.Games.Where(g => g.Name == "Diablo").First();
            //game9.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game9.Id,
            //        Content = Utilities.ImageToArray(image9)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game9);

            ////Tekken
            //Image image10 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika10.png");
            //GameEntity game10 = context.Games.Where(g => g.Name == "Tekken").First();
            //game10.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game10.Id,
            //        Content = Utilities.ImageToArray(image10)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game10);

            ////Tekken
            //Image image11 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika11.png");
            //GameEntity game11 = context.Games.Where(g => g.Name == "Dirt").First();
            //game11.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game11.Id,
            //        Content = Utilities.ImageToArray(image11)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game11);

            ////Tekken
            //Image image12 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika12.png");
            //GameEntity game12 = context.Games.Where(g => g.Name == "Formula1").First();
            //game12.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game12.Id,
            //        Content = Utilities.ImageToArray(image12)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game12);

            ////Tekken
            //Image image13 = Image.FromFile(@"C:\Users\Luka\Desktop\bla\slika13.png");
            //GameEntity game13 = context.Games.Where(g => g.Name == "Grid").First();
            //game13.GameImages = new List<GameImageEntity>()
            //{
            //    new GameImageEntity()
            //    {
            //        GameId = game13.Id,
            //        Content = Utilities.ImageToArray(image13)
            //    }
               
            //};
            //context.Games.AddOrUpdate(game13);
          

                PublisherEntity p = new PublisherEntity()
                {
                    Id = Guid.Empty,
                    Support = null
                };

                context.Publishers.Add(p);

                context.SaveChanges();
           
        }
    }
}



