namespace NewsService.Test.NewsTests
{
    using Xunit;
    using FluentAssertions;
    using NewsService.Data.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using NewsService.Services.Implementation;
    using NewsService.Data.Models;
    using LearningSystem.Test;

    public class NewsTest
    {
        public NewsTest()
        {
            Tests.Initialize();
        }

        [Fact]
        public void ShouldReturnListOfAllNewsItemsInTheCorrectOrder()
        {
            //Arrange
            var db = this.GetDatabase();
            
            var newsService = new NewService(db);

            var firstNews = new New
            {
                Id = 1,
                Content = "harambe123",
                PublishDate = DateTime.Parse("2018-10-12"),
                Title = "Yeahbuddy"
            };

            var secondNews = new New
            {
                Id = 2,
                Content = "harambdsadae123",
                PublishDate = DateTime.Parse("2018-10-12"),
                Title = "Yeahbdasduddy"
            };

            var thirdNews = new New
            {
                Id = 3,
                Content = "dsadsadsad",
                PublishDate = DateTime.Parse("2018-10-11"),
                Title = "dasdsad"
            };

            db.AddRange(firstNews, secondNews, thirdNews);

            db.SaveChanges();

            //Act

            var result = newsService.All();

            //Assert

            result
               .Should()
               .NotBeNull();
            
            result
                .Should()
                .HaveElementAt(0, firstNews)
                .And
                .HaveElementAt(1, thirdNews)
                .And
                .HaveElementAt(2, secondNews)
                .And
                .HaveCount(3);
            
        }

        private NewsServiceDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<NewsServiceDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new NewsServiceDbContext(dbOptions);
        }
    }
}
