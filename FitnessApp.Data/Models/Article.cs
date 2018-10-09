namespace FitnessApp.Data.Models
{
    using Common.Contants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(DataConstants.MinArticleTitleLength)]
        [MaxLength(DataConstants.MaxArticleTitleLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.MinArticleContentLength)]
        [MaxLength(DataConstants.MaxArticleContentLength)]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<CategoryArticle> Categories { get; set; } = new List<CategoryArticle>();

    }
}
