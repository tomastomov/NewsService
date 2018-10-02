namespace NewsService.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class New
    {
        public int Id { get; set; }

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
