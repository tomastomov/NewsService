namespace NewsService.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using Models.Models;
    using System;

    public class NewsController : BaseApiController
    {
        private readonly INewService news;

        public NewsController(INewService news)
        {
            this.news = news;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allNews = this.news.All();

            if(allNews == null)
            {
                return NotFound();
            }

            return Ok(allNews);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewsFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            this.news.Create(
                model.Title,
                model.Content,
                model.PublishDate);

            return Created(new Uri(@"https://localhost:44316/"),model);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] NewsFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var exists = this.news.Exists(id);

            if (!exists)
            {
                return NotFound();
            }

            news.Edit(id,
                model.Title,
                model.Content,
                model.PublishDate);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var exists = this.news.Exists(id);

            if (!exists)
            {
                return NotFound();
            }

            this.news.Delete(id);

            return Ok();
        }
    }
}
    