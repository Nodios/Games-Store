using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameStore.Model.Common;
using System.Collections.Generic;
using GameStore.Model;
using GameStore.Repository.Common;
using Moq;
using GameStore.Common;
using GameStore.Service.Common;
using GameStore.Service;
using System.Threading.Tasks;

namespace Service.Test
{
    [TestClass]
    public class PostServiceTest
    {
        List<IPost> postsList;
        /*
        [TestInitialize]
        public void Initialize()
        {
            
            postsList = new List<IPost>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "Novi post",
                    GameId = 1,
                    Description = "Ovo je super novi post"
                },
                 new Post()
                {
                    Id = 1,
                    Title = "Novi post 2",
                    GameId = 1,
                    Description = "Ovo je super novi post"
                },
                 new Post()
                {
                    Id = 1,
                    Title = "Novi post 3",
                    GameId = 1,
                    Description = "Ovo je super novi post"
                }
            };
        }

        [TestMethod]
        public void GetPostsTest()
        {
            Mock<IPostRepository> postRepoMock = new Mock<IPostRepository>();
            postRepoMock.Setup(m => m.GetRangeAsync(It.IsAny<int>(), It.IsAny<PostFilter>())).ReturnsAsync(postsList);

            IPostService postService = new PostService(postRepoMock.Object);
            Task<IEnumerable<IPost>> result = postService.GetPosts(3, new PostFilter(2, 5));

            Assert.AreEqual(result.Result.ToString(), postsList.ToString());

        }*/
    }
}
