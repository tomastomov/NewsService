namespace NewsService.Services.Models
{
    using Common;
    using Common.Mapping;
    using Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NewsListingModel : IMapFrom<New>
    {
        [Required]
        [MinLength(DataConstants.MinTitleLength)]
        [MaxLength(DataConstants.MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.MinContentLength)]
        [MaxLength(DataConstants.MaxContentLength)]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
