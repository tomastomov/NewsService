namespace NewsService.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface INewService
    {
        IEnumerable<NewsListingModel> All();

        void Create(string title, string content, DateTime publishDate);

        bool Exists(int id);

        void Delete(int id);

        void Edit(int id,string title, string content, DateTime publishDate);
    }
}
