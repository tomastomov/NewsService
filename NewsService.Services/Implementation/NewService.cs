namespace NewsService.Services.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Data;
    using Data.Models;
    using Models;

    public class NewService : INewService
    {
        private readonly NewsServiceDbContext db;

        public NewService(NewsServiceDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<NewsListingModel> All()
            => this.db.News
                .OrderByDescending(n => n.PublishDate)
                .ProjectTo<NewsListingModel>()
                .ToList();

        public void Create(string title, string content, DateTime publishDate)
        {
            var news = new New
            {
                Title = title,
                Content = content,
                PublishDate = publishDate
            };

            this.db.News.Add(news);

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var news = this.db.News.Find(id);

            if(news == null)
            {
                return;
            }

            this.db.Remove(news);

            db.SaveChanges();
        }

        public void Edit(int id,string title, string content, DateTime publishDate)
        {
            var news = this.db.News.FirstOrDefault(n => n.Id == id);

            if(news == null)
            {
                throw new InvalidOperationException("Invalid action was being attempted to perform!");
            }

            news.Title = title;
            news.Content = content;
            news.PublishDate = publishDate;

            db.SaveChanges();
        }

        public bool Exists(int id)
            => this.db.News.Any(n => n.Id == id);
    }
}
