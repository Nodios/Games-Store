using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameStore.Model.Common;
using System.Collections.Generic;
using GameStore.Model;
using Service.Common;
using Moq;
using GameStore.Repository.Common;
using GameStore.Service;
using System.Threading.Tasks;
using GameStore.Common;

namespace Service.Test
{
    [TestClass]
    public class PublisherServiceTest
    {
        List<IPublisher> publisherList;

        [TestInitialize]
        public void Initialize()
        {
            publisherList = new List<IPublisher>()
            {
        
            new Publisher(){
                Id = 1,
                Name = "ea",
                Description = "trebao bih izbacit ovo",
                Support = new Support()
                {
                    Address = "balitmore",
                    Phone = "015552555",
                    Email = "ea@support.com",
                }
            },

            new Publisher()
            {
                Id = 2,
                Name = "valve",
                Description = "zbilja",
                Support = new Support()
                {
                    Address = "čačinci",
                    Phone = "0188825535",
                    Email = "valve@support.com",
                }
            },

            new Publisher()
            {
                Id = 3,
                Name = "blizz",
                Description = "ali ono",
                Support = new Support()
                {
                    Address = "preko puta",
                    Phone = "013332555",
                    Email = "blizz@support.com",
                }
            }
            };
        }

        [TestMethod]
        public void GetPublisherByIdTest()
        {
            Mock<IPublisherRepository> mockPublisherRepo = new Mock<IPublisherRepository>();
            Mock<ISupportRepository> mockSupportRepo = new Mock<ISupportRepository>();
            mockPublisherRepo.Setup(m => m.GetAsync(It.IsAny<int>())).ReturnsAsync(publisherList[0]);

            IPublisherService service = new PublisherService(mockPublisherRepo.Object, mockSupportRepo.Object);
            Task<IPublisher> result = service.GetAsync(3);
        
            Assert.AreEqual(result.Result.Name, "ea");        
        }

        [TestMethod]
        public void GetSupportByIdTest()
        {
            Mock<IPublisherRepository> mockPublisherRepo = new Mock<IPublisherRepository>();
            Mock<ISupportRepository> mockSupportRepo = new Mock<ISupportRepository>();
            mockSupportRepo.Setup(m => m.GetAsync(It.IsAny<int>())).ReturnsAsync(publisherList[0].Support);

            IPublisherService service = new PublisherService(mockPublisherRepo.Object, mockSupportRepo.Object);
            Task<ISupport> result = service.GetSupportAsync(2);

            Assert.AreEqual(result.Result.Email, "ea@support.com");
        }

        [TestMethod]
        public void GetPublisherByNameTest()
        {
            Mock<IPublisherRepository> mockPublisherRepo = new Mock<IPublisherRepository>();
            Mock<ISupportRepository> mockSupportRepo = new Mock<ISupportRepository>();
            mockPublisherRepo.Setup(m => m.GetAsync(It.IsAny<string>())).ReturnsAsync(publisherList[1]);

            IPublisherService service = new PublisherService(mockPublisherRepo.Object, mockSupportRepo.Object);
            Task<IPublisher> result = service.GetAsync("Nje");

            Assert.AreEqual(result.Result.Id, 2);
        }

        [TestMethod]
        public void GetPublisherRangeTest()
        {
            Mock<IPublisherRepository> mockPublisherRepo = new Mock<IPublisherRepository>();
            Mock<ISupportRepository> mockSupportObject = new Mock<ISupportRepository>();
            mockPublisherRepo.Setup(m => m.GetRangeAsync(It.IsAny<PublisherFilter>())).ReturnsAsync(publisherList);

            IPublisherService service = new PublisherService(mockPublisherRepo.Object, mockSupportObject.Object);
            Task<IEnumerable<IPublisher>> result = service.GetRangeAsync(new PublisherFilter(2, 3));

            Assert.AreEqual(result.Result.ToString(), publisherList.ToString());

        }
    }
}
