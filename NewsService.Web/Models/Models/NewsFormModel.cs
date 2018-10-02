namespace NewsService.Web.Models.Models
{
    using NewsService.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NewsFormModel
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
