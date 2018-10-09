namespace FitnessApp.Data.Models
{
    using FitnessApp.Common.Contants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.MinPostTitleLength)]
        [MaxLength(DataConstants.MaxPostTitleLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.MinPostContentLength)]
        [MaxLength(DataConstants.MaxPostContentLength)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}