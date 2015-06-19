using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameStore.Model.Common;
using System.Collections.Generic;
using GameStore.Model;
using Moq;
using GameStore.Repository.Common;
using Service.Common;
using GameStore.Service;
using System.Threading.Tasks;
using GameStore.Common;

namespace Service.Test
{
    [TestClass]
    public class GameServiceTest
    {
        List<IGame> gameList;
        /*
        [TestInitialize]
        public void Initialize()
        {
            gameList = new List<IGame>()
            {
                new Game()
                {
                    Id = 1,
                    Name = "Fifa",
                    Description = "Sport game",
                    Genre = "Sports",
                    Price = 50,
                    OsSupport = "Ps3",
                    PublisherId = 1,
                    ReviewScore = 84,
                },

            new Game()
                {
                    Id = 2,
                    Name = "NBA",
                    Description = "Sport game",
                    Genre = "Sports",
                    Price = 40,
                    OsSupport = "Ps3",
                    PublisherId = 1,
                    ReviewScore = 55
                },

            new Game()
                {
                    Id = 3,
                    Name = "Left4Dead",
                    Description = "Zombies",
                    Genre = "Shooter",
                    Price = 22,
                    OsSupport = "PC",
                    PublisherId = 2,
                    ReviewScore = 90
                }
            };
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Mock<IGameRepository> mockGamesRepo = new Mock<IGameRepository>();
            mockGamesRepo.Setup(m => m.GetAsync(It.IsAny<int>())).ReturnsAsync(gameList[0]);

            IGamesService service = new GamesService(mockGamesRepo.Object);
            Task<IGame> result = service.GetAsync(2535);

            Assert.AreEqual(result.Result.Name, "Fifa");
        }

        [TestMethod]
        public void GetByNameTest()
        {
            Mock<IGameRepository> mockGameRepo = new Mock<IGameRepository>();
            mockGameRepo.Setup(m => m.GetRangeAsync(It.IsAny<string>())).ReturnsAsync(gameList);

            IGamesService service = new GamesService(mockGameRepo.Object);
            Task<IEnumerable<IGame>> result = service.GetRangeAsync("Mjao");

            Assert.AreEqual(gameList.ToString(),result.ToString());
        }

        [TestMethod]
        public void GetRangeTest()
        {
            Mock<IGameRepository> mockGameRepo = new Mock<IGameRepository>();
            mockGameRepo.Setup(m => m.GetRangeAsync(It.IsAny<GameFilter>())).ReturnsAsync(gameList);

            IGamesService service = new GamesService(mockGameRepo.Object);
            Task<IEnumerable<IGame>> result = service.GetRangeAsync(new GameFilter(2, 5));

            Assert.AreEqual(result.Result.ToString(), gameList.ToString());
        }

        [TestMethod]
        public void GetListOfGamesThatBelongToPublisherTest()
        {
            Mock<IGameRepository> mockGameRepo = new Mock<IGameRepository>();
            mockGameRepo.Setup(m => m.GetRangeAsync(It.IsAny<int>())).ReturnsAsync(gameList);

            IGamesService service = new GamesService(mockGameRepo.Object);
            Task<IEnumerable<IGame>> result = service.GetRangeAsync(new GameFilter(2, 2));

            Assert.AreEqual(result.Result.ToString(), gameList.ToString());
        }*/
    }
}
